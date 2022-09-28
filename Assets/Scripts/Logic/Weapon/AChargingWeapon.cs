using System.Timers;
using UnityEngine;

namespace Assets.Scripts.Logic.Weapon
{
    public class AChargingWeapon : AWeapon
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

        public AChargingWeapon(float chargeRecoveryTime, float speedProjectile, float attackRate, Transform weapon) 
            : base(speedProjectile, attackRate, weapon)
        {
            timerChargeRecovery = new Timer(chargeRecoveryTime);
            timerChargeRecovery.Elapsed += TimerChargeRecovery_Elapsed;
        }

        public override ProjectileSpawnData Shoot()
        {
            if (!CanAttacked) return null;

            NumberCharges--;

            if (NumberCharges == MaxCharges - 1)
            {
                timerChargeRecovery.Start();
                timerAttack.Start();
            }

            return new ProjectileSpawnData
            {
                Direction = Vector2.up,
                Rotation = weapon.rotation.eulerAngles
            };
        }

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
            NumberCharges++;
            if (NumberCharges == MaxCharges) timerChargeRecovery.Stop();
        }
    }
}