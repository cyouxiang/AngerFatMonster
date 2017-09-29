using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchPlayer : MonoBehaviour {

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private MonsterDamage monsterDamage;

    private bool isAttack = false;
    private float lifeTime;
    private float maxTime = 3.0f;

    void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        monsterDamage = GetComponent<MonsterDamage>();
    }

	void Update () {

        if (monsterDamage.isDie) {
            navMeshAgent.Stop();
        } else {
            navMeshAgent.SetDestination(GameObject.FindWithTag("Player").transform.position);
        }

        if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) <= 2.5f) {
            if (monsterDamage.isDie) {
                isAttack = false;
            } else {
                isAttack = true;
            }
        } else {
            isAttack = false;
            lifeTime = 3.0f;
        }

        if (isAttack) {
            lifeTime += Time.deltaTime;
            if (lifeTime > maxTime) {
                animator.SetTrigger("Attack");
                GameObject.FindWithTag("Player").GetComponent<PlayerDamage>().Damage();
                lifeTime = 0f;
            }
        }

        
    }
}
