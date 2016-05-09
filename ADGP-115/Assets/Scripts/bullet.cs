using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    float bulletSpeed = 70.0f;
    GameObject Bullet;
    Vector3 position;
	// Use this for initialization
	void Start () {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
    transform.position = new Vector3 (transform.position.x * Time.deltaTime * bulletSpeed, position.y, position.z);
	}
}
