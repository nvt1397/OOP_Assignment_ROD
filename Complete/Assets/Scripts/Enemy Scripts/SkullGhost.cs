using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullGhost : Enemy
{
    SkullGhost()
    {
        newStat.CurrentHP = 60f;
        speed = 0.5f;
    }
    private bool halfHP, dead;
    private Animator skullAnim;
    private Rigidbody2D rb;
    protected override void Start()
    {      
        base.Start();
        skullAnim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Move()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= 7f)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
    }

    private void Chase()
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        if (newStat.CurrentHP <= 30f)
            halfHP = true;

        if (halfHP)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerPos, 1.5f * Time.deltaTime);
            rb.gravityScale = 0f;
        }
    }

    public override void Dead(float timer)
    {
        if (newStat.CurrentHP <= 0)
        {
            dead = true;
            gameObject.tag = "Wall";
            rb.gravityScale = 0.5f;
            Destroy(gameObject, timer);
        }
    }

    private void Update()
    {
        skullAnim.SetBool("halfHP", halfHP);
        skullAnim.SetBool("dead", dead);               
        if(newStat.CurrentHP >= 0)
        Move();
        Chase();
        facingCheck(size);
        Dead(1.5f);
    }
}
