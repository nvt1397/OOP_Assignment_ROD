using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private bool left, down;
    private float oldPosX, newPosX;
    private float oldPosY, newPosY;
    private float currentAngle = 0f;
    public float radius = 2f;
    public float circleTime = 3f;
    private float rotatespeed;
    public float range = 5f;
    public float speed = 1f;
    public int moveType = 1;
    private void Start()
    {
        oldPosX = transform.position.x;
        newPosX = oldPosX - range;
        oldPosY = transform.position.y;
        newPosY = oldPosY - range;
        left = true;
        down = true;
        rotatespeed = (Mathf.PI * 2) / circleTime;
    }

    private void MovePatternHorizontal(float speed)
    {
        float currentPosX = transform.position.x;
        //đổi hướng
        if (transform.position.x <= newPosX + 0.1f)
        {
            left = false;
        }
        if (transform.position.x >= oldPosX - 0.1f)
        {
            left = true;
        }
        if (currentPosX <= oldPosX && left == true)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(oldPosX - range, transform.position.y), speed * Time.deltaTime);
        if (transform.position.x >= newPosX && left == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(newPosX + range, transform.position.y), speed * Time.deltaTime);
        }
    }
    private void MovePatternVertical(float speed)
    {
        float currentPosY = transform.position.y;
        //đổi hướng
        if (transform.position.y <= newPosY)
        {
            down = false;
        }
        if (transform.position.y >= oldPosY)
        {
            down = true;
        }

        if (currentPosY <= oldPosY && down == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, oldPosY - range), speed * Time.deltaTime);
        }
        if (transform.position.y >= newPosY && down == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, newPosY + range), speed * Time.deltaTime);
        }
    }

    private void MovePatternCircular(float rotatespeed)
    {
        rotatespeed = (Mathf.PI * 2) / circleTime;
        currentAngle += Time.deltaTime * rotatespeed;
        float newPosX = radius * Mathf.Cos(currentAngle);
        float newPosY = radius * Mathf.Sin(currentAngle);
        transform.position = new Vector3(oldPosX + newPosX, oldPosY + newPosY, transform.position.z);
    }

    void FixedUpdate()
    {
        switch (moveType) {
            case 1:
                MovePatternHorizontal(this.speed);
                break;
            case 2:
                MovePatternVertical(this.speed);
                break;
            case 3:
                MovePatternCircular(this.rotatespeed);
                break;
        }
    }
}
