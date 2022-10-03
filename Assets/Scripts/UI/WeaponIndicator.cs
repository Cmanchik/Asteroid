using Assets.Scripts.Performance.Weapon;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class WeaponIndicator : MonoBehaviour
    {
        [SerializeField] private AChargingWeaponScript weapon;

        [Space]

        [SerializeField] private TMP_Text numberCharge;
        [SerializeField] private Image cooldownIndicator;

        private int charges;

        private float recoveryTime;
        private float currentTime;

        private bool recovered;

        private void Start()
        {
            charges = weapon.MaxChargers;
            numberCharge.text = charges.ToString();

            recoveryTime = weapon.ChargingRecoveryTime;
            currentTime = weapon.ChargingRecoveryTime;

            weapon.SubShootEvent(Shoot);
            weapon.SubRecoveryChargeEvent(RecoveryCharge);

            recovered = false;
        }

        private void Update()
        {
            if (!recovered) return;

            cooldownIndicator.fillAmount = currentTime / recoveryTime;
            currentTime -= Time.deltaTime;
        }

        private void RecoveryCharge()
        {
            charges++;
            numberCharge.text = charges.ToString();

            currentTime = recoveryTime;

            if (charges == weapon.MaxChargers)
            {
                cooldownIndicator.enabled = false;
                recovered = false;
            }
        }

        private void Shoot()
        {
            if (charges == weapon.MaxChargers)
            {
                cooldownIndicator.enabled = true;
                recovered = true;
            }

            charges--;
            numberCharge.text = charges.ToString();
        }
    }
}