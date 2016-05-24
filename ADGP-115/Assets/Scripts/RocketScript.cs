using UnityEngine;
using System.Collections;

public class RocketScript : MonoBehaviour {

    float bulletSpeed = 800f;
    float lifespan = 4f;
    public GameObject Owner;
    // Use this for initialization
    void Start () {
        this.transform.rotation = Quaternion.Euler(Owner.transform.rotation.x, Owner.transform.rotation.z, 90);
        transform.Translate(Vector3.forward * 10);
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
                Owner.GetComponent<MoveCar>().Health -= 80;
            }
            Debug.Log("collision");
            Destroy(this.gameObject);
        }
    }
}
