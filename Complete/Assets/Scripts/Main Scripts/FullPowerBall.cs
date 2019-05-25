using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FullPowerBall : Fireball {
    public GameObject explosionEffect;
    protected new float dmg = 50f;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player") && !col.CompareTag("ColliderCheck"))
        {      
            GameObject newexplosionEffect = Instantiate(explosionEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(newexplosionEffect, 0.25f);
        }
        if (col.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            enemy = col.GetComponent<Enemy>();
            enemy.Damaged(this.dmg);
            if (enemy.newStat.CurrentHP <= 0f)
                enemy = null;
        }
        if (col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        GC.Collect();
    }
}
