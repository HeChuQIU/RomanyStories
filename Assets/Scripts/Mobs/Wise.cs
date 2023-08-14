using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Bullets;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Mobs
{
    public class Wise : Mob
    {
        public enum State
        {
            Waiting,
            Spell1,
            Spell2
        }

        public State state;
        [SerializeField] private BulletB bulletPrefab1;
        [SerializeField] private BulletB bulletPrefab2;
        [SerializeField] private BulletWise1 bulletPrefab3;
        [SerializeField] private HitBox bulletClear;

        protected override IEnumerator Action()
        {
            while (true)
            {
                switch (state)
                {
                    case State.Spell1:
                        for (int i = 0; i < 8; i++)
                        {
                            float angle1 = i * Mathf.PI / 4f;
                            for (int j = 0; j < 8; j++)
                            {
                                float angle2 = j * Mathf.PI / 4f;
                                var bullet1 = Instantiate(bulletPrefab1, transform.position, Quaternion.identity);
                                bullet1.transform.position += new Vector3(Mathf.Cos(j), Mathf.Sin(j)) * 1f;
                                bullet1.targetPosition = (Vector2)transform.position +
                                                         new Vector2(Mathf.Cos(angle1), Mathf.Sin(angle1)) * 2f;
                                yield return new WaitForSeconds(0.005f);
                            }
                        }

                        var bullet2 = Instantiate(bulletPrefab2, transform.position, Quaternion.identity);
                        bullet2.targetPosition = GameManager.Instance.Player.transform.position;
                        break;
                    case State.Spell2:
                        for (int i = 0; i < 8; i++)
                        {
                            var angle = i * Mathf.PI / 4 + Random.Range(-Mathf.PI / 8f, Mathf.PI / 8f);
                            var bullet3 = Instantiate(bulletPrefab3, transform.position, Quaternion.identity);
                            bullet3.targetPosition =
                                (Vector2)transform.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * 6f;
                            bullet3.bulletPrefab = bulletPrefab1;
                        }

                        var bullet4 = Instantiate(bulletPrefab3, transform.position, Quaternion.identity);
                        bullet4.targetPosition = GameManager.Instance.Player.transform.position;
                        bullet4.bulletPrefab = bulletPrefab1;

                        yield return new WaitForSeconds(4.0f);
                        break;
                }

                yield return null;
            }
        }

        protected override void Death()
        {
            switch (state)
            {
                case State.Waiting:
                    state = State.Spell1;
                    EntityData.CurrentHitPoint = 250;
                    break;
                case State.Spell1:
                    state = State.Spell2;
                    EntityData.CurrentHitPoint = 250;
                    break;
                case State.Spell2:
                    GameManager.Instance.GameOver();
                    base.Death();
                    break;
            }
        }



        private IEnumerator ClearBullet()
        {
            var bulletClearCollider =
                Instantiate(this.bulletClear, transform.position, Quaternion.identity).Collider as CircleCollider2D;
            if (bulletClearCollider == null)
            {
                yield break;
            }

            while (bulletClearCollider.radius < 10.0f)
            {
                bulletClearCollider.radius += 0.5f;
                yield return null;
            }

            Destroy(bulletClearCollider.gameObject);
        }
    }
}