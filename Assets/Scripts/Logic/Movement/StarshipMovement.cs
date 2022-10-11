using System;
using UnityEngine;

namespace Assets.Scripts.Logic.Movement
{
    public class StarshipMovement : AMovementLogic
    {
        /// <summary>
        /// Тело для отображения поворота
        /// </summary>
        private readonly Transform starshipBody;

        /// <summary>
        /// Макс допустимое ускорение
        /// </summary>
        protected readonly float maxAcceleration;

        /// <summary>
        /// Перевод из градусов в радианы угла Z
        /// </summary>
        private float RadianAngleZ { get { return (float)((starshipBody.localEulerAngles.z * Math.PI) / 180); } }

        /// <summary>
        /// Конструктор движения коробля
        /// </summary>
        /// <param name="movementResistance">Сила сопротивления движению</param>
        /// <param name="acceleration">Величина с которой будет ускорятся объект</param>
        /// <param name="maxAcceleration">Макс величина ускорения</param>
        /// <param name="transform">Положение объекта</param>
        /// <param name="starshipBody">Тело корабля</param>
        public StarshipMovement(Vector2 acceleration, float maxAcceleration, Transform transform, Transform starshipBody) : 
            base(acceleration, transform)
        {
            this.starshipBody = starshipBody;
            this.maxAcceleration = maxAcceleration;
        }

        public override void Move()
        {
            transform.Translate(currentAcceleration);
        }

        /// <summary>
        /// Добавление ускорения
        /// </summary>
        public void Accelerate()
        {
            double newPosX = Math.Cos(RadianAngleZ) * acceleration.x + acceleration.y * Math.Sin(RadianAngleZ);
            double newPosY = acceleration.y * Math.Cos(RadianAngleZ) - acceleration.x * Math.Sin(RadianAngleZ);

            Vector2 currentDir = new(-(float)newPosX, (float)newPosY);
            Vector2 newDirAcceleration = currentDir + currentAcceleration;

            float lengthNewAcceleration = CalculateLengthVector(newDirAcceleration);

            if (lengthNewAcceleration > maxAcceleration)
            {
                float reductionDegree = maxAcceleration / lengthNewAcceleration;
                currentAcceleration = newDirAcceleration * reductionDegree;
            }
            else
            {
                currentAcceleration = newDirAcceleration;
            }
        }

        public void Reset()
        {
            currentAcceleration = Vector2.zero;
        }

        /// <summary>
        /// Повернуть корабль
        /// </summary>
        /// <param name="turningDir"></param>
        public void Turn(float turningDir)
        {
            starshipBody.Rotate(new Vector3(0, 0, (float)turningDir));
        }

        /// <summary>
        /// Вычеслить длину вектора
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        private float CalculateLengthVector(Vector2 vector)
        {
            return (float)Math.Sqrt(Math.Pow(vector.x, 2) + Math.Pow(vector.y, 2));
        }
    }
}