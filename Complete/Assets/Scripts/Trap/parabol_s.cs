using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabol_s : MonoBehaviour {
    private MainPlayer player;
    public GameObject fire_of_man;
    private float delayTimer;
    private Vector2 pos;
    public float a = -1;

    private void Fire () {
        pos = transform.position;
        pos += new Vector2(a * 0.3f, -0.1f);
        float width = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (width <= 5f && delayTimer <= 0)
        {
            Instantiate(fire_of_man, pos, Quaternion.identity);
            delayTimer = 0.5f;
        }

    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
    }

    private void Update () {
        Fire();
        delayTimer -= Time.deltaTime;
	}
}
