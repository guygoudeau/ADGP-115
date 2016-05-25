using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject PowerUp;

    public bool PUexists = false;

    float delay = 0;

    float delayTotal = 0;

	// Use this for initialization
	void Start () {
        if (PowerUp.GetComponent<powerup>().powerNum == 0)
            delayTotal = 20;
        if (PowerUp.GetComponent<powerup>().powerNum == 1)
            delayTotal = 30;
        if (PowerUp.GetComponent<powerup>().powerNum == 2)
            delayTotal = 60;
        GameObject powerup = (GameObject)Instantiate(PowerUp, transform.position, Quaternion.identity);
        powerup.GetComponent<powerup>().Owner = this.gameObject;
        delay = 0;
        PUexists = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!PUexists)
            delay += Time.deltaTime;
        if (delay >= delayTotal)
        {
            GameObject powerup = (GameObject)Instantiate(PowerUp, transform.position, Quaternion.identity);
            powerup.GetComponent<powerup>().Owner = this.gameObject;
            delay = 0;
            PUexists = true;
        }

    }
}
