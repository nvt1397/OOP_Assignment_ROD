using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : Enemy
{
    public GameObject AcidBall;
    private Vector2 firePos;
    private float shootTimer;
    Crab()
    {
        newStat.CurrentHP = 50f;
    }

    private void Fire()
    {

        float triggerRange = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (shootTimer <= 0 && triggerRange <= 4f)
        {
            firePos = transform.position;
            Instantiate(AcidBall, firePos, Quaternion.identity);
            shootTimer = 2f;
        }
    }
    private void Move()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= 7f)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
    }
    private void Update()
    {
        Fire();
        shootTimer -= Time.deltaTime;
        facingCheck(size);
        Move();
        Dead(0f);
    }
}
