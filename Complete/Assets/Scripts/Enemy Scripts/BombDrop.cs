using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : Enemy
{
    public GameObject bomb;
    private float delayTimer;
    private Vector2 pos1, pos2, pos3;

    BombDrop()
    {
        newStat.CurrentHP = 50f;
    }

    private void Drop()
    {
        float width = Mathf.Abs(player.transform.position.x - transform.position.x);
        float distance = Vector2.Distance(player.transform.position, transform.position);
        pos1 = pos2 = pos3 = transform.position;
        pos1 += new Vector2(0, -0.2f);
        pos2 += new Vector2(-0.2f, -0.2f);
        pos3 += new Vector2(0.2f, -0.2f);
        if (width <= 3f && delayTimer <= 0 && distance <= 8f)
        {
            Instantiate(bomb, pos1, Quaternion.identity);
            Instantiate(bomb, pos2, Quaternion.identity);
            Instantiate(bomb, pos3, Quaternion.identity);
            delayTimer = 2f;
        }
    }

    private void Update()
    {
        delayTimer -= Time.deltaTime;
        Drop();
        Dead(0);
    }
}
