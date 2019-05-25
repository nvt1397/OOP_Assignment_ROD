using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMage : Enemy
{
    private Animator anim;
    private float shieldTimer;
    private bool isShielding;
    //phase1
    public GameObject fireShield;
    public GameObject fireball_left1, fireball_left2, fireball_left3;
    private Vector2 pos_left1, pos_left2, pos_left3;
    public GameObject fireball_right1, fireball_right2, fireball_right3;
    private Vector2 pos_right1, pos_right2, pos_right3;
    private float shootTimer1;
    //phase2
    private int weaponIndex = 0;
    public GameObject Circle, Sword, FlameBall, Orb;
    private float shootTimer2;
    //phase3
    public GameObject MultiOrb_left, MultiOrb_right;
    private float shootTimer3;
    //di chuyển
    private float oldPosX;
    private float oldPosY;
    private float currentAngle = 0f;
    private float radius = 2f;
    private float circleTime = 3f;
    private float rotatespeed;
    GhostMage()
    {
        newStat.CurrentHP = 360f;
        size = 2f;
    }
    protected override void Start()
    {     
        base.Start();
        anim = gameObject.GetComponent<Animator>();
        isFacing = true;
        oldPosX = transform.position.x;
        oldPosY = transform.position.y;
        rotatespeed = (Mathf.PI * 2) / circleTime;
        fireShield.SetActive(false);
    }

    private void MovePatternCircular(float rotatespeed)
    {
        rotatespeed = (Mathf.PI * 2) / circleTime;
        currentAngle += Time.deltaTime * rotatespeed;
        float newPosX = radius * Mathf.Cos(currentAngle);
        float newPosY = radius * Mathf.Sin(currentAngle);
        transform.position = new Vector3(oldPosX + newPosX, oldPosY + newPosY, transform.position.z);
    }

    private void MageShield()
    {
        if (shieldTimer <= 0 && isShielding == false)
        {
            fireShield.SetActive(true);
            shieldTimer = 5f;
            isShielding = true;
        }
        if (shieldTimer <= 4f)
        {
            fireShield.SetActive(false);
            isShielding = false;
        }
    }
    //phase1
    private void Phase1()
    {
        if (shootTimer1 <= 0)
        {
            shootTimer1 = Random.Range(2.5f, 3.5f);
            if (isFacing)
            {
                pos_left1 = pos_left2 = pos_left3 = gameObject.transform.position;
                pos_left1 = pos_left2 = pos_left3 += new Vector2(-0.3f, 0.2f);
                Instantiate(fireball_left1, pos_left1, Quaternion.identity);
                Instantiate(fireball_left2, pos_left2, Quaternion.identity);
                Instantiate(fireball_left3, pos_left3, Quaternion.identity);
            }
            else
            {
                pos_right1 = pos_right2 = pos_right3 = gameObject.transform.position;
                pos_right1 = pos_right2 = pos_right3 += new Vector2(0.3f, 0.2f);
                Instantiate(fireball_right1, pos_right1, Quaternion.identity);
                Instantiate(fireball_right2, pos_right2, Quaternion.identity);
                Instantiate(fireball_right3, pos_right3, Quaternion.identity);
            }
        }
    }
    //phase2
    private void Phase2()
    {

        if (shootTimer2 <= 0)
        {
            shootTimer2 = 3f;
            weaponIndex = Random.Range(1, 5);
            switch (weaponIndex)
            {
                case 1://Circle
                    if (isFacing)
                    {
                        pos_left1 = gameObject.transform.position;
                        pos_left1 += new Vector2(-1f, 0.8f);
                        Instantiate(Circle, pos_left1, Quaternion.identity);
                    }
                    else
                    {
                        pos_right1 = gameObject.transform.position;
                        pos_right1 += new Vector2(1f, 0.8f);
                        Instantiate(Circle, pos_right1, Quaternion.identity);
                    }
                    break;
                case 2://FlameBall
                    if (isFacing)
                    {
                        pos_left2 = gameObject.transform.position;
                        pos_left2 += new Vector2(-0.9f, -0.3f);
                        Instantiate(FlameBall, pos_left2, Quaternion.identity);
                    }
                    else
                    {
                        pos_right2 = gameObject.transform.position;
                        pos_right2 += new Vector2(0.9f, 0.3f);
                        Instantiate(FlameBall, pos_right2, Quaternion.identity);
                    }
                    break;
                case 3://Sword
                    if (isFacing)
                    {
                        pos_right2 = gameObject.transform.position;
                        pos_right2 += new Vector2(0.7f, -0.2f);
                        Instantiate(Sword, pos_right2, Quaternion.identity);
                    }
                    else
                    {
                        pos_left2 = gameObject.transform.position;
                        pos_left2 += new Vector2(0.7f, -0.2f);
                        Instantiate(Sword, pos_left2, Quaternion.identity);
                    }
                    break;
                case 4://Orb
                    if (isFacing)
                    {
                        pos_right1 = gameObject.transform.position;
                        pos_right1 += new Vector2(0.6f, 0.6f);
                        Instantiate(Orb, pos_right1, Quaternion.identity);
                    }
                    else
                    {
                        pos_left1 = gameObject.transform.position;
                        pos_left1 += new Vector2(-0.6f, -0.6f);
                        Instantiate(Orb, pos_left1, Quaternion.identity);
                    }
                    break;
            }
        }
    }

    private void Phase3()
    {
        if (shootTimer3 <= 0)
        {
            shootTimer3 = 5f;
            pos_left1 = gameObject.transform.position;
            if (isFacing)
            {
                pos_left1 += new Vector2(-0.22f, 1f);
                for (int i = 1; i <= 40; i++)
                {
                    pos_left1 += new Vector2(0.01f, -0.08f);
                    Instantiate(MultiOrb_left, pos_left1, Quaternion.identity);
                }
            }
            else
            {
                pos_left1 += new Vector2(0.22f, 1f);
                for (int i = 1; i <= 40; i++)
                {
                    pos_left1 += new Vector2(-0.01f, -0.08f);
                    Instantiate(MultiOrb_right, pos_left1, Quaternion.identity);
                }
            }
        }
    }
    private void Update()
    {
        //bộ đếm giờ
        shieldTimer -= Time.deltaTime;
        //phase
        shootTimer1 -= Time.deltaTime;
        shootTimer2 -= Time.deltaTime;
        shootTimer3 -= Time.deltaTime;
        //tấn công mỗi phase
        if (newStat.CurrentHP >= 240)
            Phase1();
        else if (newStat.CurrentHP >= 120)
        {
            Phase1();
            Phase2();
        }
        else
        {
            Phase1();
            Phase3();
        }
        anim.SetFloat("currentHP", newStat.CurrentHP);
        MovePatternCircular(rotatespeed);
        MageShield();
        facingCheck(this.size);
        Dead(1f);
    }
}
