using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkull : Enemy
{
    public GameObject FireBreath;
    FireSkull()
    {
        newStat.CurrentHP = 200f;
        size = 2f;
    }  
    private void Breath()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= 2.5f && (player.transform.position.y + 1f < transform.position.y))
        {
            FireBreath.SetActive(true);
        }
        else
        {
            FireBreath.SetActive(false);
        }
    }
    protected override void Start()
    {
        base.Start();      
        FireBreath.SetActive(false);
    }

    private void Chase()
    {
        Vector2 playerPos = new Vector2(player.transform.position.x + 1.5f, player.transform.position.y + 1.5f);
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= 8f)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerPos, Time.deltaTime);
        }
    }

    private void Update()
    {
        facingCheck(this.size);
        Chase();
        Breath();
        if (newStat.CurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
