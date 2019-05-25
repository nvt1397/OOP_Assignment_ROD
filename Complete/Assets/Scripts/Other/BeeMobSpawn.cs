using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMobSpawn : Enemy {

    public GameObject bee;
    private Vector2 pos1, pos2, pos3, pos4;
    private float timer;
	
	private void Update () {
		float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance <= 5f && timer <= 0)
        {
            pos1 = pos2 = pos3 = pos4 = transform.position;
            pos1 += new Vector2(-0.3f, -0.3f);
            pos2+= new Vector2(-0.1f, -0.3f);
            pos3 += new Vector2(0.1f, -0.3f);
            pos4 += new Vector2(0.3f, -0.3f);
            GameObject bee1 = Instantiate(bee, pos1, Quaternion.identity);
            GameObject bee2 = Instantiate(bee, pos1, Quaternion.identity);
            GameObject bee3 = Instantiate(bee, pos1, Quaternion.identity);
            GameObject bee4 = Instantiate(bee, pos1, Quaternion.identity);
            Destroy(bee1, 5f);
            Destroy(bee2, 5f);
            Destroy(bee3, 5f);
            Destroy(bee4, 5f);
            timer = 10f;
        }
        timer -= Time.deltaTime;
    }
}
