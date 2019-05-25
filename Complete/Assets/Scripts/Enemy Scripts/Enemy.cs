using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour,IKillable
{
    public class EnemyStat
    {
        private float currentHP;
        public float CurrentHP
        {
            get { return currentHP; }
            set { currentHP = value; }
        }
    }
    public EnemyStat newStat = new EnemyStat();
    protected Enemy() {}
    protected Enemy(float HP) {}

    public float size = 1f;
    public float speed = 1f;
    public float maxRange = 1f;
    protected MainPlayer player;
    protected bool isChasing;
    protected bool isFacing;   

    public void Damaged(float dmg)
    {
        newStat.CurrentHP -= dmg;
    }
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
        isChasing = false;
    }

    protected virtual void facingCheck(float size)
    {
        if (player.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(size, size, size);
            isFacing = true;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-size, size, size);
            isFacing = false;
        }
    }

    protected virtual void Chase(float maxRange, float speed)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= maxRange)
        {
            isChasing = true;
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerPos, speed * Time.deltaTime);
        }
    }
    public virtual void Dead(float timer)
    {
        if (newStat.CurrentHP <= 0)
        {
            Destroy(gameObject, timer);
        }
    }
}






