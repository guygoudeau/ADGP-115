using UnityEngine;
using System.Collections;

public class MinimapScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (this.gameObject.GetComponent<Camera>().enabled == true)
                this.gameObject.GetComponent<Camera>().enabled = false;
            else
                this.gameObject.GetComponent<Camera>().enabled = true;
        }
	}
}
