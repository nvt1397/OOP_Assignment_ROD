using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    Skeleton()
    {
        newStat.CurrentHP = 100f;
        size = 2f;
        speed = 0.5f;
    }
    private Animator skeletonAnim;
    public GameObject miniSke1,miniSke2;
    private Vector2 mini1, mini2;
    private float delayTimer = 5f;
    private float distance;
    protected override void Start()
    {       
        base.Start();
        skeletonAnim = gameObject.GetComponent<Animator>();
    }
    private void Attack()
    {
        if (distance < 1f)
        {
            skeletonAnim.SetTrigger("Attack");
        }    
    }
    protected void Move()
    {
        if (newStat.CurrentHP <= 0) return;
        if (distance <= 5f)
        {
            if (isFacing == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x + 0.2f, transform.position.y), speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x - 0.2f, transform.position.y), speed * Time.deltaTime);
            }
        }           
    }
    private void Spawn()
    {
        if (delayTimer >= 0) return;
        if (newStat.CurrentHP > 0 && distance < 5f)
        {
            mini1 = mini2 = transform.position;
            mini1 += new Vector2(-0.2f, 0f);
            mini2 += new Vector2(0.2f, 0f);
            Instantiate(miniSke1, mini1, Quaternion.identity);
            Instantiate(miniSke2, mini2, Quaternion.identity);
            delayTimer = 25f;
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
        distance = Vector2.Distance(player.transform.position, transform.position);
        delayTimer -= Time.deltaTime;
        facingCheck(size);
        Move();
        Attack();
        skeletonAnim.SetFloat("Distance", distance);
        skeletonAnim.SetFloat("currentHP", newStat.CurrentHP);
        Spawn();
        Dead(1.2f);

    }
}
   