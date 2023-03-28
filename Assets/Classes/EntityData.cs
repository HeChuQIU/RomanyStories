using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Classes
{
	public interface IEntityData
	{
		int MaxHealth { get; set; }
		int CurrentHealth { get; set; }
		int MaxStrength { get; set; }
		int Strength { get; set; }
		int MaxArmor { get; set; }
		int CurrentExtraHealth { get; set; }
		float Speed { get;set; }
		string this[string propertyName] { get; set; }
	}

	[Serializable]
	public struct EntityData : IEntityData
	{
		public EntityData(int maxHealth, int currentHealth, int maxStrength, int strength, int maxArmor, int currentExtraHealth, float speed, Dictionary<string, string> properties = null)
		{
			this.maxHealth = maxHealth;
			this.currentHealth = currentHealth;
			this.maxStrength = maxStrength;
			this.strength = strength;
			this.maxArmor = maxArmor;
			this.currentExtraHealth = currentExtraHealth;
			this.speed = speed;
			this.properties = properties ?? new();
		}

		public static EntityData Default => new(0, 0, 0, 0, 0, 0, 0.0f);

		public int MaxHealth { get => maxHealth; set => maxHealth = value; }
		public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
		public int MaxStrength { get => maxStrength; set => maxStrength = value; }
		public int Strength { get => strength; set => strength = value; }
		public int MaxArmor { get => maxArmor; set => maxArmor = value; }
		public int CurrentExtraHealth { get => currentExtraHealth; set => currentExtraHealth = value; }
		public float Speed { get => speed; set => speed = value; }

		[SerializeField]
		private int maxHealth;
		[SerializeField]
		private int currentHealth;
		[SerializeField]
		private int maxStrength;
		[SerializeField]
		private int strength;
		[SerializeField]
		private int maxArmor;
		[SerializeField]
		private int currentExtraHealth;
		[SerializeField]
		private float speed;
		[SerializeField]
		private Dictionary<string, string> properties;

		public string this[string propertyName]
		{
			get => properties.ContainsKey(propertyName) ? properties[propertyName] : string.Empty;
			set
			{
				if (properties.ContainsKey(propertyName))
					properties[propertyName] = value;
				else
					properties.Add(propertyName, value);
			}
		}
	}
}
