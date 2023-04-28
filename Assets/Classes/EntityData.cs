using System;
using System.Collections.Generic;
using System.Reflection;
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
            set
            {
                OnEntityDataChanged?.Invoke(this,
                    new EntityDataChangedEventArgs(nameof(MaxHitPoint), maxHitPoint, value));
                maxHitPoint = value;
            }
        }

        public int CurrentHitPoint
        {
            get => currentHitPoint;
            set
            {
                OnEntityDataChanged?.Invoke(this,
                    new EntityDataChangedEventArgs(nameof(CurrentHitPoint), currentHitPoint, value));
                currentHitPoint = value;
            }
        }

        public int MaxStrength
        {
            get => maxStrength;
            set
            {
                OnEntityDataChanged?.Invoke(this,
                    new EntityDataChangedEventArgs(nameof(MaxStrength), maxStrength, value));
                maxStrength = value;
            }
        }

        public int Strength
        {
            get => strength;
            set
            {
                OnEntityDataChanged?.Invoke(this,
                    new EntityDataChangedEventArgs(nameof(Strength), strength, value));
                strength = value;
            }
        }

        public int MaxArmor
        {
            get => maxArmor;
            set
            {
                OnEntityDataChanged?.Invoke(this,
                    new EntityDataChangedEventArgs(nameof(MaxArmor), maxArmor, value));
                maxArmor = value;
            }
        }

        public int CurrentExtraHealth
        {
            get => currentExtraHealth;
            set
            {
                OnEntityDataChanged?.Invoke(this,
                    new EntityDataChangedEventArgs(nameof(CurrentExtraHealth), currentExtraHealth, value));
                currentExtraHealth = value;
            }
        }

        public float Speed
        {
            get => speed;
            set
            {
                OnEntityDataChanged?.Invoke(this,
                    new EntityDataChangedEventArgs(nameof(Speed), speed, value));
                speed = value;
            }
        }

        public float Damage
        {
            get => damage;
            set
            {
                OnEntityDataChanged?.Invoke(this,
                    new EntityDataChangedEventArgs(nameof(Damage), damage, value));
                damage = value;
            }
        }

        public EntityCamp Camp
        {
            get => camp;
            set
            {
                OnEntityDataChanged?.Invoke(this,
                    new EntityDataChangedEventArgs(nameof(Camp), camp, value));
                camp = value;
            }
        }

        public float IdleTime
        {
            get => idleTime;
            set
            {
                OnEntityDataChanged?.Invoke(this,
                    new EntityDataChangedEventArgs(nameof(IdleTime), idleTime, value));
                idleTime = value;
            }
        }

        public event EventHandler<EntityDataChangedEventArgs> OnEntityDataChanged;

        [SerializeField] private int maxHitPoint;
        [SerializeField] private int currentHitPoint;
        [SerializeField] private int maxStrength;
        [SerializeField] private int strength;
        [SerializeField] private int maxArmor;
        [SerializeField] private int currentExtraHealth;
        [SerializeField] private float speed;

        [FormerlySerializedAs("attackDamage")] [SerializeField]
        private float damage;

        [SerializeField] private EntityCamp camp;
        [SerializeField] private float idleTime;
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

    public class EntityDataChangedEventArgs : EventArgs
    {
        private static readonly Dictionary<string,Type> PropertyTypes = new();
        public EntityDataChangedEventArgs(string propertyName, object oldValue, object newValue)
        {
            PropertyName = propertyName;
            PropertyTypes.TryAdd(propertyName, typeof(EntityData).GetProperty(propertyName)?.PropertyType);
            PropertyType = PropertyTypes[propertyName];
            OldValue = oldValue;
            NewValue = newValue;
        }

        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
}