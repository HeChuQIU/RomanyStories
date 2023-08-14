using System;
using System.Collections;
using Assets.Classes;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] private EntityData entityData;
        [SerializeField] private HitBox hitBox;
        [SerializeField] protected Vector2 moveVelocity;
        [SerializeField] protected SpriteRenderer spriteRenderer;

        public virtual EntityData EntityData
        {
            get => entityData;
            private set => entityData = value;
        }

        public Rigidbody2D Rigidbody { get; set; }

        protected virtual void CheckRequire()
        {
            if (hitBox == null)
                hitBox = GetComponentInChildren<HitBox>();
            if (hitBox == null)
            {
                Type[] componentTypes = { typeof(HitBox), typeof(BoxCollider2D) };
                GameObject hitBoxGameObject = new GameObject("HitBox", componentTypes);
                hitBoxGameObject.transform.SetParent(transform);
            }

            if (Rigidbody == null)
                Rigidbody = GetComponent<Rigidbody2D>();
            if (Rigidbody == null)
            {
                gameObject.AddComponent<Rigidbody2D>();
            }
        }

        protected abstract void OnBeHit(HitBox hitBox, HitBox otherHitBox);

        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            CheckRequire();
            hitBox.OnBeHit += OnBeHit;
        }

        protected virtual void Update()
        {
            Rigidbody.velocity = moveVelocity;
        }

        protected virtual void Start()
        {
            StartCoroutine((IEnumerator)Action());
        }

        protected abstract IEnumerator Action();
    }
}