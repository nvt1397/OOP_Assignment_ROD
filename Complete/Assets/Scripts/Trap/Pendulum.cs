using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{

    private Rigidbody2D body2d;
    private float leftPushRange = -0.3f;
    private float rightPushRange = 0.3f;
    private float velocityThreshHold = 120f;
    private void Push()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < rightPushRange && body2d.angularVelocity > 0 && body2d.angularVelocity < velocityThreshHold)
        {
            body2d.angularVelocity = velocityThreshHold;
        }
        else if (transform.rotation.z < 0 && transform.rotation.z > leftPushRange && body2d.angularVelocity < 0 && body2d.angularVelocity > velocityThreshHold * -1)
        {
            body2d.angularVelocity = velocityThreshHold * -1;
        }
    }
    private void Start()
    {
        body2d = gameObject.GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThreshHold;
    }

    private void Update()
    {
        Push();
    }

}
