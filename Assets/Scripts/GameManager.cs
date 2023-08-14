using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Classes;
using Assets.Mobs;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;
using UnityEngine.Video;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour, ISingleton<GameManager>
    {
        [SerializeField] private IItemSystem itemSystem;
        [SerializeField] private List<GameObject> enemies;
        [SerializeField] private Player player;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private float cameraSpeed;
        [SerializeField] private float maxCameraDistance;
        [SerializeField] private bool isMoveCameraWithoutMouse;
        [SerializeField] private Mob mobPrefab;
        [SerializeField] private Hud hud;
        [SerializeField] private StyleSheet hudStyleSheet;
        [SerializeField] private Sprite flameSprite;
        [SerializeField] private Sprite heartSprite;
        [SerializeField] private DialogData dialogData;
        [SerializeField] private DialogTrigger bossDialogTrigger;
        [SerializeField] private bool lockCamera;
        [SerializeField] private Vector3 lockCameraPosition;
        [SerializeField] private Wise wise;
        [SerializeField] private BoxCollider2D bossRoomCollider;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip bossStartMusic;
        [SerializeField] private AudioClip bossLoopMusic;
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private VideoClip videoClip;


        public static GameManager Instance { get; private set; }

        public Hud Hud => hud;

        public Vector2 GetMousePosition()
        {
            return mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        public List<GameObject> Enemies
        {
            get => enemies;
            set => enemies = value;
        }

        public Player Player
        {
            get => player;
            set => player = value;
        }

        private void Awake()
        {
            Instance = this;
            itemSystem = Scripts.ItemSystem.Instance;
            if (mainCamera == null)
                mainCamera = Camera.main;
            // videoPlayer.time = videoClip.length;
            videoPlayer.loopPointReached += (source =>
            {
                hud.gameObject.SetActive(true);
                Destroy(videoPlayer.gameObject);
                Hud.OpenDialog(DialogData.Create(new List<(string speakingRole, string text)>()
                    { ("", "使用方向键以移动，Z键攻击") }));
                if (bossDialogTrigger != null)
                    bossDialogTrigger.OnTriggered += () =>
                    {
                        mainCamera.orthographicSize = 4.4f;
                        lockCamera = true;
                        wise.state = Wise.State.Spell1;
                        bossRoomCollider.enabled = true;
                        audioSource.clip = bossStartMusic;
                        audioSource.Play();
                        audioSource.loop = false;
                        StartCoroutine(ChangeClip());
                    };

                IEnumerator ChangeClip()
                {
                    yield return new WaitForSeconds(bossStartMusic.length);
                    audioSource.clip = bossLoopMusic;
                    audioSource.loop = true;
                    audioSource.Play();
                }
            });
        }

        private void Start()
        {
        }

        private void Update()
        {
        }

        private void LateUpdate()
        {
            if (isMoveCameraWithoutMouse)
                MoveCameraWithoutMouse();
            else
                MoveCamera();

            void MoveCamera()
            {
                var cameraPosition = mainCamera.transform.position;
                Vector2 playerPosition = player.transform.position;
                var mousePosition = GetMousePosition();
                var targetPosition = Vector2.Lerp(mousePosition, playerPosition, 0.5f);
                targetPosition = (targetPosition - playerPosition).magnitude > maxCameraDistance
                    ? (targetPosition - playerPosition).normalized * maxCameraDistance + playerPosition
                    : targetPosition;
                var direction = targetPosition - (Vector2)cameraPosition;
                cameraPosition += (Vector3)(direction * (cameraSpeed * Time.deltaTime));
                mainCamera.transform.position = cameraPosition;
            }

            void MoveCameraWithoutMouse()
            {
                if (lockCamera)
                {
                    mainCamera.transform.position = lockCameraPosition;
                    return;
                }

                var position = player.transform.position;
                position.z = mainCamera.transform.position.z;
                mainCamera.transform.position = position;
            }
        }

        public void GameOver()
        {
            StartCoroutine(Enu());

            IEnumerator Enu()
            {
                yield return new WaitForSeconds(1.0f);
                Hud.OpenDialog(DialogData.Create(new List<(string speakingRole, string text)>() { ("", "你已完成游戏内容") }));
                yield return null;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
            }
        }

        public IItemSystem ItemSystem
        {
            get => itemSystem;
            private set => itemSystem = value;
        }
    }
}