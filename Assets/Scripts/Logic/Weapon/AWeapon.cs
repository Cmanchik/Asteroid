using System;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts.Logic.Weapon
{
    public abstract class AWeapon
    {
        /// <summary>
        /// Скорость полета снаряда
        /// </summary>
        protected float speedProjectile;

        /// <summary>
        /// Объект выпускающий снаряды
        /// </summary>
        protected Transform weapon;

        /// <summary>
        /// Таймер отката атаки оружия
        /// </summary>
        protected Timer timerAttack;

        /// <summary>
        /// Направление снаряда по умолчанию
        /// </summary>
        protected Vector2 directionProjectile;

        public virtual bool CanAttacked { get; protected set; }

        /// <summary>
        /// Базовый конструктор оружия
        /// </summary>
        /// <param name="speedProjectile">скорость полета снаряда</param>
        /// <param name="attackRate">скорость атаки оружия в милисекундах</param>
        /// <param name="transform">объект выпускаюший снаряды</param>
        public AWeapon(float speedProjectile, float attackRate, Transform weapon)
        {
            this.speedProjectile = speedProjectile;
            this.weapon = weapon;

            timerAttack = new Timer(attackRate);
            timerAttack.Elapsed += OnCooldownAttackEnd;

            directionProjectile = Vector2.up;
        }

        /// <summary>
        /// Метод отслеживания отката атаки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnCooldownAttackEnd(object sender, ElapsedEventArgs e)
        {
            CanAttacked = true;
            timerAttack.Stop();
        }

        /// <summary>
        /// Подписка на событие отката оружия
        /// </summary>
        /// <param name="handler">Метод для подписки</param>
        public void SubCooldownEndEvent(ElapsedEventHandler handler)
        {
            timerAttack.Elapsed += handler;
        }

        /// <summary>
        /// Отподписка от событие отката оружия
        /// </summary>
        /// <param name="handler">Метод для отписки</param>
        public void UnsubCooldownEndEvent(ElapsedEventHandler handler)
        {
            timerAttack.Elapsed -= handler;
        }

        /// <summary>
        /// Логика выстрела
        /// </summary>
        /// <returns>Возвращает направление полёта снаряда</returns>
        public abstract ProjectileSpawnData Shoot();
    }
}