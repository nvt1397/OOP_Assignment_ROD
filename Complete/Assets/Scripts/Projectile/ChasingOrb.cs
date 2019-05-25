using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingOrb : MonoBehaviour {
    private MainPlayer player;
    public float Speed = 2f;
    public float fadedTimer = 5f;
    public float dmg = 8f;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
    }

    void Update()
    {
        Destroy(gameObject, fadedTimer);
    }

    public void FixedUpdate()
    {
        Vector2 direction = (Vector2)player.transform.position - rb.position;
        float rotate = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotate * 200f;
        rb.velocity = transform.up * Speed;
    }


    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.CurrentHP -= dmg;
            Destroy(gameObject);
        }
    }
}
