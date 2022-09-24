using Assets.Scripts.Performance.Movement;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ShipIndicators : MonoBehaviour
    {
        [SerializeField] private TMP_Text speedField;

        [Space]

        [SerializeField] private StartshipMovementScript movementLogic;

        private void Update()
        {
            speedField.text = movementLogic.CurrentSpeed.ToString();
        }
    }
}