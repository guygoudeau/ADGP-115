using UnityEngine;
using System.Collections;

public class NPCScript : MonoBehaviour {

    public GameObject OtherTank1;   //GameObject used to reference the First Player Tank.

    public GameObject OtherTank2;   //GameObject used to reference the second tank besides itself.

    public GameObject OtherTank3;   //GameObject used to reference the third tank besides itself.
    public float CarSpeed = 1.0f;
    float BaseSpeed = 0.0f;
    public bool HasRocket = false;
    public float Health = 100;
    public int GasTank = 0;
    public GameObject Sniper;
    public GameObject Shotgun;
    public GameObject MachineGun;
    public GameObject Rocket;
    public int barrel = 0;
    float delaySpan = 1;
    float Delay = 1;
    public float Boost;
    public bool BoostCurrent = false;
    public GameObject currentBullet;
    bool alive = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
