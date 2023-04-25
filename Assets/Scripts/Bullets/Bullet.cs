using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public abstract class Bullet : Entity
    {
        private Vector2 lastPosition;

        protected override void Update()
        {
            base.Update();
            RotateToDirection();
        }

        protected virtual void RotateToDirection()
        {
            var position = transform.position;
            var direction = (Vector2)position - lastPosition;
            if (direction == Vector2.zero)
                return;
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, direction));
            lastPosition = position;
        }

        protected override void OnBeHit(HitBox hitBox, HitBox otherHitBox)
        {
            if (otherHitBox == null)
                return;
            if (!otherHitBox.IsWall && otherHitBox.Entity.EntityData.Camp == EntityData.Camp)
                return;
            Destroy(hitBox.Entity.gameObject);
        }
    }
}