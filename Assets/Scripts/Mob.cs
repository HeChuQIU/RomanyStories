using Assets.Scripts.Bullets;
using UnityEngine;
using Logger = Assets.Classes.Logger;

namespace Assets.Scripts
{
    public abstract class Mob : Entity
    {
        protected virtual void TakeDamage(float damage)
        {
            int damageInt = (int)damage + Random.Range(0f, 1f) > damage - Mathf.FloorToInt(damage) ? 0 : 1;
            TakeDamage(damageInt);
        }

        protected virtual void TakeDamage(int damage)
        {
            if (damage <= EntityData.CurrentExtraHealth)
            {
                EntityData.CurrentExtraHealth -= damage;
            }
            else
            {
                damage -= EntityData.CurrentExtraHealth;
                EntityData.CurrentExtraHealth = 0;
                EntityData.CurrentHitPoint -= damage;
            }
        }

        protected override void OnBeHit(HitBox hitBox, HitBox otherHitBox)
        {
            if (otherHitBox == null)
                return;
            var bullet = otherHitBox.Entity as Bullet;
            if (bullet != null && bullet.EntityData.Camp != EntityData.Camp)
            {
                Logger.Log($"{otherHitBox.Entity.gameObject.name} hit {hitBox.Entity.gameObject.name}");
                TakeDamage(bullet.EntityData.Damage);
            }
        }
    }
}