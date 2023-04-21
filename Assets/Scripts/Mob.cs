using UnityEngine;

public abstract class Mob : Entity
{
    protected virtual void TakeDamage(float damage)
    {
        int damageInt = (int)damage + Random.Range(0f, 1f) > damage - (int)damage ? 1 : 0;
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
}