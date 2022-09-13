using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Movement
{
    public class StarshipMovement : AMovementLogic
    {
        /// <summary>
        /// Сила сопротивления движению
        /// </summary>
        private readonly float movementResistance;

        /// <summary>
        /// Конструктор движения коробля
        /// </summary>
        /// <param name="movementResistance">Сила сопротивления движению</param>
        /// <param name="acceleration">Величина с которой будет ускорятся объект</param>
        /// <param name="maxAcceleration">Макс величина ускорения</param>
        /// <param name="transform">Положение объекта</param>
        public StarshipMovement(float movementResistance, float acceleration, float maxAcceleration, Transform transform) : 
            base(acceleration, maxAcceleration, transform)
        {
            this.movementResistance = movementResistance;
        }

        public override void Move()
        {
            currentAcceleration += currentAcceleration + acceleration >= maxAcceleration ? maxAcceleration : acceleration;
            transform.Translate(Vector2.up * currentAcceleration);
        }

        /// <summary>
        /// Логика затухания движения
        /// </summary>
        public void ResistMovement()
        {
            currentAcceleration -= currentAcceleration - movementResistance <= 0 ? currentAcceleration : movementResistance;
        }
    }
}