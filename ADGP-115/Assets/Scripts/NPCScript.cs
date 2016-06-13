using UnityEngine;
using System.Collections;

public class NPCScript : MonoBehaviour {

    public GameObject OtherTank1;   //GameObject used to reference the First Player Tank.
    public GameObject OtherTank2;   //GameObject used to reference the second tank besides itself.
    public GameObject OtherTank3;   //GameObject used to reference the third tank besides itself.
    public GameObject HealthP1; //A GameObject used to reference the first Health pickup.
    public GameObject HealthP2; //A GameObject used to reference the second Health pickup.
    public GameObject SpeedP1;  //A GameObject used to reference the first Speed pickup.
    public GameObject SpeedP2;  //A GameObject used to reference the second Speed pickup.
    public GameObject RocketP;   //A GameObject used to reference the Rocket pickup.
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
    float lowestDist = 0;   //A float to hold the lowest value distance between the tank this script is attached to and another object.
    Vector3 closestPos = new Vector3(0, 0, 0);  //The position of the tank closest to the tank this script is attached to.
    Vector3 closestPiUP = new Vector3(0, 0, 0); //The position of the pickup closest to this tank.
    GameObject Destination; //A GameObject called Destination that is determined near the end of the Update function.
    GameObject chosenPiUP;  //A GameObject to reference the pickup that is chosen as the Destination in a non-direct manner for ease.
    GameObject chosenTank;  //A GameObject to reference the Tank that is chosen as the Destination in a non-direct manner for ease.
    bool PiUP_Priority = false; //A bool to have the script understand if the Destination should be a Pickup or a Tank.
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (Destination == null)
        {
            lowestDist = Vector3.Distance(OtherTank1.transform.position, transform.position);   //Sets the lowestDist to the Distance between this tank and OtherTank1
            closestPos = OtherTank1.transform.position; //Sets OtherTank1's position to the closestPos
            chosenTank = OtherTank1;
        }
        if ((lowestDist > Vector3.Distance(OtherTank2.transform.position, transform.position)) && (Destination == null))   //Checks to see if the Distance between this tank and OtherTank2 is lower than the current lowestDist
        {
            lowestDist = Vector3.Distance(OtherTank2.transform.position, transform.position);   //If so, sets the lowestDist to be the Distance between this tank and OtherTank2
            closestPos = OtherTank2.transform.position; //Sets OtherTank2's position to the closestPos
            chosenTank = OtherTank2;
        }
        if ((lowestDist > Vector3.Distance(OtherTank3.transform.position, transform.position)) && (Destination == null))   //Checks to see if the Distance between this tank and OtherTank3 is lower than the current lowestDist
        {
            lowestDist = Vector3.Distance(OtherTank3.transform.position, transform.position);   //If so, sets the lowestDist to be the Distance between this tank and OtherTank3
            closestPos = OtherTank3.transform.position; //Sets OtherTank3's position to the closestPos
            chosenTank = OtherTank3;
        }
        if (((60 > Vector3.Distance(SpeedP1.transform.position, transform.position)) && (lowestDist > 40)) && (Destination == null))
        {
            lowestDist = Vector3.Distance(SpeedP1.transform.position, transform.position);
            closestPiUP = SpeedP1.gameObject.transform.position;
            PiUP_Priority = true;
            chosenPiUP = SpeedP1;
        }
        if (((60 > Vector3.Distance(SpeedP2.transform.position, transform.position)) && (lowestDist > 40)) && (Destination == null))
        {
            lowestDist = Vector3.Distance(SpeedP2.transform.position, transform.position);
            closestPiUP = SpeedP2.gameObject.transform.position;
            PiUP_Priority = true;
            chosenPiUP = SpeedP2;
        }
        if ((RocketP != null) && (Destination == null))
        {
            closestPiUP = RocketP.transform.position;
            PiUP_Priority = true;
            chosenPiUP = RocketP;
        }
        if ((Health <= 60) && (Destination == null))
        {
            lowestDist = Vector3.Distance(HealthP1.transform.position, transform.position);
            closestPiUP = HealthP1.transform.position;
            PiUP_Priority = true;
            chosenPiUP = HealthP1;
        }
        if (((Health <= 60) && (lowestDist > Vector3.Distance(HealthP2.transform.position, transform.position))) && (Destination == null))
        {
            lowestDist = Vector3.Distance(HealthP2.transform.position, transform.position);
            closestPiUP = HealthP2.transform.position;
            PiUP_Priority = true;
            chosenPiUP = HealthP2;
        }
        if (PiUP_Priority)
            Destination = chosenPiUP;
        else
            Destination = chosenTank;
    }
}
