using System;
using System.Collections.Generic;
using Assets.Classes;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

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
        [SerializeField] private UIDocument hudUI;

        private VisualElement HudRoot => hudUI.rootVisualElement;

        public static GameManager Instance { get; private set; }

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
        }

        private void Start()
        {
            HudRoot.Add(new Hud(player.EntityData));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(mobPrefab, GetMousePosition(), Quaternion.identity);
            }
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
                var position = player.transform.position;
                position.z = mainCamera.transform.position.z;
                mainCamera.transform.position = position;
            }
        }

        public IItemSystem ItemSystem
        {
            get => itemSystem;
            private set => itemSystem = value;
        }
    }
}