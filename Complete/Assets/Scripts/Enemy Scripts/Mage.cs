using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mage : Enemy
{
    private Animator Mageanim;
    private float dmgTimer;
    //tấn công
    private float attackTimer;
    private Vector2 objPos;
    public GameObject fireObj, breakableObj;
    public GameObject Shield;
    private Vector2 shieldPos1, shieldPos2;
    private float shieldTimer;
    private bool isShielding;
    Mage()
    {
        newStat.CurrentHP = 300f;
        size = 3f;
    }
    protected override void Start()
    {  
        base.Start();
        Mageanim = gameObject.GetComponent<Animator>();
        attackTimer = 0f;
        Shield.SetActive(false);
    }

    private void MageAttack(bool canAttack)
    {
        float seed = Random.Range(0, 100);
        if (canAttack == false) return;
        objPos = gameObject.transform.position;
        if (isFacing)
            objPos += new Vector2(-0.3f, 0.4f);
        else objPos += new Vector2(0.3f, 0.4f);
        if(seed/50 <= 1)
        Instantiate(fireObj, objPos, Quaternion.identity);
        else
        Instantiate(breakableObj, objPos, Quaternion.identity);
    }
    private void MageShield()
    {
        if (shieldTimer <= 0 && isShielding == false)
        {
            Shield.SetActive(true);
            shieldTimer = 10f;
            isShielding = true;
        }
        if (shieldTimer <= 5f)
        {
            Shield.SetActive(false);
            isShielding = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerAttack") && dmgTimer <= 0 && newStat.CurrentHP > 0)
        {
            dmgTimer = 1f;
            Mageanim.Play("MageDmg");
        }
    }

    public override void Dead(float timer)
    {
        //chạy hoạt cảnh chết
        if (newStat.CurrentHP <= 0)
        {
            Mageanim.Play("MageDead");
            gameObject.tag = "Wall";
            Destroy(gameObject, timer);
        }
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distance <= 5f && attackTimer <= 0)
        {
            if (newStat.CurrentHP > 0) MageAttack(true);
            attackTimer = 3f;
        }
        if (newStat.CurrentHP > 0) facingCheck(this.size);
        dmgTimer -= Time.deltaTime;
        attackTimer -= Time.deltaTime;
        shieldTimer -= Time.deltaTime;
        MageShield();
        Dead(3f);
    }
}

