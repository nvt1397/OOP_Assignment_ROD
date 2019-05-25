using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_of_man : MonoBehaviour {
    private MainPlayer player;
    public float a = -1;
    public float dmg = 3f; 
    private Rigidbody2D rb;
    public Vector2 direction;

    private void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        Fire();
    }
    
    private void Fire()
    {
        direction = new Vector2(a*direction.x, direction.y);
        rb.AddForce(direction);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ColliderCheck"))
        {
            player.CurrentHP -= dmg;
            Destroy(gameObject);
        }        
    }
    private void Update()
    {
        Destroy(gameObject,2f);
    }
}
