using UnityEngine;
using System.Collections;

public class powerup : MonoBehaviour {

    Vector3 position;
    private float speed = 6;
    public bool fly = true;
    public float Delay;
    public GameObject Owner;
    public int powerNum;

    // Use this for initialization
    void Start () {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {


        
        Delay += Time.deltaTime;
        //the following block of code makes the powerups appear to float
        if (Delay >= 0.5f)
        {
            Delay = 0;
            fly = !fly;
        }
        if (fly == true)
            position.y +=  Time.deltaTime * speed;
        if (fly == false)
            position.y -=  Time.deltaTime * speed;
        transform.position = new Vector3(position.x, position.y, position.z);

    }
    void OnTriggerEnter(Collider enemy) //allows the powerup to be picked up on collision.
    {
        if (enemy.gameObject.GetComponent<MoveCar>())
        {

            if (powerNum == 0)//this is the effects of the Boost powerup
            {
                if (enemy.gameObject != Owner)
                {
                    Owner.GetComponent<Spawner>().PUexists = false;//Works with the spawner object to control the location of the powerup
                    Owner = enemy.gameObject;
                    Owner = enemy.gameObject;
                    Owner.GetComponent<MoveCar>().GasTank = 1;
                    Owner.GetComponent<MoveCar>().powerup.Play();
                    Destroy(this.gameObject);
                }
            }

            if (powerNum == 1) //this is the effects of the health pack powerup
            {
                if (enemy.gameObject != Owner)
                {
                    Owner.GetComponent<Spawner>().PUexists = false;//Works with the spawner object to control the location of the powerup
                    Owner = enemy.gameObject;
                    Owner = enemy.gameObject;
                    Owner.GetComponent<MoveCar>().Health += 30; //calculation for the health pack
                    if (Owner.GetComponent<MoveCar>().Health >= 100)
                        Owner.GetComponent<MoveCar>().Health = 100;
                    Owner.GetComponent<MoveCar>().powerup.Play();
                    Destroy(this.gameObject);
                }
            }
            if (powerNum == 2)//this is the effects of the Rocket powerup
            {
                if (enemy.gameObject != Owner)
                {
                    Owner.GetComponent<Spawner>().PUexists = false; //Works with the spawner object to control the location of the powerup
                    Owner = enemy.gameObject;
                    Owner.GetComponent<MoveCar>().HasRocket = true;
                    Owner.GetComponent<MoveCar>().powerup.Play();
                    Destroy(this.gameObject);
                }
            }
        }
    }





}
