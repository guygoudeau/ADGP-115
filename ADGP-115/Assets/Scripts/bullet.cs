using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    float bulletSpeed = 50f;
    float lifespan = .8f;
    public GameObject Bullet;
    public GameObject Owner;
	// Use this for initialization
	void Start () {
        if (Bullet.name == "SniperB(Clone)")
        {
            lifespan = 4;
            bulletSpeed = 13.4f;
        }
        if (Bullet.name == "ShotgunB(Clone)")
        {
            lifespan = 1f;
            bulletSpeed = 1.7f;
        }
        if (Bullet.name == "MachineGunB(Clone)")
        {
            lifespan = 2.5f;
            bulletSpeed = 1.7f;
        }
        this.transform.rotation = Owner.transform.rotation;
        transform.Translate(Vector3.forward * 10);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * ((bulletSpeed * Owner.GetComponent<MoveCar>().CarSpeed) * Time.deltaTime));
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
            Destroy(Bullet);
	}

    void OnTriggerEnter (Collider enemy)
    {
        if (enemy.gameObject != Owner)
        {
            Owner = enemy.gameObject;
            if (enemy.gameObject.GetComponent<MoveCar>())
            {
                Owner.GetComponent<MoveCar>().takedamage.Play();
                if (Bullet.name == "SniperB(Clone)")
                    Owner.GetComponent<MoveCar>().Health -= 30;
                else if (Bullet.name == "ShotgunB(Clone)")
                    Owner.GetComponent<MoveCar>().Health -= 10;
                else if (Bullet.name == "MachineGunB(Clone)")
                    Owner.GetComponent<MoveCar>().Health -= 2;
            }
            Debug.Log("collision");
            Destroy(this.gameObject);
        }
    }
}
