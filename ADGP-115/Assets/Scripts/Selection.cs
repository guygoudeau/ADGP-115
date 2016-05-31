using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selection : MonoBehaviour {

    public GameObject Player;

    public int p1Barrel = 2;

    public int p2Barrel = 2;

    public GameObject GrassArena;

    public GameObject IceArena;

    public GameObject FutureArena;

    GameObject currentArena;

    public GameObject RocketPowerup;

    public GameObject HealthPowerup;

    public GameObject BoostPowerup;

    public AudioSource select;

    public int P1currentColor = 6;
    public int P2currentColor = 6;

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
        select.Play();
    }
    public void p2Sniper()
    {
        p2Barrel = 0;
        select.Play();
    }
    public void p1Shotgun()
    {
        p1Barrel = 1;
        select.Play();
    }
    public void p2Shotgun()
    {
        p2Barrel = 1;
        select.Play();
    }
    public void p1MachineG()
    {
        p1Barrel = 2;
        select.Play();
    }
    public void p2MachineG()
    {
        p2Barrel = 2;
        select.Play();
    }
    public void p1Chainsaw()
    {
        p1Barrel = 3;
        select.Play();
    }
    public void p2Chainsaw()
    {
        p2Barrel = 3;
        select.Play();
    }

    public void SelectGrass()
    {
        currentArena = GrassArena;
        select.Play();
    }
    public void SelectIce()
    {
        currentArena = IceArena;
        select.Play();
    }
    public void SelectFuture()
    {
        currentArena = FutureArena;
        select.Play();
    }

    public void P1Blue()
    {
        P1currentColor = 1;
        select.Play();
    }
    public void P1Red()
    {
        P1currentColor = 2;
        select.Play();
    }
    public void P1Green()
    {
        P1currentColor = 3;
        select.Play();
    }
    public void P1Yellow()
    {
        P1currentColor = 4;
        select.Play();
    }
    public void P1White()
    {
        P1currentColor = 5;
        select.Play();
    }
    public void P1Black()
    {
        P1currentColor = 6;
        select.Play();
    }

    public void P2Blue()
    {
        P2currentColor = 1;
        select.Play();
    }
    public void P2Red()
    {
        P2currentColor = 2;
        select.Play();
    }
    public void P2Green()
    {
        P2currentColor = 3;
        select.Play();
    }
    public void P2Yellow()
    {
        P2currentColor = 4;
        select.Play();
    }
    public void P2White()
    {
        P2currentColor = 5;
        select.Play();
    }
    public void P2Black()
    {
        P2currentColor = 6;
        select.Play();
    }

    public void Finish()
    {
        select.Play();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject arena = Instantiate(currentArena);
        var starts = arena.GetComponentsInChildren<Transform>();

        // Creating Player1
        GameObject Player1 = (GameObject)Instantiate(Player, new Vector3(0, 5, -120), Quaternion.identity);
        Player1.GetComponent<MoveCar>().barrel = p1Barrel;
        Player1.tag = "P1";
        Player1.name = "Player 1";
        if (P1currentColor == 1)
        {
            Player1.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (P1currentColor == 2)
        {
            Player1.GetComponent<Renderer>().material.color = Color.red;
        }
        if (P1currentColor == 3)
        {
            Player1.GetComponent<Renderer>().material.color = Color.green;
        }
        if (P1currentColor == 4)
        {
            Player1.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (P1currentColor == 5)
        {
            Player1.GetComponent<Renderer>().material.color = Color.white;
        }
        if (P1currentColor == 6)
        {
            Player1.GetComponent<Renderer>().material.color = Color.black;
        }
        
        // Creating Player2 
        GameObject Player2 = (GameObject)Instantiate(Player, new Vector3(0, 5, 50), Quaternion.identity);
        Player2.GetComponent<MoveCar>().barrel = p2Barrel;
        Player2.tag = "P2";
        Player2.name = "Player 2";
        if (P2currentColor == 1)
        {
            Player2.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (P2currentColor == 2)
        {
            Player2.GetComponent<Renderer>().material.color = Color.red;
        }
        if (P2currentColor == 3)
        {
            Player2.GetComponent<Renderer>().material.color = Color.green;
        }
        if (P2currentColor == 4)
        {
            Player2.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (P2currentColor == 5)
        {
            Player2.GetComponent<Renderer>().material.color = Color.white;
        }
        if (P2currentColor == 6)
        {
            Player2.GetComponent<Renderer>().material.color = Color.black;
        }
        Player2.GetComponentInChildren<Camera>().rect = new Rect(.5f, 0, .5f, 1);

        foreach (var st in starts)
        {
            if (st.gameObject.name == "P1Start")
            {
                Player1.transform.position = st.position;
                Player1.transform.rotation = st.rotation;
            }
            if (st.gameObject.name == "P2Start")
            {
                Player2.transform.position = st.position;
                Player2.transform.rotation = st.rotation;
            }
            if (st.gameObject.name == "Rspawn")
                st.gameObject.GetComponent<Spawner>().PowerUp = RocketPowerup;
            if (st.gameObject.name == "Hspawn1" || st.gameObject.name == "Hspawn2")
                st.gameObject.GetComponent<Spawner>().PowerUp = HealthPowerup;
            if (st.gameObject.name == "Bspawn1" || st.gameObject.name == "Bspawn2")
                st.gameObject.GetComponent<Spawner>().PowerUp = BoostPowerup;
        }

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
        foreach(Transform ws in transform.GetComponentInParent<Transform>().parent.GetComponentsInChildren<Transform>())
        {
            if (ws.gameObject.name == "P1Win")
            {
                Player2.GetComponent<MoveCar>().winScreen = ws;
                ws.gameObject.SetActive(false);
            }
            if (ws.gameObject.name == "P2Win")
            {
                Player1.GetComponent<MoveCar>().winScreen = ws;
                ws.gameObject.SetActive(false);
            }
            if (ws.gameObject.name == "HUDCanvas")
            {
                Player1.GetComponent<MoveCar>().HUD = ws;
                Player2.GetComponent<MoveCar>().HUD = ws;
            }
        }

        this.transform.GetComponentInParent<Transform>().gameObject.SetActive(false);
    }
}
