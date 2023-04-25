using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Classes;
using UnityEngine;

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
                            direction = (targetPosition - (Vector2)transform.position).normalized;
                            nextIdleTime = Time.time + EntityData.IdleTime;
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
    }
}