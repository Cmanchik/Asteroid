using Assets.Scripts.Performance.Movement;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ShipIndicators : MonoBehaviour
    {
        [SerializeField] private TMP_Text speedField;
        [SerializeField] private TMP_Text coordinateField;
        [SerializeField] private TMP_Text angleField;

        private string speedText;
        private string coordinateText;
        private string angleText;

        [Space]

        [SerializeField] private StartshipMovementScript movementLogic;
        [SerializeField] private Transform body;
        [SerializeField] private Transform starShipBody;

        private new Transform transform;

        private void Awake()
        {
            transform = GetComponent<Transform>();

            speedText = speedField.text;
            coordinateText = coordinateField.text;
            angleText = angleField.text;
        }

        private void Update()
        {
            speedField.text = string.Format(speedText, movementLogic.CurrentSpeed.ToString());
            coordinateField.text = string.Format(coordinateText, body.position.ToString());
            angleField.text = string.Format(angleText, starShipBody.eulerAngles.z.ToString()); 
        }

        public void Reset()
        {
            speedField.text = string.Format(speedText, "0");
            coordinateField.text = string.Format(coordinateText, Vector2.zero);
            angleField.text = string.Format(angleText, "0");
        }
    }
}