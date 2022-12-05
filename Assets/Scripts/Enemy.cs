using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    void Update()
    {
       if(health < 1)
       {
            Destroy(gameObject);
       } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            health -= 1;
        }
    }
}
