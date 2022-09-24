using UnityEngine;

namespace Assets.Scripts.Logic.Movement
{
    public class RectilinearMovement : AMovementLogic
    {
        public RectilinearMovement(Vector2 accelerationDir, Transform transform) : base(accelerationDir, transform)
        {
        }

        public override void Move()
        {
            transform.Translate(acceleration);
        }
    }
}