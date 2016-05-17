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
        if (Owner.GetComponent<MoveCar>().barrel == 3)
        {
            if (enemy.gameObject != Owner)
                if (enemy.gameObject.GetComponent<MoveCar>())
                {
                    enemy.GetComponent<MoveCar>().Health -= .2f;
                }
        }
    }
}
