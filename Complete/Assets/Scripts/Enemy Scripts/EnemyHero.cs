using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHero : Enemy
{
    private bool attack;
    private Animator enemyanim;
    private float attackTimer;
    private float shieldTimer;
    private float distance;
    EnemyHero()
    {
        newStat.CurrentHP = 50f;
    }
    protected override void Start()
    {       
        base.Start();
        attack = false;
        enemyanim = gameObject.GetComponent<Animator>();
        transform.localScale = new Vector3(size, size, size);
        shieldTimer = 0f;
    }

    private void Move()
    {
        if (distance <= 4f && shieldTimer <= 0)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x + 0.3f, transform.position.y), 0.5f * Time.deltaTime);
    }

    private void can_Attack()
    {
        if (distance <= 0.33f && shieldTimer <= 0)
        {
            attack = true;
        }
    }

    private void Attack()
    {
        if (attack && shieldTimer <= 0)
        {
            if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(size, size, size);
            }
            else
            {
                transform.localScale = new Vector3(-size, size, size);
            }
            attackTimer = 0.5f; shieldTimer = 3f;
        }

    }
    private void Shield()
    {
        if (shieldTimer >= 0 && attackTimer <= 0)
        {
            attack = false;
            if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-size, size, size);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x - 3f, transform.position.y), 0.5f * Time.deltaTime);
            }
            else
            {
                transform.localScale = new Vector3(size, size, size);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x + 3f, transform.position.y), 0.5f * Time.deltaTime);
            }

        }
    }
    private void Update()
    {
        enemyanim.SetBool("attack", attack);
        distance = Vector2.Distance(player.transform.position, transform.position);
        attackTimer -= Time.deltaTime;
        shieldTimer -= Time.deltaTime;
        Move();
        can_Attack();
        Attack();
        Shield();
        Dead(0f);
    }
}