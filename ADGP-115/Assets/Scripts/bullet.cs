using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    float bulletSpeed = 50f;
    float lifespan = .8f;
    public GameObject Bullet;
    public GameObject Owner;
    Vector3 position;
	// Use this for initialization
	void Start () {
        if (Bullet.name == "SniperB(Clone)")
        {
            lifespan = 4;
            bulletSpeed = 800;
        }
        if (Bullet.name == "ShotgunB(Clone)")
        {
            lifespan = 1f;
            bulletSpeed = 100;
        }
        if (Bullet.name == "MachineGunB(Clone)")
        {
            lifespan = 2.5f;
            bulletSpeed = 100;
        }
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * (bulletSpeed * Time.deltaTime));
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
                if (Bullet.name == "SniperB(Clone)")
                    Owner.GetComponent<MoveCar>().Health -= 50;
                else if (Bullet.name == "ShotgunB(Clone)")
                    Owner.GetComponent<MoveCar>().Health -= 10;
                else if (Bullet.name == "MachineGunB(Clone)")
                    Owner.GetComponent<MoveCar>().Health -= 1;
            }
            Debug.Log("collision");
            Destroy(this.gameObject);
        }
    }
}
