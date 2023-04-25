using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Detector : MonoBehaviour
    {
        [SerializeField] private float detectorRadius;
        [SerializeField] private Mob hostMob;
        private CircleCollider2D collider;

        public float DetectorRadius
        {
            get => detectorRadius;
            set
            {
                collider.radius = value;
                detectorRadius = value;
            }
        }

        private void Awake()
        {
            hostMob = GetComponentInParent<Mob>();
            collider = GetComponent<CircleCollider2D>();
            collider.radius = detectorRadius;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Mob mob) && mob.EntityData.Camp != hostMob.EntityData.Camp)
            {
                hostMob.Targets.Add(mob);
            }
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Mob mob)&& mob.EntityData.Camp != hostMob.EntityData.Camp)
            {
                hostMob.Targets.Remove(mob);
            }
        }
    }
}