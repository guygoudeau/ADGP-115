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
        if (chainsawsound.isPlaying)
        {
            if (chainsawsound.time >= 11.0)
            {
                chainsawsound.Stop();
            }
        }
	}

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.GetComponent<MoveCar>())
        {
            chainsawsound.time = 4.0f;
            chainsawsound.Play();
        }
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
                        if (chainsawsound.time >= 9.0f)
                            chainsawsound.time = 6.0f;
                        enemy.GetComponent<MoveCar>().Health -= .5f;
                    }
            }
        }
    }

    void OnTriggerExit(Collider enemy)
    {
        if (enemy.GetComponent<MoveCar>())
            chainsawsound.time = 9.0f;
    }
}
