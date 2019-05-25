using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableChasingOrb : ChasingOrb {
    private Rigidbody2D rb;
    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerAttack"))
        {
            Destroy(gameObject);
        }
        if (col.CompareTag("Player"))
        {
            MainPlayer player = col.GetComponent<MainPlayer>();
            Rigidbody2D playerRB = col.GetComponent<Rigidbody2D>();
            player.CurrentHP -= 5f;
            playerRB.AddForce(Vector2.left * 50f);
            Destroy(gameObject);
        }
    }
}
