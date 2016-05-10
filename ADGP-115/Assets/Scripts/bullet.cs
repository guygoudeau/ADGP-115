using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    float bulletSpeed = 70.0f;
    float lifespan = .8f;
    public GameObject Bullet;
    Vector3 position;
	// Use this for initialization
	void Start () {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3 (transform.position.x + (Time.deltaTime * bulletSpeed), position.y, position.z);
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
            Destroy(Bullet);
	}
}
