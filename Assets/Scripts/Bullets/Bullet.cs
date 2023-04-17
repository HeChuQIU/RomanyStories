using System;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class Bullet : Entity
    {
        protected override void OnBeHit(HitBox hitBox)
        {
            Destroy(hitBox.gameObject);
        }
    }
}