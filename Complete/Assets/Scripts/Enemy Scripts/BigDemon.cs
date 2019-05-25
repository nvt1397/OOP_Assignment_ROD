using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDemon : Enemy {
    public GameObject FireBall_left, FireBall_right;
    private Vector2 pos;
    private float fireTimer;
    BigDemon()
    {
        newStat.CurrentHP = 100f;
    }

    private void Fire()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance <= maxRange && fireTimer <= 0)
        {
            pos = gameObject.transform.position;
            if (isFacing)
            {
                pos += new Vector2(0.3f, 0);
                Instantiate(FireBall_left, pos, Quaternion.identity);
            }
            else
            {
                pos += new Vector2(-0.3f, 0);
                Instantiate(FireBall_right, pos, Quaternion.identity);
            }
            fireTimer = 1f;
        }
    }
	void Update () {
        fireTimer -= Time.deltaTime;
        Fire();
        facingCheck(3f);
        Dead(0f);
	}
}
