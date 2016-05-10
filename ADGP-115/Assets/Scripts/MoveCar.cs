using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour
{
    public float CarSpeed = 50.0f;
    Vector3 position;


    string movementAxisHorizontal;
    string movementAxisVertical;
    string fire;
    public GameObject bullet;
    bool shooting = false;

    // Use this for initialization
    void Start () {
        position = transform.position;
        if (gameObject.tag == "P1")
        {
            movementAxisHorizontal = "P1Horizontal" ;
            movementAxisVertical = "P1Vertical" ;
            fire = "Fire1";
        }
        if (gameObject.tag == "P2")
        {
            movementAxisHorizontal = "P2Horizontal";
            movementAxisVertical = "P2Vertical";
            fire = "Fire2";
        }

    }
	
	// Update is called once per frame
	void Update () {

    
        position.x += Input.GetAxis (movementAxisHorizontal) * CarSpeed * Time.deltaTime;
        position.z += Input.GetAxis(movementAxisVertical) * CarSpeed * Time.deltaTime;
        transform.position = new Vector3(position.x, transform.position.y, position.z);
        if (Input.GetButtonDown(fire))
            shooting = true;
        if (Input.GetButtonUp(fire))
            shooting = false;
        if (shooting)
        {
            Instantiate(bullet, new Vector3(position.x + 10 ,position.y, position.z), Quaternion.identity);
        }
	}
}
