using UnityEngine;
using System.Collections;

public class powerup : MonoBehaviour {

    Vector3 position;
    private float speed = 6;
    public bool fly = true;
    public float Delay;
    public float yoffset;
    public GameObject Owner;

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
        transform.position = new Vector3(position.x, position.y + yoffset, position.z);

    }
    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject != Owner)
        {
           Owner = enemy.gameObject;
           Owner.GetComponent<MoveCar>().GasTank = 1;
           Destroy(this.gameObject);
        }
    }





}
