using Assets.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Player;

namespace Assets.Scripts
{
	public abstract class Fsm : MonoBehaviour
	{
		[SerializeField]
		protected IFsmState currentState;
		[SerializeField]
		protected Dictionary<StateType, FsmState> fsmStates = new();

		public virtual IFsmState CurrentState { get => currentState; 
			protected set 
			{
				currentState?.OnExit?.Invoke();
				currentState = value;
				currentState?.OnEnter?.Invoke();
			}
		}

		protected virtual void FixedUpdate()
		{
			currentState?.OnFixedUpdate?.Invoke();
		}
	}
}