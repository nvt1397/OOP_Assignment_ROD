using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalChase : Enemy {

    public float HP = 50f;
    HorizontalChase()
    {
        newStat.CurrentHP = 50f;
        speed = 2f;
        maxRange = 5f;

    }
    HorizontalChase(float HP, float size,float speed,float maxRange)
    {
        newStat.CurrentHP = HP;
        this.size = size;
        this.speed = speed;
        this.maxRange = maxRange;
    }
    private void Awake()
    {
        HorizontalChase newtype = new HorizontalChase(HP,speed,size,maxRange);
        newStat.CurrentHP = newtype.HP;       
    }

    private void Move()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= maxRange && transform.position.y >= player.transform.position.y - 0.5f )
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
    }
    private void Update () {
        facingCheck(this.size);
        Move();
        Dead(0f);
	}
}
