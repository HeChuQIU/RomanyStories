using System.Collections;
using Assets.Scripts.Bullets;
using UnityEngine;

public class BulletPlayer : Bullet
{
    public Vector2 targetPosition;

    protected override IEnumerator Action()
    {
        moveVelocity = (targetPosition - (Vector2)transform.position).normalized * EntityData.Speed;
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}