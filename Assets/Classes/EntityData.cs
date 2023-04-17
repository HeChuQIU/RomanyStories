using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Classes
{
	public interface IEntityData
	{
		int MaxHitPoint { get; set; }
		int CurrentHitPoint { get; set; }
		int MaxStrength { get; set; }
		int Strength { get; set; }
		int MaxArmor { get; set; }
		int CurrentExtraHealth { get; set; }
		float Speed { get;set; }
		string this[string propertyName] { get; set; }
	}

	[Serializable]
	public class EntityData : IEntityData
	{
		public int MaxHitPoint { get => maxHitPoint; set => maxHitPoint = value; }
		public int CurrentHitPoint { get => currentHitPoint; set => currentHitPoint = value; }
		public int MaxStrength { get => maxStrength; set => maxStrength = value; }
		public int Strength { get => strength; set => strength = value; }
		public int MaxArmor { get => maxArmor; set => maxArmor = value; }
		public int CurrentExtraHealth { get => currentExtraHealth; set => currentExtraHealth = value; }
		public float Speed { get => speed; set => speed = value; }

		[SerializeField]
		private int maxHitPoint;
		[SerializeField]
		private int currentHitPoint;
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
