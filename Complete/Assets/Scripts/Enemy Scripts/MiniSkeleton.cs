using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSkeleton : Enemy {

	protected override void Start () {
        base.Start();
        newStat.CurrentHP = 20f;
        speed = 0.3f;
    }
    private void Move()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= 5f)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
    }
    private void Dead()
    {
        Destroy(gameObject, 20f);
        if (newStat.CurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Update () {
        facingCheck(1f);
        Move();
        Dead();
	}
}
