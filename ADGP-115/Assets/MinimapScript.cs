using UnityEngine;
using System.Collections;

public class MinimapScript : MonoBehaviour {

    public GameObject Player1;
    public GameObject Player2;
    public GameObject HealthP1;
    public GameObject HealthP2;
    public GameObject SpeedP1;
    public GameObject SpeedP2;
    public GameObject RocketP;

    public GameObject MapPlayer1;
    public GameObject MapPlayer2;
    public GameObject MapHealth1;
    public GameObject MapHealth2;
    public GameObject MapSpeed1;
    public GameObject MapSpeed2;
    public GameObject MapRocket;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (this.gameObject.GetComponent<Camera>().enabled == true)
                this.gameObject.GetComponent<Camera>().enabled = false;
            else
                this.gameObject.GetComponent<Camera>().enabled = true;
        }
	}
}
