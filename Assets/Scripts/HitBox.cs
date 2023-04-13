using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitBox : MonoBehaviour
{
	[SerializeField]
	private Entity entity;
	[SerializeField]
	private new Collider2D collider;

	public Entity Entity { get => entity; protected set => entity = value; }
	public Collider2D Collider { get => collider; protected set => collider = value; }

	public void OnBeHit()
	{

	}

	private void Awake()
	{
		CheckRequire();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collider.TryGetComponent(out HitBox hitBox))
			return;

		hitBox.OnBeHit();
	}

	private void CheckRequire()
	{
		if (entity == null)
			entity = GetComponentInParent<Entity>();
		if (entity == null)
			Destroy(this);

		if (collider == null && !TryGetComponent(out collider))
			Destroy(this);
	}
}
