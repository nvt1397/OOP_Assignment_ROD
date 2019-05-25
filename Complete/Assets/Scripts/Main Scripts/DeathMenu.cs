using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour {
    private MainPlayer player;
    public GameObject DeathUI;
    private float restartTimer;
    public int sceneIndex = -1;
    public int currentIndex;
    private void Start()
    {
        DeathUI.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
    }
    private void LateUpdate()
    {
        currentIndex = sceneIndex;
        if (player.CurrentHP <= 0)
        {
            restartTimer += Time.deltaTime;
            if (restartTimer >= 2f)
            {
                DeathUI.SetActive(true);
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GC.Collect();
                    SceneManager.LoadScene(sceneIndex);
                }
            }
        }        
    }
    
}
