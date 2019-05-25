using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    public Resume getIndex;
    private void Start()
    {
        getIndex = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Resume>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void ResumeGame()
    {
        if (getIndex.getCurrentIndex() == -1) {
            return;
        }
        SceneManager.LoadScene(getIndex.getCurrentIndex());
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
