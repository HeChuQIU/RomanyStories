using System;
using System.Collections;
using System.Linq;
using Assets.Scripts.Bullets;
using UnityEngine;
using Logger = Assets.Classes.Logger;

namespace Assets.Scripts
{
    public class Slime : Mob
    {
        private enum State
        {
            Idle,
            Move
        }

        [SerializeField] private State state;
        [SerializeField] private float moveTime;
        [SerializeField] private Animator animator;
        [SerializeField] private BulletB bulletPrefab;

        protected override IEnumerator Action()
        {
            var direction = Vector2.right;
            float nextMoveTime = 0f;
            float nextIdleTime = 0f;
            while (true)
            {
                switch (state)
                {
                    case State.Idle:
                        moveVelocity = Vector2.zero;
                        if (Time.time > nextMoveTime && Targets.Count > 0)
                        {
                            Vector2 targetPosition = (from target in Targets
                                orderby (target.transform.position - transform.position).magnitude
                                select target.transform.position).First();
                            var position = transform.position;
                            direction = (targetPosition - (Vector2)position).normalized;
                            nextIdleTime = Time.time + EntityData.IdleTime;
                            BulletB bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
                            bullet.targetPosition = targetPosition;
                            state = State.Move;
                        }

                        break;
                    case State.Move:
                        if (Time.time > nextIdleTime)
                        {
                            state = State.Idle;
                            nextMoveTime = Time.time + moveTime;
                            break;
                        }

                        moveVelocity = direction * EntityData.Speed;
                        break;
                }

                yield return new WaitForFixedUpdate();
            }
        }

        protected override void Awake()
        {
            base.Awake();
            if (animator == null)
                animator = GetComponent<Animator>();
            if (animator == null)
                Logger.Log("Animator is null");
        }

        protected override void Update()
        {
            base.Update();
            if (animator.enabled)
                SetAnimation();

            void SetAnimation()
            {
                Vector2[] directions = { new Vector2(1, 1), new Vector2(1, -1) };
                if (moveVelocity.magnitude < 0.1f)
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

        protected override void Death()
        {
            string animationName;

            if (EntityData.Dying)
                return;
            Logger.Log($"{name} Death");
            Logger.Log($"moveVelocity:{moveVelocity}");
            EntityData.Dying = true;
            if (animator != null)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Left")||animator.GetCurrentAnimatorStateInfo(0).IsName("Left Idle"))
                    animationName = "Left Death";
                else
                    animationName = "Right Death";
                StartCoroutine(DelayDeath());
            }
            else
                Destroy(gameObject);

            IEnumerator DelayDeath()
            {
                Logger.Log(animationName);
                animator.Play(animationName);
                yield return null;
                while (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
                {
                    yield return null;
                }

                Destroy(gameObject);
            }
        }
    }
}