using UnityEngine;
using System.Collections;

public class ChainsawScript : MonoBehaviour {
    public GameObject Owner; 
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider enemy)
    {
        if (enemy.gameObject != Owner)
        {
            enemy.GetComponent<MoveCar>().Health -= 1;
        }
    }
}
