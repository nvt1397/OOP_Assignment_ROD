using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_sin : MonoBehaviour {

    private MainPlayer player;
    public int direction = 1;
    private float speed = 0.05f;
    private float x0, y0, x = 0, y = 0;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
        x0 = transform.position.x;
        y0 = transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ColliderCheck"))
        {
            player.CurrentHP -= 5f;
            Destroy(gameObject);
        }
        
    }
    private void Update()
    {
        x += speed;
        y = 0.7f * Mathf.Sin(x);
        transform.position = new Vector2(x0 + direction*x*0.5f, y0 + y);
        if(x * 0.5f >= 7f || x * 0.5f <= -7f) Destroy(gameObject);
    }

}
