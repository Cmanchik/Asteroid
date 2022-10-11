using Assets.Scripts.Logic.Movement;
using System;
using UnityEngine;

namespace Assets.Scripts.Logic.Enemy
{
    public class EnemyController
    {
        private readonly Transform bodyEnemy;
        private readonly Transform bodyPlayer;

        private readonly EnemyStarshipMovement movementLogic;

        private readonly float speedTurning;

        public EnemyController(Transform enemy, Transform player, EnemyStarshipMovement movementLogic, float speedTurning)
        {
            bodyEnemy = enemy;
            bodyPlayer = player;
            this.movementLogic = movementLogic;
            this.speedTurning = speedTurning;
        }

        public void Move()
        {
            Vector2 direction = bodyPlayer.position - bodyEnemy.position;
            float angle2 = Vector2.SignedAngle(movementLogic.CurrentAcceleration.normalized, direction.normalized);

            if (angle2 >= 0) movementLogic.Turn(speedTurning);
            else movementLogic.Turn(-speedTurning);

            movementLogic.Move();
            movementLogic.Accelerate();
        }
    }
}