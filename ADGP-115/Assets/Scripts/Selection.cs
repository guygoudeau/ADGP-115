using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selection : MonoBehaviour {

    public GameObject Player;

    public int p1Barrel = 2;

    public int p2Barrel = 2;

    public GameObject DesertArena;

    public GameObject GrassArena;

    public GameObject IceArena;

    public GameObject FutureArena;

    GameObject currentArena;

    // Use this for initialization
    void Start () {
        currentArena = GrassArena;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void p1Sniper()
    {
        p1Barrel = 0;
    }

    public void p2Sniper()
    {
        p2Barrel = 0;
    }

    public void p1Shotgun()
    {
        p1Barrel = 1;
    }

    public void p2Shotgun()
    {
        p2Barrel = 1;
    }

    public void p1MachineG()
    {
        p1Barrel = 2;
    }

    public void p2MachineG()
    {
        p2Barrel = 2;
    }

    public void p1Chainsaw()
    {
        p1Barrel = 3;
    }

    public void p2Chainsaw()
    {
        p2Barrel = 3;
    }

    public void SelectDesert()
    {
        currentArena = DesertArena;
    }

    public void SelectGrass()
    {
        currentArena = GrassArena;
    }

    public void SelectIce()
    {
        currentArena = IceArena;
    }

    public void SelectFuture()
    {
        currentArena = FutureArena;
    }

    public void Finish()
    {
        Instantiate(currentArena);
        // Creating Player1
        GameObject Player1 = (GameObject)Instantiate(Player, new Vector3(0, 5, -120), Quaternion.identity);
        Player1.GetComponent<MoveCar>().barrel = p1Barrel;
        Player1.tag = "P1";
        Player1.name = "Player 1";
        // Creating Player2 
        GameObject Player2 = (GameObject)Instantiate(Player, new Vector3(0, 5, 50), Quaternion.identity);
        Player2.GetComponent<MoveCar>().barrel = p2Barrel;
        Player2.tag = "P2";
        Player2.name = "Player 2";

        


        if (GameObject.Find("Player Camera").transform.parent.gameObject)
            Debug.Log("boop");
        Component[] sliders = transform.GetComponentInParent<Transform>().parent.GetComponentsInChildren<Slider>();
        foreach (Slider hb in sliders)
        {
            if (hb.name == "P1Slider")
                Player1.GetComponent<MoveCar>().healthSlider = hb;
            else if (hb.name == "P2Slider")
                Player2.GetComponent<MoveCar>().healthSlider = hb;
        }
        Component[] texts = transform.GetComponentInParent<Transform>().parent.GetComponentsInChildren<Text>();
        foreach(Text weapon in texts)
        {
            if (weapon.name == "P1Weapon")
                Player1.GetComponent<MoveCar>().currentWeapon = weapon;
            else if (weapon.name == "P2Weapon")
                Player2.GetComponent<MoveCar>().currentWeapon = weapon;
        }
        Component[] cameras = this.transform.GetComponentsInChildren<Camera>();
        foreach(Camera sc in cameras)
        {
            if (sc.name == "SelectionCamera")
                sc.gameObject.SetActive(false);
        }
        Component[] listeners = transform.GetComponentInParent<Transform>().parent.GetComponentsInChildren<AudioListener>();
        foreach (AudioListener al in listeners)
            if (al.name == "AudioListener")
                al.enabled = true;
        this.transform.GetComponentInParent<Transform>().gameObject.SetActive(false);
    }
}
