using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : Enemy
{
    private Animator buganim;
    Bug()
    {
        newStat.CurrentHP = 40f;
    }
    protected override void Start()
    {
        base.Start();
        buganim = gameObject.GetComponent<Animator>();
        gameObject.tag = "Wall";
    }

    protected override void Chase(float maxRange, float speed)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x + 0.2f, player.transform.position.y);
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= 2f)
        {
            gameObject.tag = "Enemy";
            isChasing = true;
        }
        if (distance <= maxRange && isChasing)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerPos, speed * Time.deltaTime);
        }
    }

    public override void Dead(float timer)
    {
        if (newStat.CurrentHP <= 0)
        {
            gameObject.tag = "Wall";
            Destroy(gameObject, timer);
        }
    }

    private void Update()
    {
        buganim.SetBool("isChasing", isChasing);
        if (newStat.CurrentHP > 0)
        {
            Chase(maxRange, speed);
            facingCheck(size);
        }
        Dead(1f);
    }
}
