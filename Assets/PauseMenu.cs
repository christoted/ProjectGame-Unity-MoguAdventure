using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public bool tombolPause=false;

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)||tombolPause)
        {
           Pause();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        tombolPause = false;
        
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        tombolPause = false;
    }
    public void tekanPause()
    {
        tombolPause = true;
        //Debug.Log("Pause Pressed");
    }
    public void loadMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(0);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
