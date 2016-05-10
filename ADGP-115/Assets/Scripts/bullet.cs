using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    float bulletSpeed = 50f;
    float lifespan = .8f;
    public GameObject Bullet;
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
            lifespan = .7f;
            bulletSpeed = 100;
        }
        if (Bullet.name == "MachineGunB(Clone)")
        {
            lifespan = 1;
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
        if (enemy.gameObject.name == "p2" && Bullet.name == "SniperB(Clone)")
            enemy.gameObject.GetComponent<MoveCar>().Health -= 50;
        else if (enemy.gameObject.name == "p2" && Bullet.name == "ShotgunB(Clone)")
            enemy.gameObject.GetComponent<MoveCar>().Health -= 10;
        else if (enemy.gameObject.name == "p2" && Bullet.name == "MachineGunB(Clone)")
            enemy.gameObject.GetComponent<MoveCar>().Health--;
    }
}
