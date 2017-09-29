using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform spawnObject;

    private AudioSource gunAudio;

    private bool isAttack = false;
    private float lifeTime;
    private float maxTime = 0.5f;

    //紀錄手指觸碰位置
    Vector2 m_screenPos = new Vector2();

    void Start () {
        //允許多點觸碰
        Input.multiTouchEnabled = true;

        gunAudio = GetComponent<AudioSource>();
    }

    void Update () {
        MobileInput();

        if (Input.GetMouseButtonDown(0)) {
            gunAudio.Play();
            GameObject go = Instantiate(bulletPrefab, spawnObject.position, spawnObject.rotation) as GameObject;
            go.GetComponent<Rigidbody>().AddForce(transform.forward * 30, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.JoystickButton4)) {
            isAttack = true;
        } else {
            isAttack = false;
            lifeTime = 0.5f;
        }

        if (isAttack) {
            lifeTime += Time.deltaTime;
            if (lifeTime > maxTime) {
                gunAudio.Play();
                GameObject go = Instantiate(bulletPrefab, spawnObject.position, spawnObject.rotation) as GameObject;
                go.GetComponent<Rigidbody>().AddForce(transform.forward * 30, ForceMode.VelocityChange);
                lifeTime = 0f;
            }
        }
    }

    void MobileInput() {
        if (Input.touchCount <= 0)
            return;

        //1個手指觸碰螢幕
        if (Input.touchCount == 1) {

            //開始觸碰
            if (Input.touches[0].phase == TouchPhase.Began) {
                GameObject go = Instantiate(bulletPrefab, spawnObject.position, spawnObject.rotation) as GameObject;
                go.GetComponent<Rigidbody>().AddForce(-transform.up * 30, ForceMode.VelocityChange);
            }
        } 
    }
}
