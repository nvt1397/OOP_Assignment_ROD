using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionShot : MonoBehaviour {
    public float velocity_x,velocity_y;
    private Rigidbody2D rb;
    private MainPlayer player;
    public float dmg = 6f;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.CurrentHP -= dmg;
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        rb.velocity = new Vector2(velocity_x*2, velocity_y*2);
        Destroy(gameObject, 1.5f);
    }
}
