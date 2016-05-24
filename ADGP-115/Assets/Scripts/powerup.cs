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
    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.GetComponent<MoveCar>())
        {

            if (powerNum == 0)
            {
                if (enemy.gameObject != Owner)
                {
                    Owner = enemy.gameObject;
                    Owner.GetComponent<MoveCar>().GasTank = 1;
                    Destroy(this.gameObject);
                }
            }

            if (powerNum == 1)
            {
                if (enemy.gameObject != Owner)
                {
                    Owner = enemy.gameObject;
                    Owner.GetComponent<MoveCar>().Health += 30;
                    if (Owner.GetComponent<MoveCar>().Health >= 100)
                        Owner.GetComponent<MoveCar>().Health = 100;
                    Destroy(this.gameObject);
                }
            }
            if (powerNum == 2)
            {
                if (enemy.gameObject != Owner)
                {
                    Owner = enemy.gameObject;
                    Owner.GetComponent<MoveCar>().HasRocket = true;
                    Destroy(this.gameObject);
                }
            }
        }
    }





}
