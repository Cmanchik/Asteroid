using UnityEngine;
using Assets.Scripts.Logic.Movement;

namespace Assets.Scripts.Performance.Movement
{
    public class StartshipMovementScript : MonoBehaviour
    {
        [SerializeField] private float acceleration;
        [SerializeField] private float maxAcceleration;

        [Space]

        [SerializeField] private Transform starshipBody;

        public float CurrentSpeed { get { return movementLogic.CurrentSpeed; } }

        private StarshipMovement movementLogic;

        private InputSystem input;

        private bool canMove;

        private void Awake()
        {
            movementLogic = new StarshipMovement(new Vector2(0, acceleration), maxAcceleration, transform, starshipBody);
            input = new InputSystem();

            canMove = false;
        }

        private void Start()
        {
            input.Starship.Accelerate.started += context => canMove = true;
            input.Starship.Accelerate.canceled += context => canMove = false;
        }

        private void FixedUpdate()
        {
            movementLogic.Move();
            movementLogic.Turn(input.Starship.Turning.ReadValue<float>());

            if (canMove) movementLogic.Accelerate();
        }

        private void OnEnable()
        {
            input.Enable();
        }

        private void OnDisable()
        {
            input.Disable();
        }
    }
}