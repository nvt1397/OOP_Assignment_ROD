using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PreLoad : MonoBehaviour {
    private float Timer = 3f;
    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
            SceneManager.LoadScene(1);
    }
}
