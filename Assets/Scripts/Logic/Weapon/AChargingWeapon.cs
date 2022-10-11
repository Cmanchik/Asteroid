using System;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts.Logic.Weapon
{
    public abstract class AChargingWeapon : AWeapon
    {
        /// <summary>
        /// Текущее кол-во зарядов
        /// </summary>
        public int NumberCharges { get; protected set; }

        /// <summary>
        /// Макс кол-во зарядов
        /// </summary>
        public int MaxCharges { get; protected set; }

        /// <summary>
        /// Глобальная возможность ударить учитывая заряды
        /// </summary>
        public override bool CanAttacked
        {
            get => NumberCharges != 0 && canAttacked;
            protected set => base.CanAttacked = value;
        }

        /// <summary>
        /// Возможность ударить без учета зарядов
        /// </summary>
        protected bool canAttacked;

        /// <summary>
        /// Таймер востановления зарядов
        /// </summary>
        protected readonly Timer timerChargeRecovery;

        /// <summary>
        /// Действие при откате заряда
        /// </summary>
        public event Action OnChargerRecovered;

        public AChargingWeapon(int maxCharges, float chargeRecoveryTime, float speedProjectile, float attackRate, Transform weapon) 
            : base(speedProjectile, attackRate, weapon)
        {
            MaxCharges = maxCharges;
            NumberCharges = maxCharges;

            canAttacked = true;

            timerChargeRecovery = new Timer(chargeRecoveryTime * 1000);
            timerChargeRecovery.Elapsed += TimerChargeRecovery_Elapsed;
            timerChargeRecovery.AutoReset = true;
        }

        public abstract override ProjectileSpawnData Shoot();

        protected override void OnCooldownAttackEnd(object sender, ElapsedEventArgs e)
        {
            canAttacked = true;
            timerAttack.Stop();
        }

        /// <summary>
        /// Метод отслеживания востановления зарядов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerChargeRecovery_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (NumberCharges + 1 > MaxCharges) NumberCharges = MaxCharges;
            else NumberCharges++;

            OnChargerRecoveredInvoke();

            if (NumberCharges == MaxCharges) timerChargeRecovery.Stop();
        }

        protected void OnChargerRecoveredInvoke()
        {
            OnChargerRecovered?.Invoke();
        }

        public void ResetCharges()
        {
            NumberCharges = MaxCharges;
            timerChargeRecovery.Stop();
        }
    }
}