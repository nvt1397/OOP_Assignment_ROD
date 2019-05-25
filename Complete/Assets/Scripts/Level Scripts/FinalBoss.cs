using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour {
    public GameObject closedgate;
    public GameObject Boss;
    private GhostMage finalboss;
    public GameObject finishedGate;
    private MainPlayer player;
	private void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
        closedgate.SetActive(false);
        finishedGate.SetActive(false);     
        Boss.SetActive(false);
        finalboss = Boss.GetComponent<GhostMage>();
    }
	
	private void Update () {
		if(player.transform.position.x <= -53f)
        {
            closedgate.SetActive(true);
            Boss.SetActive(true);          
        }
        if(finalboss.newStat.CurrentHP <= 0)
        {
            finishedGate.SetActive(true);
            closedgate.SetActive(false);
        }
	}
}
