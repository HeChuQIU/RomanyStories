using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Bullets;
using UnityEngine;
using Logger = Assets.Classes.Logger;

namespace Assets.Scripts
{
    public abstract class Mob : Entity
    {
        [SerializeField] private List<Mob> targets;

        protected virtual void TakeDamage(float damage)
        {
            int damageInt = (int)damage + (Random.Range(0f, 1f) > damage - Mathf.FloorToInt(damage) ? 0 : 1);
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
                StartCoroutine(HitPointLossRenderEffect());
            }

            if (EntityData.CurrentHitPoint <= 0)
                Death();
        }

        protected virtual IEnumerator HitPointLossRenderEffect()
        {
            if (spriteRenderer == null)
                yield break;
            spriteRenderer.color = new Color(1f, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
        }

        protected virtual void Death()
        {
            if (!EntityData.Dying)
                Destroy(gameObject);
            EntityData.Dying = true;
        }

        protected override void OnBeHit(HitBox hitBox, HitBox otherHitBox)
        {
            if (otherHitBox == null)
                return;
            var bullet = otherHitBox.Entity as Bullet;
            if (bullet != null && bullet.EntityData.Camp != EntityData.Camp)
            {
                // Logger.Log($"{otherHitBox.Entity.gameObject.name} hit {hitBox.Entity.gameObject.name}");
                TakeDamage(bullet.EntityData.Damage);
            }
        }

        public List<Mob> Targets
        {
            get => targets;
            set => targets = value;
        }
    }
}