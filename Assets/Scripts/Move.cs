using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public Vector2 move;
	[SerializeField]
	private new Rigidbody2D rigidbody;
	[SerializeField]
	private float speed = 1f;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		rigidbody.velocity = Time.fixedDeltaTime * speed * move;
	}
}
