using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigger : MonoBehaviour {
    private float size = 2f;
    public float growRate = 0.75f;
	private void Update () {
        size += growRate * Time.deltaTime;
        transform.localScale = new Vector3(size, size, size);
	}
}
