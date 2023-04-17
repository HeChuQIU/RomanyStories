using System;
using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour, ISingleton<GameManager>
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private GameObject bullet;
        [SerializeField] private IItemSystem itemSystem;
        [SerializeField] private List<GameObject> enemies;
        [SerializeField] private GameObject player;

        public List<GameObject> Enemies
        {
            get => enemies;
            set => enemies = value;
        }

        public GameObject Player
        {
            get => player;
            set => player = value;
        }

        private void Awake()
        {
            Instance = this;
            itemSystem = Scripts.ItemSystem.Instance;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.E))
                Instantiate(bullet, new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0), Quaternion.identity);
        }

        public IItemSystem ItemSystem
        {
            get => itemSystem;
            private set => itemSystem = value;
        }
    }
}