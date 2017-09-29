using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDamage : MonoBehaviour {

    public int monsterHP = 3;
    private Animator animator;

    public bool isDie = false;
    private float lifeTime;
    private float maxTime = 3.0f;
    private SphereCollider sphereCollider;
    
	void Start () {
        animator = GetComponent<Animator>();
        sphereCollider = GetComponent<SphereCollider>();
    }
	
	void Update () {
		if (isDie) {
            lifeTime += Time.deltaTime;
            if (lifeTime > maxTime) {
                Destroy(gameObject);
            }
        }
	}

    public void Damage () {
        monsterHP--;
        print(monsterHP);
        if (monsterHP == 0) {
            Die();
        } else {
            animator.SetTrigger("Hit");
        }
    }

    private void Die () {
        print("Die");
        sphereCollider.enabled = false;
        GameManagement._instance.playerScore++;
        animator.SetTrigger("Die");
        isDie = true;
    }
}
