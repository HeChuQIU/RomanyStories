using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public interface IEntity
	{
		public string Name { get; set; }
		public IEnumerable<IAbility> Abilities { get; }
	}
}