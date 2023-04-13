using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour/* : Entity*/
{
	[SerializeField]
	private EntityData entityData;
	public EntityData EntityData { get => entityData; set => entityData = value; }

	[SerializeField]
	private SpriteRenderer spriteRenderer;
	[SerializeField]
	private new Rigidbody2D rigidbody;

	private void Awake()
	{
		if (spriteRenderer == null)
			spriteRenderer = GetComponent<SpriteRenderer>();

		if (rigidbody == null)
			rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (Vector2.Dot(Vector2.right, rigidbody.velocity) < 0)
			spriteRenderer.flipX = false;
		else if (Vector2.Dot(Vector2.right, rigidbody.velocity) > 0)
			spriteRenderer.flipX = true;
	}
}
