using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Resume : MonoBehaviour {
    public DeathMenu current;
    private int currentIndex = -1;
    public Scene mainMenu;
    public int getCurrentIndex() {
        return currentIndex; 
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene() != mainMenu)
        DontDestroyOnLoad(gameObject);
        current = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DeathMenu>();
        if(current != null)
        {
            currentIndex = current.currentIndex;
        }
    }
}
