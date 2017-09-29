using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    private float lifeTime;
    private float maxTime = 3.0f;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lifeTime += Time.deltaTime;
        if (lifeTime > maxTime) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter (Collision hit) {

        //impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, Vector3.up)) as GameObject;
        //NetworkServer.Spawn(impactParticle);
        //
        //Destroy(projectileParticle, 3f);
        //Destroy(impactParticle, 5f);
        if (hit.gameObject.tag == "Enemy") {
            hit.gameObject.GetComponent<MonsterDamage>().Damage();
        }
        Destroy(gameObject);
    
    }
}
