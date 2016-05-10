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
            bulletSpeed = 800;
        if (Bullet.name == "ShotgunB(Clone)")
            bulletSpeed = 100;
        if (Bullet.name == "MachineGunB(Clone)")
            bulletSpeed = 100;
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
        if (enemy.gameObject.name == "p2")
            enemy.gameObject.GetComponent<MoveCar>.health--;
    }
}
