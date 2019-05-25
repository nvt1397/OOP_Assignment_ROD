using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slug : Enemy
{
    public float HP = 100f;
    public float range = 4f;
    private float oldPosX, newPosX;
    Slug()
    {
        newStat.CurrentHP = HP;
    }
    Slug(float HP, float size, float range, float speed)
    {
        newStat.CurrentHP = HP;
        this.size = size;
        this.range = range;
        this.speed = speed;
    }

    protected override void Start()
    {
        Slug newtype = new Slug(HP, size, range, speed);
        newStat.CurrentHP = newtype.HP;
        base.Start();
        oldPosX = transform.position.x;
        newPosX = oldPosX - range;
        isFacing = true;
    }

    private void Move()
    {
        float currentPosX = transform.position.x;
        //đổi hướng
        if (transform.position.x <= newPosX + 0.1f)
        {
            isFacing = false;
            transform.localScale = new Vector3(-size, size, size);
        }
        if (transform.position.x >= oldPosX - 0.1f)
        {
            isFacing = true;
            transform.localScale = new Vector3(size, size, size);
        }

        if (currentPosX <= oldPosX && isFacing == true)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(oldPosX - range, transform.position.y), speed*Time.deltaTime);
        if (transform.position.x >= newPosX && isFacing == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(newPosX + range, transform.position.y), speed*Time.deltaTime);
        }
    }

    private void Update()
    {
        Move();
        Dead(0f);
    }
}
