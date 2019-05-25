using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public float velocity_x = 4f;
    private float velocity_y = 0f;
    protected float dmg = 10f;
    protected Enemy enemy;
    private Rigidbody2D rb;
    private MainPlayer player;
    public GameObject impactEffect;
    public AudioSource fly;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
    }   

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(velocity_x, velocity_y);
        Destroy(gameObject,2f);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player") && !col.CompareTag("ColliderCheck"))
        {
            GameObject newimpactEffect = Instantiate(impactEffect, gameObject.transform.position, Quaternion.identity);
            fly = null;
            Destroy(newimpactEffect, 0.25f);
        }
        if (col.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            enemy = col.GetComponent<Enemy>();
            enemy.Damaged(dmg);
            if (enemy.newStat.CurrentHP <= 0f)
            enemy = null;
            player.CurrentPow += 10f;         
        }
        if (col.CompareTag("Wall") || col.CompareTag("Breakable") || col.CompareTag("Platform") || col.CompareTag("Trap") || col.CompareTag("Ceil"))
        {
            Destroy(gameObject);
        }
        GC.Collect();
    }
}
