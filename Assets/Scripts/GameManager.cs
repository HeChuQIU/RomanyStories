using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class GameManager : MonoBehaviour,ISingleton<GameManager>
	{
		public static GameManager Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
			itemSystem = Scripts.ItemSystem.Instance;
		}

		[SerializeField]
		private IItemSystem itemSystem;
		public IItemSystem ItemSystem { get => itemSystem; private set => itemSystem = value; }
	}
}