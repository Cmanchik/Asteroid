using Assets.Scripts.Logic.Weapon;
using System;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts.Performance.Weapon
{
    public abstract class AWeaponScript : MonoBehaviour
    {
        [SerializeField] protected float speedProjectile;

        [SerializeField] protected float attackRate;
        public float AttackRate { get { return attackRate; } }

        [Space]

        [SerializeField] protected Transform weaponPos;
        [SerializeField] protected GameObject projectilePrefab;

        protected AWeapon weapon;

        public bool CanAttacked { get { return weapon.CanAttacked; } }

        protected InputSystem input;

        public void SubShootEvent(Action action)
        {
            weapon.OnShooted += action;
        }

        protected abstract void Shoot();

        private void OnEnable()
        {
            input.Enable();
        }

        private void OnDisable()
        {
            input.Disable();
        }
    }
}