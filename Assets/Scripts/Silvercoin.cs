using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silvercoin : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Silvertext.Coin += 1;
            Destroy(gameObject);
        }
    }
}
