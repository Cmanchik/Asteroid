using Assets.Scripts.Logic.Enemy;
using Assets.Scripts.Logic.Movement;
using UnityEngine;

namespace Assets.Scripts.Performance.Movement
{
    public class EnemyStarshipMovementScript : MonoBehaviour
    {
        [SerializeField] private EnemyStarshipMovement movementLogic;

        [Space]

        [SerializeField] private float acceleration;
        [SerializeField] private float maxAcceleration;
        [SerializeField] private float speedTurning;
        [SerializeField] private Transform starshipBody;

        private EnemyController enemyLogic;

        private void Awake()
        {
            movementLogic = new EnemyStarshipMovement(new Vector2(0, acceleration), maxAcceleration, transform, starshipBody);
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            enemyLogic = new EnemyController(transform, player.transform, movementLogic, speedTurning);
        }

        private void FixedUpdate()
        {
            enemyLogic.Move();
        }
    }
}