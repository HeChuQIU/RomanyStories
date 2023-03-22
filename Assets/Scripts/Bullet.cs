using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets.Classes;

namespace Assets.Scripts
{
	public class Bullet : Fsm
	{
		[SerializeField]
		private new Rigidbody2D rigidbody;
		[SerializeField]
		private new Collider2D collider;
		[SerializeField]
		private float speed;
		[SerializeField]
		private string stateName;

		public override IFsmState CurrentState
		{
			get => currentState;
			protected set
			{
				base.CurrentState = value;
				stateName = value.Name;
			}
		}

		
	}
}