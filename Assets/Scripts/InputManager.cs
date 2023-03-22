using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class InputManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject player;

		public GameObject Player { get => player; set => player = value; }

	}
}