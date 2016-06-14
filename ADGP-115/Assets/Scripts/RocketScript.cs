using UnityEngine;
using System.Collections;

public class RocketScript : MonoBehaviour {

    float bulletSpeed = 200f;   //A float variable that determines how far the GameObject this script it attached to, which is usually the RocketB GameObject, will translate per update.
    float lifespan = 4f;    //A float variable that determines how many seconds the RocketB has to exist until it is destroyed.
    public GameObject Owner;    //A GameObject variable that allows for a publisher and subscriber relationship between the RocketB and Players.
    // Use this for initialization
    void Start () {
        this.transform.rotation = Owner.transform.rotation; //Sets the RocketB's rotation to the rotation of the Owner.
        transform.Translate(Vector3.forward * 20);   //Translates the RocketB 20 units so that is ahead of the Owner and does not collide with the Owner that spawned it right when the RocketB is created.
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * (bulletSpeed * Time.deltaTime));   //Translates the RocketB up by the bulletspeed times deltaTime.
        lifespan -= Time.deltaTime; //Decrements the lifespan variable by deltaTime for every Update.
        if (lifespan <= 0)  //Checks to see if the lifespan variable is less than or equal to 0. If so, then the RocketB is destroyed.
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider enemy) //A function that is called when the RocketB enters another GameObject.
    {
        if (enemy.gameObject != Owner)  //Checks to see if the enemy GameObject is not the RocketB's Owner. If it isn't it sets the enemy GameObject as the RocketB's new Owner.
        {
            Owner = enemy.gameObject;
            if (enemy.gameObject.GetComponent<MoveCar>())   //Checks to see if the enemy GameObject has the MoveCar script, indicating whether or not the enemy GameObject is a Player GameObject.
            {
                Owner.GetComponent<MoveCar>().rocket.Play();    //Plays the rocket audioclip that the Owner has.
                Owner.GetComponent<MoveCar>().Health -= 80;     //Decrements the Owner's Health variable by 80.
            }
            Destroy(this.gameObject);   //Destroys the RocketB.
        }
    }
}
