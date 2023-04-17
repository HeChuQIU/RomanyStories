using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Classes.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Bullets
{
    [RequireComponent(typeof(Move))]
    public class BulletA : Bullet
    {
        [SerializeField] private Vector2 moveVector;

        private void Start()
        {
            StartCoroutine(Action());
        }

        private void FixedUpdate()
        {
            Move.moveVector = EntityData.Speed * moveVector;
        }

        private IEnumerator Action()
        {
            var gap = 2f;
            while (true)
            {
                moveVector = moveVector.Rotate(Random.Range(0f,360f));
                if (gap <= 0.1f)
                {
                    continue;
                }

                EntityData.Speed *= 1.1f;
                gap /= 1.1f;
                
                yield return new WaitForSeconds(gap);
            }
        }
    }
}