using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class EventManager : MonoBehaviour
	{
		public event Action OnGameStart;
		public void GameStart() => OnGameStart?.Invoke();



	}
}