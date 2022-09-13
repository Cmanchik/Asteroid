using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Movement
{
    public abstract class AMovementLogic
    {
        /// <summary>
        /// Велечина ускорения
        /// </summary>
        protected readonly float acceleration;

        /// <summary>
        /// Текущее ускорение
        /// </summary>
        protected float currentAcceleration;

        /// <summary>
        /// Макс допустимое ускорение
        /// </summary>
        protected readonly float maxAcceleration;

        /// <summary>
        /// Положение объекта
        /// </summary>
        protected readonly Transform transform;
     
        /// <summary>
        /// Текущая мгновенная скорость
        /// </summary>
        public float CurrentSpeed { get { return currentAcceleration; } }

        /// <summary>
        /// Конструктор логики перемещения
        /// </summary>
        /// <param name="acceleration">Величина с которой будет ускорятся объект</param>
        /// <param name="maxAcceleration">Макс величина ускорения</param>
        /// <param name="transform">Положение объекта</param>
        public AMovementLogic(float acceleration, float maxAcceleration, Transform transform)
        {
            this.acceleration = acceleration;
            this.maxAcceleration = maxAcceleration;
            this.transform = transform;
        }

        /// <summary>
        /// Логика передвижения
        /// </summary>
        public abstract void Move();
    }
}