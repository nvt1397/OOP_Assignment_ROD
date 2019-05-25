using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : Enemy
{
    public float growRate = 0.2f;
    Grow()
    {
        newStat.CurrentHP = 100f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerAttack"))
        {
            size += growRate;
        }
    }
    private void Update()
    {
        facingCheck(this.size);
        Chase(maxRange, speed);
        Dead(0f);
    }
}
