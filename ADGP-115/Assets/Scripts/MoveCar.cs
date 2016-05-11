﻿using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour
{
    public float CarSpeed = 50.0f;
    Vector3 position;

    public int Health = 10;
    string movementAxisHorizontal;
    string movementAxisVertical;
    string fire;
    public GameObject Sniper;
    public GameObject Shotgun;
    public GameObject MachineGun;
    bool shooting = false;
    public int barrel = 0;
    float delaySpan = 1;
    float Delay = 1;
    public GameObject currentBullet;
    // Use this for initialization
    void Start () {
        position = transform.position;
        if (gameObject.tag == "P1")
        {
            movementAxisHorizontal = "P1Horizontal" ;
            movementAxisVertical = "P1Vertical" ;
            fire = "Fire1";
        }
        if (gameObject.tag == "P2")
        {
            movementAxisHorizontal = "P2Horizontal";
            movementAxisVertical = "P2Vertical";
            fire = "Fire2";
        }

        if (barrel == 0)
        {
            delaySpan = 5;
            Delay = 0;
            currentBullet = Sniper;
        }
        if (barrel == 1)
        {
            delaySpan = 3;
            Delay = 0;
            currentBullet = Shotgun;
        }
        if (barrel == 2)
        {
            delaySpan = .1f;
            Delay = 0;
            currentBullet = MachineGun;
        }
    }
	
	// Update is called once per frame
	void Update () {

    
        position.x += Input.GetAxis (movementAxisHorizontal) * CarSpeed * Time.deltaTime;
        position.z += Input.GetAxis(movementAxisVertical) * CarSpeed * Time.deltaTime;
        transform.position = new Vector3(position.x, transform.position.y, position.z);
        if (Input.GetButtonDown(fire))
            shooting = true;
        if (Input.GetButtonUp(fire))
            shooting = false;
        if (shooting && (Delay <= 0))
        {
            GameObject Bullet = (GameObject)Instantiate(currentBullet, new Vector3(position.x, position.y, position.z + 10), Quaternion.identity);
            Bullet.GetComponent<bullet>().Owner = this.gameObject;
            if (barrel == 1)
            {
                for(int i = 1; i < 3; i++)
                {
                    GameObject exPosBullet = (GameObject)Instantiate(currentBullet, new Vector3(position.x + (5 * i), position.y, position.z + 10), Quaternion.identity);
                    exPosBullet.GetComponent<bullet>().Owner = this.gameObject;
                    GameObject exNegBullet = (GameObject)Instantiate(currentBullet, new Vector3(position.x - (5 * i), position.y, position.z + 10), Quaternion.identity);
                    exNegBullet.GetComponent<bullet>().Owner = this.gameObject;
                }
            }
            Delay = delaySpan;
        }
        Delay -= Time.deltaTime;
	}
}
