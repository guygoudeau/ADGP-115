using UnityEngine;
using System.Collections;

public class ChainsawScript : MonoBehaviour {
    public GameObject Owner;
    public AudioSource chainsawsound;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerStay(Collider enemy)
    {
        if (Owner.GetComponent<MoveCar>().Health > 0)
        {
            if (Owner.GetComponent<MoveCar>().barrel == 3)
            {
                if (enemy.gameObject != Owner)
                    if (enemy.gameObject.GetComponent<MoveCar>())
                    {
                        enemy.GetComponent<MoveCar>().Health -= .5f;
                    }
            }
        }
    }
}
