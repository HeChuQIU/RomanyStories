using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class BulletB : Bullet
    {
        public Vector2 targetPosition;

        protected override IEnumerator Action()
        {
            moveVelocity = (targetPosition - (Vector2)transform.position).normalized * EntityData.Speed;
            yield return new WaitForSeconds(30f);
            Destroy(gameObject);
        }
    }
}