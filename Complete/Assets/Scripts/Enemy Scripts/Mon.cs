using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mon : Enemy
{
    private Animator monAnim;
    private float distance;
    private bool flag = false;
    Mon()
    {
        newStat.CurrentHP = 20f;
        size = 1f;
        speed = 1f;
    }
	protected override void Start ()
    {
        base.Start();
        monAnim = gameObject.GetComponent<Animator>();
    }
    private void Dead()
    {
        if (newStat.CurrentHP <= 0)
        {
            Destroy(gameObject, 0.25f);
            flag = true;
        }
    }
    private void Boom()
    {
        if (flag == true) return;
        if (distance <= 0.5f)
        {

            monAnim.SetTrigger("Boom");
            player.CurrentHP -= 15f;
            newStat.CurrentHP = 0;
        }
    }
    private void Move()
    {    
        if (distance <= 5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
        }
        if (distance <= 0.7f)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * 4 * Time.deltaTime);
        }

    }

    private void Update ()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);
        monAnim.SetFloat("Distance", distance);      
        facingCheck(size);
        Move();
        Boom();
        Dead();
    }
}
