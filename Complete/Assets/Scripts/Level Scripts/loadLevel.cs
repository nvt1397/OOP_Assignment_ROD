using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadLevel : MonoBehaviour {
    public DeathMenu current;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            SceneManager.LoadScene(current.sceneIndex + 1);
    }
}
