using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Movement
{
    public class EnemyStarshipMovement : StarshipMovement
    {
        public Vector2 CurrentAcceleration => currentAcceleration;

        public EnemyStarshipMovement(Vector2 acceleration, float maxAcceleration, Transform transform, Transform starshipBody) : base(acceleration, maxAcceleration, transform, starshipBody)
        {
        }
    }
}