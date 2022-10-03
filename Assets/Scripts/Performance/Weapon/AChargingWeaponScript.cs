using Assets.Scripts.Logic.Weapon;
using Assets.Scripts.Utils;
using System;
using UnityEngine;

namespace Assets.Scripts.Performance.Weapon
{
    public abstract class AChargingWeaponScript : AWeaponScript
    {
        [SerializeField] protected float chargingRecoveryTime;
        [SerializeField] protected int maxCharges;

        public int MaxChargers { get { return maxCharges; } } 
        public float ChargingRecoveryTime { get { return chargingRecoveryTime; } }

        public int CurrentCharges { get { return ((AChargingWeapon)weapon).NumberCharges; } }

        protected abstract override void Shoot();

        public void SubRecoveryChargeEvent(Action action)
        {
            ((AChargingWeapon)weapon).OnChargerRecovered += () => UnityMainThread.wkr.AddJob(action);
        }
    }
}