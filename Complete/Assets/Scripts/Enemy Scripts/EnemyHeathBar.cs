using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHeathBar : MonoBehaviour {
    private Enemy enemy;
    private float maxHP;
    private float currentX;
    private float maxX;
    private void Start () {
        enemy = gameObject.GetComponentInParent<Enemy>();
        currentX = maxX = gameObject.transform.localScale.x;
        maxHP = enemy.newStat.CurrentHP;
    }
	private void Update () {
        currentX = (enemy.newStat.CurrentHP / maxHP) * maxX;
        gameObject.transform.localScale = new Vector3(currentX, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
}
