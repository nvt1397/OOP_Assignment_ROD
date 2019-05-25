using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoss : MonoBehaviour {
    public GameObject Boss;
    private Enemy boss;
    public GameObject finishedGate;
    private void Start()
    {
        finishedGate.SetActive(false);
        boss = Boss.GetComponent<Enemy>();
    }

    private void Update()
    {
        if (boss.newStat.CurrentHP <= 0)
        {
            finishedGate.SetActive(true);
        }
    }
}
