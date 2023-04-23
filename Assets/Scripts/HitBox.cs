using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class HitBox : MonoBehaviour
    {
        [SerializeField] private Entity entity;
        [SerializeField] private new Collider2D collider;
        [SerializeField] private bool isWall;

        public Entity Entity
        {
            get => entity;
            protected set => entity = value;
        }

        public Collider2D Collider
        {
            get => collider;
            protected set => collider = value;
        }

        public bool IsWall
        {
            get => isWall;
            set => isWall = value;
        }

        public Action<HitBox, HitBox> OnBeHit { get; set; }

        private void Awake()
        {
            CheckRequire();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var otherHitBox = collision.GetComponent<HitBox>();
            OnBeHit?.Invoke(this, otherHitBox);
        }

        private void CheckRequire()
        {
            if (!IsWall)
            {
                if (entity == null)
                    entity = GetComponentInParent<Entity>();
                if (entity == null)
                {
                    throw new Exception("HitBox needs Entity on parent gameObject");
                }
            }

            if (collider == null && !TryGetComponent(out collider))
            {
                throw new Exception("HitBox needs Collider2D on gameObject");
            }
        }
    }
}