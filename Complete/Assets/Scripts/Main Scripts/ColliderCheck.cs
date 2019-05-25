using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour {
    private MainController controller;
    private MainPlayer player;
    private float dmgTimer, bulletTimer;
    private void Start()
    {
        player = gameObject.GetComponentInParent<MainPlayer>();
        controller = player.GetComponentInChildren<MainController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Wall"))
            controller.grounded = true;
        if ((col.CompareTag("Trap") || col.CompareTag("Enemy")) && dmgTimer <=0)
        {
            dmgTimer = 0.5f;
            player.CurrentHP -= 5f;
            controller.isDamaged = true;
            controller.grounded = true;
        }
        if (col.CompareTag("Projectile")){
            bulletTimer = 1f;
            controller.isDamaged = true;
        }
        if (col.CompareTag("Healing") && player.CurrentHP > 0)
        {
            player.CurrentHP += 20f;
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        controller.grounded = true;
        if(!col.CompareTag("Ceil") && !col.CompareTag("PlayerAttack") && !col.CompareTag("Wall"))
        player.CurrentStamina += 60f * Time.deltaTime;
        if (col.CompareTag("Wall"))
        {
            controller.grounded = false;
        }
        if (col.CompareTag("Trap"))
        {
            player.CurrentHP -= Time.deltaTime * 30f;
            controller.isDamaged = true;
            controller.grounded = true;
        }
        if (col.CompareTag("Enemy"))
        {
            player.CurrentHP -= Time.deltaTime * 10f;
            controller.isDamaged = true;
            controller.grounded = true;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        dmgTimer -= Time.deltaTime;
        bulletTimer -= Time.deltaTime;
        if(bulletTimer<=0) controller.isDamaged = false;
        controller.grounded = false;
        controller.isDamaged = false;
    }
}
