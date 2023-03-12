using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Classes
{
	public interface IEntityData
	{
		public float Health { get; set; }
		public float MaxHealth { get; set; }
		public float ExtraHealth { get; set; }
		public float Damage { get; set; }
		public float Speed { get; set; }
		public float AttackSpeed { get; set; }
		public float Armor { get; set; }
		public float Immune { get; set; }
		public EntityType Type { get; set; }
	}

	public enum EntityType
	{
		Mob,
		Player,
		Projectile
	}


	public class EntityData : IEntityData
	{
		public float Health { get; set; }
		public float MaxHealth { get; set; }
		public float ExtraHealth { get; set; }
		public float Damage { get; set; }
		public float Speed { get; set; }
		public float AttackSpeed { get; set; }
		public float Armor { get; set; }
		public float Immune { get; set; }
		public EntityType Type { get; set; }
	}
}
