using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public bool Pausegame;
    public GameObject pauseGameMenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausegame)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }    
    }
    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }
    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
