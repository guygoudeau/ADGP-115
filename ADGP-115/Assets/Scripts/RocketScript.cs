using UnityEngine;
using System.Collections;

public class RocketScript : MonoBehaviour {

    float bulletSpeed = 200f;
    float lifespan = 4f;
    public GameObject Owner;
    // Use this for initialization
    void Start () {
        transform.position = Owner.transform.position;
        this.transform.rotation = Owner.transform.rotation;
        transform.Rotate(90 * Vector3.right);
        transform.Translate(Vector3.up * 20);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * (bulletSpeed * Time.deltaTime));
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject != Owner)
        {
            Owner = enemy.gameObject;
            if (enemy.gameObject.GetComponent<MoveCar>())
            {
                Owner.GetComponent<MoveCar>().rocket.Play();
                Owner.GetComponent<MoveCar>().Health -= 80;
            }
            Destroy(this.gameObject);
        }
    }
}
