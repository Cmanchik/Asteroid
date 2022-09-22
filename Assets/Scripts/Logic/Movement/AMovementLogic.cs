using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Movement
{
    public abstract class AMovementLogic
    {
        /// <summary>
        /// Велечина и направление силы
        /// </summary>
        protected readonly Vector2 acceleration;

        /// <summary>
        /// Текущее ускорение
        /// </summary>
        protected Vector2 currentAcceleration;

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
        public float CurrentSpeed { get { return Mathf.Sqrt(Mathf.Pow(currentAcceleration.x, 2) + Mathf.Pow(currentAcceleration.y, 2)); } }

        /// <summary>
        /// Конструктор логики перемещения
        /// </summary>
        /// <param name="acceleration">Величина с которой будет ускорятся объект</param>
        /// <param name="maxAcceleration">Макс величина ускорения</param>
        /// <param name="transform">Положение объекта</param>
        public AMovementLogic(Vector2 acceleration, float maxAcceleration, Transform transform)
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