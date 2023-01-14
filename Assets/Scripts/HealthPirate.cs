using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPirate : MonoBehaviour
{
    [SerializeField] public float startingHP;
    public float currenthealth { get; private set;}
    public GameObject DeathPanel;
    public GameObject AllGame;
    public GameObject AllGame1;
    public GameObject AllGame2;
    public GameObject AllGame3;
    public GameObject AllGame4;
    public GameObject AllGame5;
    public GameObject AllGame6;

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
        if (currenthealth < 1)
        {
            DeathPanel.SetActive(true);
            currenthealth = currenthealth + 3;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
    public void Resumegamebutnotdelete()
    {
        DeathPanel.SetActive(false);
    }
    public void Deletegame()
    {
        Destroy(gameObject);
        Destroy (AllGame);
        Destroy (AllGame1);
        Destroy (AllGame2);
        Destroy (AllGame3);
        Destroy (AllGame4);
        Destroy (AllGame5);
        Destroy (AllGame6);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}
