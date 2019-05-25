using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour {
    private MainPlayer player;
    public GameObject explosion;
	private void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("ColliderCheck"))
        {
            player.CurrentHP -= 8f;
        }
        Destroy(gameObject);
        explosion = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(explosion, 0.25f);
    }
}
