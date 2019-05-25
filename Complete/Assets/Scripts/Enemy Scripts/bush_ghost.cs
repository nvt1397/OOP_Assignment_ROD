using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush_ghost : Enemy {

    public GameObject ghost_sin;
    private float delayTimer;
    private Vector2 pos;
    private void appear_ghost()
    {
        pos = transform.position;
        pos += new Vector2(0, 0.4f);
        float width = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (width <= 7f && delayTimer <= 0)
        {
            Instantiate(ghost_sin, pos, Quaternion.identity);
            delayTimer = 2f;
        }
    }

    private void Update()
    {
        appear_ghost();
        delayTimer -= Time.deltaTime;
    }
}
