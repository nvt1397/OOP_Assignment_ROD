using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private float jumpPower = 40f;
    private float dashPower = 10f;
    private float speed = 5f;
    private float maxspeed = 2f;
    private Rigidbody2D rb;
    private Animator anim;
    private MainPlayer player;
    public GameObject fireballToLeft, fireballToRight;
    public GameObject fullPowToLeft, fullPowToRight;
    private Vector2 fireballPos;
    public GameObject FireShield;
    //các giá trị boolean để kiểm tra 
    public bool grounded;
    public bool isDamaged;
    public bool isFacing;
    public bool isAttacking;
    public bool isDashing;
    public bool isShielding;
    //thời gian chờ
    private float attackTimer;
    private float dashTimer;
    private void Start()
    {
        player = gameObject.GetComponentInParent<MainPlayer>();
        rb = player.GetComponentInChildren<Rigidbody2D>();
        anim = player.GetComponentInChildren<Animator>();
        attackTimer = 1f;
        isFacing = true;
        isDashing = false;
        isShielding = false;
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = col.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = null;
        }
    }

    private void Fire(bool canAttack, float fullPow)
    {
        if (canAttack == false) return;
        fireballPos = transform.position;
        if (isFacing)
        {
            fireballPos += new Vector2(0.1f, 0);
            if (fullPow >= 100)
            {
                Instantiate(fullPowToRight, fireballPos, Quaternion.identity);
                player.CurrentPow -= 100f;
            }
            else Instantiate(fireballToRight, fireballPos, Quaternion.identity);
        }
        else
        {
            fireballPos += new Vector2(-0.1f, 0);
            if (fullPow >= 100)
            {
                Instantiate(fullPowToLeft, fireballPos, Quaternion.identity);
                player.CurrentPow -= 100f;
            }
            else Instantiate(fireballToLeft, fireballPos, Quaternion.identity);
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.X) && player.CurrentStamina > 5f)
        {
            if (isDashing == false)
            {
                player.CurrentStamina -= 10f;
                isDashing = true;
                dashTimer = 3f;
                if (isFacing == true)
                    rb.AddForce(Vector2.right * dashPower);
                else
                    rb.AddForce(Vector2.left * dashPower);
            }
        }
        if (dashTimer <= 2.8f)
            isDashing = false;
        dashTimer -= Time.deltaTime;
    }
    private void Jump()
    {
        if (player.CurrentStamina >= 0)
        {
            rb.AddForce(Vector2.up * jumpPower);
            player.CurrentStamina -= 15f * Time.deltaTime;
        }
    }
    private void Shield(bool turnOn)
    {
        if (turnOn == true)
        {
            if (player.CurrentEnergy >= 10f)
            {
                FireShield.SetActive(true);
                isShielding = true;
            }
        }
        else
        {
            isShielding = false;
            FireShield.SetActive(false);
        }
    }
    private void Controller()
    {
        //nhận các input để chạy animation
        anim.SetBool("grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        anim.SetBool("isDamaged", isDamaged);
        anim.SetBool("isAttacking", isAttacking);
        //nhận input di chuyển
        float h = Input.GetAxis("Horizontal");

        //di chuyển
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        //giới hạn tốc độ
        if (rb.velocity.y > maxspeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxspeed);
        }
        if (rb.velocity.x > maxspeed && isDashing == false)
        {
            rb.velocity = new Vector2(maxspeed, rb.velocity.y);
        }

        if (rb.velocity.x < -maxspeed && isDashing == false)
        {
            rb.velocity = new Vector2(-maxspeed, rb.velocity.y);
        }


        //đổi hướng
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacing = false;
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFacing = true;
        }

        //nhảy
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }

        //bắn 
        if (Input.GetKey(KeyCode.Z) && attackTimer <= 0)
        {
            if (player.CurrentEnergy >= 0)
            {
                player.CurrentEnergy -= 5f;
                isAttacking = true;
                attackTimer = 0.5f;
                Fire(true, player.CurrentPow);
            }
        }
        if (attackTimer <= 0.3f)
            isAttacking = false;
        attackTimer -= Time.deltaTime;

        //lướt
        Dash();

        //khiên
        if (Input.GetKeyDown(KeyCode.C))
            if (isShielding == false)
            {
                Shield(true);
            }
            else
            {
                Shield(false);
            }
    }
    private void FixedUpdate()
    {
        if (player.CurrentHP > 0)
        {
            Controller();
        }
        if (isShielding == true)
        {
            player.CurrentEnergy -= 10f * Time.deltaTime;
        }
        if (player.CurrentEnergy <= 0)
        {
            FireShield.SetActive(false);
            isShielding = false;
        }
    }
}


