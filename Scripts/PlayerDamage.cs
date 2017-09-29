using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {

    //static bool playerIsDie = false;
    public int playerMaxHP = 5;
    public int playerHP;
    public Image HPBar;

    public Image DEAD_BG;

    public float flashSpeed = 3f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    private bool damaged = false;
    private bool isDie = false;
    private float lifeTime;
    private float maxTime = 5.0f;

    private AudioSource playerAudio;
    public AudioClip[] impact;

    int rotaSpeed;

    void Start () {
        playerHP = playerMaxHP;
        DEAD_BG = GameObject.Find("DEAD_BG").GetComponent<Image>();
        playerAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (isDie) {
            lifeTime += Time.deltaTime;
            if (lifeTime > maxTime) {
                //Destroy(gameObject);
                Application.LoadLevel("AR");
            }
        } else {
            if (damaged) {
                DEAD_BG.color = flashColour;
            } else {
                DEAD_BG.color = Color.Lerp(DEAD_BG.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            damaged = false;
        }
	}

    public void Damage () {
        playerHP--;
        damaged = true;
        playerAudio.PlayOneShot(impact[0], 1f);
        HPBar.fillAmount = (float)playerHP / (float)playerMaxHP;
        if (playerHP == 0) {
            isDie = true;
            InvokeRepeating("Die", 0.1f, 0.02f);
        }
    }

    private void Die () {
        DEAD_BG.color += new Color(1, 0, 0, 0.003f);

        //transform.Rotate(Vector3.right * Time.deltaTime * -30);
        //transform.Rotate(Vector3.up * Time.deltaTime * rotaSpeed);
        //rotaSpeed -= 2;
    }

    public void Restore () {
        playerHP += 4;
        if (playerHP > 5)
            playerHP = 5;

        HPBar.fillAmount = (float)playerHP / (float)playerMaxHP;
    }
        
    void OnCollisionEnter(Collision other) {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Award") {
            playerAudio.PlayOneShot(impact[1], 1f);
            Destroy(other.gameObject);
            Restore();
        }
    }
}
