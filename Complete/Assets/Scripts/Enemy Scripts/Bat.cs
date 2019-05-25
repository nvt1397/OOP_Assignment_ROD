using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    private Animator Batanim;
    private Rigidbody2D rb;
    Bat()
    {
        newStat.CurrentHP = 20f;
    }
    protected override void Start()
    {
        base.Start();
        Batanim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();       
    }

    public override void Dead(float timer)
    {
        if (newStat.CurrentHP <= 0)
        {
            gameObject.tag = "Wall";
            rb.gravityScale = 0.5f;
            Destroy(gameObject, timer);
        }
    }

    private void Update()
    {
        Batanim.SetBool("isChasing", isChasing);
        if (newStat.CurrentHP > 0)
        {
            Chase(maxRange, speed);
            facingCheck(1f);
        }
        Dead(1.5f);
    }
}
