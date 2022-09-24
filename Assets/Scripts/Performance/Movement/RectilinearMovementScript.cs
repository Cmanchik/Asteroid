using Assets.Scripts.Logic.Movement;
using UnityEngine;

namespace Assets.Scripts.Performance.Movement
{
    public class RectilinearMovementScript : MonoBehaviour
    {
        private RectilinearMovement movement;

        public void Init(Vector2 directionMovement)
        {
            movement = new RectilinearMovement(directionMovement, transform);
        }

        private void FixedUpdate()
        {
            movement.Move();
        }
    }
}