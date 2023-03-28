using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Move : MonoBehaviour
{
	public Vector2 move;

	[SerializeField]
	private new Rigidbody2D rigidbody;
	public Rigidbody2D Rigidbody { get => rigidbody; set => rigidbody = value; }

	[SerializeField]
	private Player entity;
	public Player Entity { get => entity; set => entity = value; }

	private void Awake()
	{
		Rigidbody = GetComponent<Rigidbody2D>();
		Entity = GetComponent<Player>();
	}

	private void FixedUpdate()
	{
		Rigidbody.velocity = Time.fixedDeltaTime * Entity.EntityData.Speed * move;
	}
}
