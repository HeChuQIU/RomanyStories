using System;
using System.Collections.Generic;
using UnityEngine;

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
        float Damage { get; set; }
        EntityCamp Camp { get; set; }
        string this[string propertyName] { get; set; }
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
            set => currentHitPoint = value;
        }

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

        public float Damage
        {
            get => attackDamage;
            set => attackDamage = value;
        }

        public EntityCamp Camp
        {
            get => camp;
            set => camp = value;
        }

        [SerializeField] private int maxHitPoint;
        [SerializeField] private int currentHitPoint;
        [SerializeField] private int maxStrength;
        [SerializeField] private int strength;
        [SerializeField] private int maxArmor;
        [SerializeField] private int currentExtraHealth;
        [SerializeField] private float speed;
        [SerializeField] private float attackDamage;
        [SerializeField] private EntityCamp camp;
        private Dictionary<string, string> properties = new();

        public string this[string propertyName]
        {
            get => properties.ContainsKey(propertyName) ? properties[propertyName] : string.Empty;
            set => properties[propertyName] = value;
        }
    }

    public enum EntityCamp
    {
        Friendly,
        Enemy
    }
}