using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {
    public GameObject PauseUI;
    private bool paused = false;
    public DeathMenu current;
    private void Start()
    {
        PauseUI.SetActive(false);  
    }
    private void Update()
    {
        if (Input.GetButtonDown("Pause")){
            paused = !paused;
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Reload()
    {
        SceneManager.LoadScene(current.sceneIndex);
        GC.Collect();
    }
    public void Resume()
    {
        paused = false;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(1);
        GC.Collect();
    }
}
