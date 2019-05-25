using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Enemy {
    private Animator plantAnim;
    Plant()
    {
        newStat.CurrentHP = 150f;
    }
    
	protected override void Start () {
        base.Start();
        plantAnim = gameObject.GetComponent<Animator>();
    }
    private void Attack()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance > 2f)
        {
            gameObject.tag = "Wall";
        }
        else
        {
            gameObject.tag = "Enemy";
        }
        if (distance <= 1.5f)
        {
            plantAnim.SetTrigger("Attack");
        }
    }
    private void Update () {
        facingCheck(size);
        Attack();
        Dead(0f);
    }
}
