using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class BulletWise1 : BulletB
    {
        public BulletB bulletPrefab;

        protected override IEnumerator Action()
        {
            StartCoroutine(base.Action());
            while (true)
            {
                if (((Vector2)transform.position - targetPosition).magnitude <= 1.0f)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        var angle = Random.Range(0f, Mathf.PI * 2f);
                        BulletB bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                        bullet.targetPosition = (Vector2)transform.position +
                                                new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * 2f;
                        bullet.EntityData.Speed = Random.Range(0.5f, 1.5f);
                    }

                    Destroy(gameObject);
                }

                yield return null;
            }
        }
    }
}