using Assets.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Player : MonoBehaviour
	{
		[SerializeField]
		private FsmState<Player> currentState;
		[SerializeField]
		private Dictionary<StateType, FsmState<Player>> fsmStates = new();
		[SerializeField]
		private new Rigidbody2D rigidbody;
		[SerializeField]
		private float speed;
		[SerializeField]
		private string stateName;

		public FsmState<Player> CurrentState
		{
			get => currentState;
			private set
			{
				currentState?.OnExit();
				value?.OnEnter();
				currentState = value;
				stateName = currentState.GetType().Name;
			}
		}

		private void Start()
		{
			fsmStates.Add(StateType.Idle, new IdleState(this));
			fsmStates.Add(StateType.Attack, new AttackState(this));
			fsmStates.Add(StateType.GetHit, new GetHitState(this));
			fsmStates.Add(StateType.Walk, new WalkState(this));
			fsmStates.Add(StateType.Die, new DieState(this));

			CurrentState = fsmStates[StateType.Idle];

			rigidbody = GetComponent<Rigidbody2D>();
		}

		private void FixedUpdate()
		{
			currentState?.OnFixedUpdate();
		}

		public enum StateType
		{
			Idle,
			Attack,
			GetHit,
			Walk,
			Die
		}

		[Serializable]
		public class IdleState : FsmState<Player>
		{
			public IdleState(Player fsm)
			{ 
				Fsm = fsm; 
			}

			public override Player Fsm { get; protected set; }

			public override void OnEnter()
			{
				
			}

			public override void OnExit()
			{
				
			}

			public override void OnFixedUpdate()
			{
				Vector2 move = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
				if (move.sqrMagnitude != 0)
					Fsm.currentState = Fsm.fsmStates[StateType.Walk];
			}
		}

		public class AttackState : FsmState<Player>
		{
			public AttackState(Player fsm)
			{
				Fsm = fsm;
			}

			public override Player Fsm { get; protected set; }
			public override void OnEnter()
			{
				
			}

			public override void OnExit()
			{

			}

			public override void OnFixedUpdate()
			{
				
			}
		}

		public class GetHitState : FsmState<Player>
		{
			public GetHitState(Player fsm)
			{
				Fsm = fsm;
			}
			
			public override Player Fsm { get; protected set; }
			public override void OnEnter()
			{
				
			}

			public override void OnExit()
			{
				
			}

			public override void OnFixedUpdate()
			{
				
			}
		}

		[Serializable]
		public class WalkState: FsmState<Player>
		{
			public WalkState(Player fsm)
			{
				Fsm = fsm;
			}

			public override Player Fsm { get; protected set; }

			public override void OnEnter()
			{
				
			}

			public override void OnExit()
			{
				
			}

			public override void OnFixedUpdate()
			{
				Vector2 move = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
				if (move.sqrMagnitude == 0) 
					Fsm.currentState = Fsm.fsmStates[StateType.Idle];
				Fsm.rigidbody.velocity = move * Fsm.speed;
			}
		}

		public class DieState : FsmState<Player>
		{
			public DieState(Player fsm)
			{
				Fsm = fsm;
			}

			public override Player Fsm { get; protected set; }

			public override void OnEnter()
			{
				
			}

			public override void OnExit()
			{
				
			}

			public override void OnFixedUpdate()
			{
				
			}
		}
	}
}