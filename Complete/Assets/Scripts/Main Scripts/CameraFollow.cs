using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;
    private float smoothTimeX = 0.5f;
    private float smoothTimeY = 0.5f;
    private GameObject player;


    private void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	

	private void LateUpdate () {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
