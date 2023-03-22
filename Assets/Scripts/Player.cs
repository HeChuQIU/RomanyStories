using Assets.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Player : Fsm
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

		private void Awake()
		{
			FsmState idleState = new();
			idleState.Name = nameof(StateType.Idle);
			idleState.OnFixedUpdate += () =>
			{
				Vector2 move = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
				move *= speed;
				if (move.sqrMagnitude != 0)
					CurrentState = fsmStates[StateType.Walk];
			};
			fsmStates.Add(StateType.Idle, idleState);

			fsmStates.Add(StateType.Attack, new FsmState());

			fsmStates.Add(StateType.GetHit, new FsmState());

			FsmState walkState = new();
			walkState.Name = nameof(StateType.Walk);
			walkState.OnFixedUpdate += () =>
			{
				Vector2 move = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
				move *= speed;
				if (move.sqrMagnitude == 0)
					CurrentState = fsmStates[StateType.Idle];
				rigidbody.velocity = move;
			};
			fsmStates.Add(StateType.Walk, walkState);

			fsmStates.Add(StateType.Die, new FsmState());

			rigidbody = GetComponent<Rigidbody2D>();
		}

		private void Start()
		{
			CurrentState = fsmStates[StateType.Idle];
		}

/*		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}*/

		public enum StateType
		{
			Idle,
			Attack,
			GetHit,
			Walk,
			Die
		}
	}
}