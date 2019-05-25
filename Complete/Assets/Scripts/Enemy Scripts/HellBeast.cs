using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellBeast : Enemy
{
    HellBeast()
    {
        newStat.CurrentHP = 300f;
        size = 3f;
    }
    private float attackTimer;
    private Vector2 objPos;
    public GameObject skull_left, skull_right;
    public GameObject Shield;
    private bool isAttack1, isAttack2;
    private Animator Beastanim;

    protected override void Start()
    {
        base.Start();    
        Beastanim = gameObject.GetComponent<Animator>();
        isFacing = true;
        isAttack1 = isAttack2 = false;
        Shield.SetActive(true);
    }
    private void Attack1(bool canAttack)
    {
        if (canAttack)
            isAttack1 = true;
        else isAttack1 = false;
    }
    private void Attack2(bool canAttack)
    {

        if (canAttack == false) return;
        objPos = gameObject.transform.position;
        isAttack2 = true;
        if (isFacing)
        {
            objPos += new Vector2(-0.5f, 0.1f);
            for (int i = 0; i <= 20; i++)
            {
                objPos += new Vector2(0, 0.01f);
                Instantiate(skull_left, objPos, Quaternion.identity);
            }
        }
        else
        {
            objPos += new Vector2(0.5f, 0.1f);
            for (int i = 0; i <= 20; i++)
            {
                objPos += new Vector2(0, 0.01f);
                Instantiate(skull_right, objPos, Quaternion.identity);
            }
        }
    }

    private void Update()
    {
        Beastanim.SetBool("isAttack1", isAttack1);
        Beastanim.SetBool("isAttack2", isAttack2);
        facingCheck(this.size);
        float triggerRange = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (triggerRange <= 2f) Shield.SetActive(false);
        else Shield.SetActive(true);
        if (triggerRange <= 5f)
        {
            if (player.transform.position.y <= transform.position.y)
            {
                if (attackTimer <= 0 && isAttack1 == false)
                {
                    attackTimer = 3f;
                    if (newStat.CurrentHP > 0)
                    {
                        Attack2(true);
                    }
                }
            }
            else if ((player.transform.position.x >= transform.position.x - 0.5f) && (player.transform.position.x <= transform.position.x + 0.5f))
            {
                Attack1(true);
            }
            else Attack1(false);
        }
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 2f)
        {
            isAttack2 = false;
        }
        Dead(0f);
    }
}