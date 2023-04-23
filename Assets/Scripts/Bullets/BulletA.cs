using System.Collections;
using Assets.Classes.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Bullets
{
    public class BulletA : Bullet
    {
        [SerializeField] private Vector2 moveDirection;

        protected void FixedUpdate()
        {
            moveVelocity = EntityData.Speed * moveDirection;
        }

        protected override IEnumerator Action()
        {
            var gap = 2f;
            while (true)
            {
                moveVelocity = Vector2Extension.Rotate(moveVelocity, Random.Range(0f,360f));
                if (gap > 0.1f)
                {
                    EntityData.Speed *= 1.1f;
                    gap /= 1.1f;
                }
                yield return new WaitForSeconds(gap);
            }
        }
    }
}