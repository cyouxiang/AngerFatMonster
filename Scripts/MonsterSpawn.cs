using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour {

    public Transform player;
    public GameObject[] monsterPrefabs;
    public int monsterMaxCount = 1;

	void Start () {
        InvokeRepeating("Spawn", 0.5f, 3f);
    }

	void Update () {

    }

    public void Spawn () {
        GameObject[] respawns = GameObject.FindGameObjectsWithTag("Enemy");
        //print(respawns.Length);
        //print(monsterPrefabs.Length - 1);
        //print(Random.Range(0, monsterPrefabs.Length - 1));
        if (respawns.Length >= monsterMaxCount)
            return;

        int posX = Random.Range((int)player.position.x -20, (int)player.position.x + 20);
        int posZ = Random.Range((int)player.position.z - 20, (int)player.position.z + 20);
        //Vector2 pos1 = Random.insideUnitCircle * 20;
        Vector3 pos2 = new Vector3(posX, 0, posZ);

        Vector3 directionVector = pos2 - player.position;

        if (directionVector.magnitude > 10f) {
            Instantiate(monsterPrefabs[Random.Range(0, monsterPrefabs.Length)], pos2, Quaternion.identity);
        } else {
            Spawn();
        }
    }
}
