using System;
using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Bullets;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : Mob
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private new Rigidbody2D rigidbody;

    private Vector2 moveVector = Vector2.zero;

    protected override void Awake()
    {
        base.Awake();
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void OnBeHit(HitBox hitBox, HitBox otherHitBox)
    {
        Debug.Log($"{otherHitBox.Entity.gameObject.name} hit {HitBox.Entity.gameObject.name}");
        var bullet = otherHitBox.Entity as Bullet;
        if (bullet != null)
        {
            TakeDamage(bullet.EntityData.Damage);
        }
    }

    private void Update()
    {
        if (Vector2.Dot(Vector2.right, moveVector) < 0)
            spriteRenderer.flipX = false;
        else if (Vector2.Dot(Vector2.right, moveVector) > 0)
            spriteRenderer.flipX = true;
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        Move.moveVector = EntityData.Speed * moveVector;
    }

    private void FixedUpdate()
    {
    }
}