using UnityEngine;
using System;

namespace Assets.Scripts
{
	[RequireComponent(typeof(Collider2D))]
	public class Item : MonoBehaviour
	{
		[SerializeField]
		private new Collider2D collider2D;
		[SerializeField]
		private ItemStack itemStack;
		public ItemStack ItemData { get => itemStack; private set => itemStack = value; }

		private void Awake()
		{
			if (collider2D == null) 
				collider2D = GetComponent<Collider2D>();
			if (collider2D == null)
				throw new NullReferenceException();
				
				collider2D.isTrigger = true;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			
		}
	}
}