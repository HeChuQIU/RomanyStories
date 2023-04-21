using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
<<<<<<< HEAD
using Random = UnityEngine.Random;

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
        float Speed { get; set; }
        float AttackDamage { get; set; }
        string this[string propertyName] { get; set; }

        event Action<IEntityData> OnHitPointChange;

        void TakeDamage(float damage);
    }

    [Serializable]
    public class EntityData : IEntityData
    {
        public int MaxHitPoint
        {
            get => maxHitPoint;
            set => maxHitPoint = value;
        }

        public int CurrentHitPoint
        {
            get => currentHitPoint;
            set
            {
                OnHitPointChange?.Invoke(this);
                currentHitPoint = value;
            }
        }
=======

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
>>>>>>> 46d45598a2801beba1af11db7b97f6dfaeabd75e

        public int MaxStrength
        {
            get => maxStrength;
            set => maxStrength = value;
        }

        public int Strength
        {
            get => strength;
            set => strength = value;
        }

        public int MaxArmor
        {
            get => maxArmor;
            set => maxArmor = value;
        }

        public int CurrentExtraHealth
        {
            get => currentExtraHealth;
            set => currentExtraHealth = value;
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public float AttackDamage
        {
            get => attackDamage;
            set => attackDamage = value;
        }

        [SerializeField] private int maxHitPoint;
        [SerializeField] private int currentHitPoint;
        [SerializeField] private int maxStrength;
        [SerializeField] private int strength;
        [SerializeField] private int maxArmor;
        [SerializeField] private int currentExtraHealth;
        [SerializeField] private float speed;
        [SerializeField] private float attackDamage;

        [SerializeField] private Dictionary<string, string> properties = new();

        public string this[string propertyName]
        {
            get => properties.ContainsKey(propertyName) ? properties[propertyName] : string.Empty;
            set => properties[propertyName] = value;
        }

        public event Action<IEntityData> OnHitPointChange;

        public void TakeDamage(float damage)
        {
            int damageInt = (int)damage + Random.Range(0f, 1f) > damage - (int)damage ? 1 : 0;
            if (damageInt <= CurrentExtraHealth)
            {
                CurrentExtraHealth -= damageInt;
            }
            else
            {
                damageInt -= CurrentExtraHealth;
                CurrentExtraHealth = 0;
                CurrentHitPoint -= damageInt;
            }
        }
    }
}