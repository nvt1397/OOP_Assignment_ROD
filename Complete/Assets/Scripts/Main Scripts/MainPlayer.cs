using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour, IKillable {
    //chỉ số của người chơi
    private const float MAX = 100f;    
    private float currentHP;
    private float currentStamina;
    private float currentEnergy;
    private float currentPow;
    public float CurrentHP
    {
        get { return currentHP; }
        set
        {
            currentHP = value;
            if (currentHP > MAX) currentHP = MAX;
        }
    }
    //năng lượng để bay
    public float CurrentStamina
    {
        get { return currentStamina; }
        set
        {
            currentStamina = value;
            if (currentStamina > MAX) currentStamina = MAX;
        }
    }
    //năng lượng để bắn
    public float CurrentEnergy
    {
        get { return currentEnergy; }
        set
        {
            currentEnergy = value;
            if (currentEnergy > MAX) currentEnergy = MAX;
        }
    }
    //đầy sức mạnh
    public float CurrentPow
    {
        get { return currentPow; }
        set
        {
            currentPow = value;
        }
    }
    //nhận các thuộc tính của rigidbody và animator
    private Rigidbody2D rb;
    private Animator anim;

    
    public void Dead(float timer)
    {
        //máu và năng lượng không vượt quá 100        
        if (CurrentHP <= 0)
        {
            anim.Play("Dead");
            //khóa di chuyển sau khi chết
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            rb.isKinematic = true;
            Resources.UnloadUnusedAssets();
        }
    }
    //khi bắt đầu
    void Start()
    {
        currentHP = MAX;
        currentStamina = MAX;
        currentEnergy = MAX;
        currentPow = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        //hồi năng lượng theo thời gian     
        currentEnergy += 3f * Time.deltaTime;
        Dead(0f);
    }
}


