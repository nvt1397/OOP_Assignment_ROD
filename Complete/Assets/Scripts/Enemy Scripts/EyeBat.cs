using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBat : Enemy
{
    public GameObject eyeShot1, eyeShot2, eyeShot3, eyeShot4;
    private Vector2 firePos1, firePos2, firePos3, firePos4;
    public float range = 4f;
    private float oldPosY, newPosY;
    private bool isMovingDown;
    private float fireTimer;
    EyeBat()
    {
        newStat.CurrentHP = 40f;
    }
    protected override void Start()
    {       
        base.Start();
        oldPosY = transform.position.y;
        newPosY = oldPosY - range;
        isMovingDown = true;
    }

    private void Fire()
    {
        float distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (fireTimer <= 0 && distance <= 4f)
        {
            firePos1 = firePos2 = firePos3 = firePos4 = transform.position;
            firePos1 += new Vector2(0.2f, 0.2f);
            firePos2 += new Vector2(-0.2f, 0.2f);
            firePos3 += new Vector2(-0.2f, -0.2f);
            firePos4 += new Vector2(0.2f, -0.2f);
            Instantiate(eyeShot1, firePos1, Quaternion.identity);
            Instantiate(eyeShot2, firePos2, Quaternion.identity);
            Instantiate(eyeShot3, firePos3, Quaternion.identity);
            Instantiate(eyeShot4, firePos4, Quaternion.identity);
            fireTimer = 2f;
        }
    }
    private void Move()
    {
        float currentPosY = transform.position.y;
        //đổi hướng
        if (transform.position.y <= newPosY)
        {
            isMovingDown = false;
        }
        if (transform.position.y >= oldPosY)
        {
            isMovingDown = true;
        }

        if (currentPosY <= oldPosY && isMovingDown == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, oldPosY - range), speed * Time.deltaTime);
        }
        if (transform.position.y >= newPosY && isMovingDown == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, newPosY + range), speed * Time.deltaTime);
        }
    }
    private void Update()
    {
        facingCheck(this.size);
        Move();
        fireTimer -= Time.deltaTime;
        Fire();
        Dead(0f);
    }
}
