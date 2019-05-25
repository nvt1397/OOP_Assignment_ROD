using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : MonoBehaviour {
    private MainPlayer player;
    private Vector2 playerPos;
    private Vector3 destroyPoint;
    public float speed = 3f;
    private void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
        playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        destroyPoint = player.transform.position;
    }
    private void FireAtPlayer()
    {        
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerPos, speed * Time.deltaTime);
        if (transform.position == destroyPoint) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ColliderCheck"))
        {
            player.CurrentHP -= 2f;
            Destroy(gameObject);
        }
    }
    private void Update () {
        FireAtPlayer();
    }
}
