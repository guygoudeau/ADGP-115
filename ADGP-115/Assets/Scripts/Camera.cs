using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {


    Quaternion Rotation;
    // Use this for initialization
    void Start () {

        Rotation = gameObject.transform.rotation;
        Rotation.x = 0;
        Rotation.y = 0;
        Rotation.z = 0;
    }
	
	// Update is called once per frame
	void Update () {

        
        
        transform.rotation = new Quaternion(0,Rotation.x, Rotation.y, Rotation.z);
    }
}
