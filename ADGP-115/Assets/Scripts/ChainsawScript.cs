using UnityEngine;
using System.Collections;

public class ChainsawScript : MonoBehaviour {
    public GameObject Owner;    //A GameObject variable that acts as an easier way to refer to the Player it's attacked to.
    public AudioSource chainsawsound;   //An AudioSource variable used to play the chainsaw audioclip.
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (chainsawsound.isPlaying)    //An if statement that checks if the chainsaw audioclip is being played with the audiosource.
        {
            if (chainsawsound.time >= 11.0) //An if statement that checks if the current is greater than or equal to 11 seconds into the audioclip. If so, the audioclip will be stopped.
            {
                chainsawsound.Stop();
            }
        }
	}

    void OnTriggerEnter(Collider enemy) //A function that is called when the Owner's barrel enters a rigidbody.
    {
        if (Owner.GetComponent<MoveCar>().barrel == 3)  //Checks to see if the Owner's barrel is a chainsaw.
        {
            if (enemy.GetComponent<MoveCar>())  //If the object the Owner's barrel entered has a MoveCar script, it starts playing the chainsawsound audioclip at four seconds.
            {
                chainsawsound.time = 4.0f;
                chainsawsound.Play();
            }
        }
    }

    void OnTriggerStay(Collider enemy)  //A function that is called when the Owner's barrel of the Owner stays in a rigidbody.
    {
        if (Owner.GetComponent<MoveCar>().Health > 0)   //Checks if the Owner's health is greater than zero. If not it will skip the code within the statement's brackets.
        {
            if (Owner.GetComponent<MoveCar>().barrel == 3)  //Checks to see if the Owner's barrel is a chainsaw.
            {
                if (enemy.gameObject != Owner)  //Checks to see if the rigidbody that the Owner's barrel is in is not the Owner.
                    if (enemy.gameObject.GetComponent<MoveCar>())   //Checks to see if the enemy object has the MoveCar script, indicating if it is a player or not.
                    {
                        if (chainsawsound.time >= 9.0f) //Checks to see if the timd of the audioclip is 9 seconds or more. If so, it sets the time of the audioclip to the 6 second mark.
                            chainsawsound.time = 6.0f;
                        enemy.GetComponent<MoveCar>().Health -= .5f;    //Decrements the Health variable of the enemy object by .5
                    }
            }
        }
    }

    void OnTriggerExit(Collider enemy)  //A function that is called when the Owner's barrel exits the enemy rigidbody.
    {
        if (Owner.GetComponent<MoveCar>().barrel == 3)  //Checks to see if the Owner's barrel is a chainsaw.
        {
            if (enemy.GetComponent<MoveCar>())  //If the enemy object contains the MoveCar script then set the chainsawsound audioclip time to the 9 second mark.
                chainsawsound.time = 9.0f;
        }
    }
}
