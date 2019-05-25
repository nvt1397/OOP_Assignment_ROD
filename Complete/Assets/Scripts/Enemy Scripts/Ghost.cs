using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    private Animator ghostAnim;
    Ghost()
    {
        speed = 1f;
        size = 2f;
        maxRange = 6f;
        newStat.CurrentHP = 60f;
    }
    protected override void Start()
    {
        base.Start();
        ghostAnim = gameObject.GetComponent<Animator>();
    }
    protected override void Chase(float maxRange, float speed)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= 2f) isChasing = true;
        if (distance <= maxRange && isChasing == true)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerPos, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerAttack"))
        {
            speed += 0.3f;
        }
    }
    private void Update()
    {
        ghostAnim.SetBool("isChasing", isChasing);
        Chase(maxRange, speed);
        facingCheck(this.size);
        Dead(0f);
    }
}
