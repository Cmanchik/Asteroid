using UnityEngine;
using Assets.Scripts.Logic.Movement;

namespace Assets.Scripts.Performance.Movement
{
    public class MovementScript : MonoBehaviour
    {
        [SerializeField] private float movementResistance;
        [SerializeField] private float acceleration;
        [SerializeField] private float maxAcceleration;

        public float CurrentSpeed { get { return movementLogic.CurrentSpeed; } }

        private StarshipMovement movementLogic;

        private InputSystem input;

        private bool canMove;

        private void Awake()
        {
            movementLogic = new StarshipMovement(movementResistance, acceleration, maxAcceleration, transform);
            input = new InputSystem();

            canMove = false;
        }

        private void Start()
        {
            input.Starship.Movement.started += context => canMove = true;

            input.Starship.Movement.canceled += context => canMove = false;
        }

        private void FixedUpdate()
        {
            movementLogic.ResistMovement();
            movementLogic.Move();

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