using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : Enemy
{
    public GameObject fire_of_shadow;
    private Vector2 firePos;
    private float fireTimer = 1.4f;
    Shadow()
    {
        newStat.CurrentHP = 80f;
    }
    private void Fire()
    {
        firePos = transform.position;
        float triggerRange = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (fireTimer <= 0 && triggerRange <= 7f)
        {
            if (isFacing) firePos += new Vector2(-0.5f, 0.8f);
            else firePos += new Vector2(0.5f, 0.8f);
            Instantiate(fire_of_shadow, firePos, Quaternion.identity);
            fireTimer = 2.1f;
        }
    }
    private void Update()
    {
        Fire();
        facingCheck(2f);
        fireTimer -= Time.deltaTime;
        Dead(0f);
    }
}
