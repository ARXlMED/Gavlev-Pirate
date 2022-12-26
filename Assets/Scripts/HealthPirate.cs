using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPirate : MonoBehaviour
{
    [SerializeField] public float startingHP;
    public float currenthealth { get; private set;}

    private void Awake()
    {
        currenthealth = startingHP;
    }
    private void TakeDamage(float _damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startingHP);
        if (currenthealth > 0)
        {
            //player live
        }
        if (currenthealth < 0)
        {
            //player die
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}
