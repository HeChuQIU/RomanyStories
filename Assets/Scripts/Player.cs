using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : Mob
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private new Rigidbody2D rigidbody;
        [SerializeField] private BulletPlayer bulletPrefab;
        [SerializeField] private Animator animator;
        [SerializeField] private float attackColdDown;

        protected override void Awake()
        {
            base.Awake();
            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();

            if (rigidbody == null)
                rigidbody = GetComponent<Rigidbody2D>();

            if (animator == null)
                animator = GetComponent<Animator>();
        }

        protected override IEnumerator Action()
        {
            yield return null;
        }

        private float nextAttackTime;
        protected override void Update()
        {
            base.Update();
            if (Input.GetAxis("Fire1") > 0)
            {
                if (Time.time>nextAttackTime)
                {
                    Attack();
                }
            }

            SetAnimation();
            moveVelocity.x = Input.GetAxis("Horizontal");
            moveVelocity.y = Input.GetAxis("Vertical");
            moveVelocity = EntityData.Speed * moveVelocity;
            
            void Attack()
            {
                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.targetPosition = GameManager.Instance.GetMousePosition();
                nextAttackTime = Time.time + attackColdDown;
            }

            void SetAnimation()
            {
                Vector2[] directions = { new Vector2(1, 1), new Vector2(1, -1) };
                if (moveVelocity.magnitude < 0.01f)
                {
                    Func<string, bool> animatorStateIsName = animator.GetCurrentAnimatorStateInfo(0).IsName;
                    if (animatorStateIsName("Left"))
                    {
                        animator.Play("Left Idle");
                    }
                    else if (animatorStateIsName("Right"))
                    {
                        animator.Play("Right Idle");
                    }
                    else if (animatorStateIsName("Up"))
                    {
                        animator.Play("Up Idle");
                    }
                    else if (animatorStateIsName("Down"))
                    {
                        animator.Play("Down Idle");
                    }

                    return;
                }

                if (Vector2.Dot(moveVelocity, directions[0]) > 0)
                {
                    animator.Play(Vector2.Dot(moveVelocity, directions[1]) > 0 ? "Right" : "Up");
                }
                else
                {
                    animator.Play(Vector2.Dot(moveVelocity, directions[1]) > 0 ? "Down" : "Left");
                }
            }
        }
    }
}