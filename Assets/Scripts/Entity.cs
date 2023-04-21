using System;
using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Logger = Assets.Classes.Logger;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] private EntityData entityData;
        [SerializeField] private HitBox hitBox;
        [FormerlySerializedAs("moveVector")] [SerializeField] protected Vector2 moveVelocity;

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

            if (Rigidbody==null)
                Rigidbody=GetComponent<Rigidbody2D>();
            if (Rigidbody==null)
            {
                gameObject.AddComponent<Rigidbody2D>();
            }
        }

        protected abstract void OnBeHit(HitBox hitBox, HitBox otherHitBox);

        protected virtual void Awake()
        {
            CheckRequire();
            hitBox.OnBeHit += OnBeHit;
        }

        protected virtual void Update()
        {
            Rigidbody.velocity = moveVelocity;
        }
    }
}