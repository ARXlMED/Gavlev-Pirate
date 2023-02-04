using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_window : MonoBehaviour
{
    public GameObject dia_win;
    private void Start()
    {
        dia_win.SetActive(false);  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        dia_win.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        dia_win.SetActive(false);
        } 
    }    
}
