using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currenthealth / 10;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currenthealth /10;
    }
}
