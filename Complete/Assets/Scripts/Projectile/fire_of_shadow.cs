using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_of_shadow : MonoBehaviour {
    private MainPlayer player;
    public float dmg = 6f;
    private Vector2 playerPos, pos;
    public float speed = 3f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
        playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        pos = new Vector2(transform.position.x, transform.position.y);
        facingCheck(1f);
    }
    private void FireAtPlayer()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), (playerPos - pos) * 5 + pos, speed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }
    private void facingCheck(float size)
    {
        if (player.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(size, size, size);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-size, size, size);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ColliderCheck"))
        {
            player.CurrentHP -= dmg;
        }
    }
    private void Update()
    {
        FireAtPlayer();
        Destroy(gameObject, 2);
    }
}
