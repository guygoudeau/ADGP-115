using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    float bulletSpeed = 50f;    //A float variable for the bullet's speed.
    float lifespan = .8f;   //A float variable that represents how many seconds will pass before the bullet destroys itself.
    public GameObject Bullet;   //A GameObject that allows for the script to directly reference it's parent.
    public GameObject Owner;    //A GameObject variable that allows for a publisher and subscriber relationship between the Bullet GameObject and Players.
	// Use this for initialization
	void Start () {
        if (Bullet.name == "SniperB(Clone)")    //If the Bullet is an instantiated version of a SniperB prefab, then it's lifespan is set to 4 seconds and it's personal speed is 13.4.
        {
            lifespan = 4;
            bulletSpeed = 13.4f;
        }
        if (Bullet.name == "ShotgunB(Clone)")   //If the Bullet is an instantiated version of a ShotgunB prefab, then it's lifespan is set to 1 second and it's personal speed is 1.7.
        {
            lifespan = .5f;
            bulletSpeed = 3.7f;
        }
        if (Bullet.name == "MachineGunB(Clone)")    //If the Bullet is an instantiated version of a MachineGunB prefab, then it's lifespan is set to 2.5 seconds and it's personal speed is 1.7.
        {
            lifespan = 2.5f;
            bulletSpeed = 1.7f;
        }
        this.transform.rotation = Owner.transform.rotation; //Sets it's rotation to the Owner object, which at this point would be the Player that spawned it.
        transform.Translate(Vector3.forward * 10);  //Translates the bullet to be ten units forward so it doesn't collide with the Owner's barrel.
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * ((bulletSpeed * Owner.GetComponent<MoveCar>().CarSpeed) * Time.deltaTime));   //Translates the bullet forward by the bulletSpeed multiplied by the Owner's carspeed and deltaTime. This ensures the bullet will pretty much travel the same speed on any computer and that it will always be faster than the Player.
        lifespan -= Time.deltaTime; //Decrements the lifespan by the current deltaTime every update.
        if (lifespan <= 0)  //If the lifespan reaches zero or goes lower than zero then the Bullet GameObject is destroyed.
            Destroy(Bullet);
	}

    void OnTriggerEnter (Collider enemy)    //Function that gets called on collision with an object with a rigidbody.
    {
        if (enemy.gameObject != Owner)  //Ignores the object if it is already it's owner. Otherwise it performs the following code.
        {
            Owner = enemy.gameObject;   //Changes the Owner to the enemy object.
            if (enemy.gameObject.GetComponent<MoveCar>())   //Checks to see if the enemy object has the MoveCar script. If it does it performs the code in the if statement's brackets.
            {
                Owner.GetComponent<MoveCar>().takedamage.Play();    //Plays an audioclip for taking damage that the Owner has.
                if (Bullet.name == "SniperB(Clone)")    //If the Bullet is a clone of the SniperB prefab, it decrements the Owner's Health variable by 30.
                    Owner.GetComponent<MoveCar>().Health -= 30;
                else if (Bullet.name == "ShotgunB(Clone)")  //If the Bullet is a clone of the ShotgunB prefab, it decrements the Owner's Health variable by 10.
                    Owner.GetComponent<MoveCar>().Health -= 12;
                else if (Bullet.name == "MachineGunB(Clone)")   //If the Bullet is a clone of the MachineGunB prefab, it decrements the Owner's Health variable by 2.
                    Owner.GetComponent<MoveCar>().Health -= 2;
            }
            Destroy(this.gameObject);   //Regardless of whether or not the object is a player object, the Bullet is destroyed.
        }
    }
}
