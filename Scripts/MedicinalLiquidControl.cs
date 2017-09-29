using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicinalLiquidControl : MonoBehaviour {

    private float lifeTime;
    private float maxTime = 10.0f;

    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, Vector3.up, 2f);

        lifeTime += Time.deltaTime;
        if (lifeTime > maxTime) {
            Destroy(gameObject);
        }
    }
}
