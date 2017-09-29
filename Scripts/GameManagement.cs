using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour {

    public static GameManagement _instance;
    public int playerScore = 0;
    public Text score;

    public Transform player;
    public GameObject[] awardPrefabs;
    public int awardMaxCount = 1;

    void Awake () {
        _instance = this;
        InvokeRepeating("Spawn", 5f, 10f);
    }
	
	// Update is called once per frame
	void Update () {
        score.text = "Score：" + playerScore;
    }

    public void Spawn() {
        GameObject[] respawns = GameObject.FindGameObjectsWithTag("Award");

        if (respawns.Length >= awardMaxCount)
            return;

        int posX = Random.Range((int)player.position.x -10, (int)player.position.x + 10);
        int posZ = Random.Range((int)player.position.z - 10, (int)player.position.z + 10);
        //Vector2 pos1 = Random.insideUnitCircle * 20;
        Vector3 pos2 = new Vector3(posX, 0, posZ);

        Vector3 directionVector = pos2 - player.position;

        if (directionVector.magnitude > 5f) {
            Instantiate(awardPrefabs[Random.Range(0, awardPrefabs.Length)], pos2, Quaternion.identity);
        } else {
            Spawn();
        }
    }
}