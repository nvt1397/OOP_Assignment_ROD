using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    public float fallDelay;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
        if (col.collider.CompareTag("Platform") || col.collider.CompareTag("Trap"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        GameObject.Destroy(gameObject);
        yield return 0;
    }
}
