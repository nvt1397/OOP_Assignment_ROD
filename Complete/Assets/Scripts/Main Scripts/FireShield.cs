using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShield : MonoBehaviour
{
    public GameObject impactEffect;
    private Enemy enemy;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Platform"))
        {
            GameObject newimpactEffect = Instantiate(impactEffect, col.transform.position, Quaternion.identity);
            Destroy(newimpactEffect, 0.25f);
        }
        if (col.CompareTag("Projectile") || col.CompareTag("Breakable"))
        {
            Destroy(col.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            enemy = col.GetComponent<Enemy>();
            enemy.Damaged(20f * Time.deltaTime);
            if (enemy.newStat.CurrentHP <= 0f)
                enemy = null;
        }
    }
}
