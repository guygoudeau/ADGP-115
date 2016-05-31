using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selection : MonoBehaviour {

    public GameObject Player;
    public GameObject GrassArena;
    public GameObject IceArena;
    public GameObject FutureArena;
    public GameObject RocketPowerup;
    public GameObject HealthPowerup;
    public GameObject BoostPowerup;
    public AudioSource select;
    GameObject currentArena;
    public int p1Barrel = 2; // tank default weapon is machine gun
    public int p2Barrel = 2;
    public int P1currentColor = 6; // tank default color is black
    public int P2currentColor = 6;

    void Start ()
    {
        currentArena = GrassArena; // starting arena is grass by default
	}

    public void p1Sniper() // Player 1's sniper button
    {
        p1Barrel = 0; // this changes weapon to sniper rifle
        select.Play(); // this plays a sound when you click the button
    }
    public void p2Sniper() // Player 2's sniper button
    {
        p2Barrel = 0; // this changes weapon to sniper rifle
        select.Play(); // this plays a sound when you click the button
    }
    public void p1Shotgun() // Player 1's shotgun button
    {
        p1Barrel = 1; // switch to shotgun
        select.Play(); // play sound
    }
    public void p2Shotgun() // Player 2's shotgun button
    {
        p2Barrel = 1;
        select.Play();
    }
    public void p1MachineG() // Player 1's machine gun button
    {
        p1Barrel = 2; // switch to machine gun
        select.Play(); // play sound
    }
    public void p2MachineG() // Player 2's machine gun button
    {
        p2Barrel = 2;
        select.Play();
    }
    public void p1Chainsaw() // Player 1's chainsaw button
    {
        p1Barrel = 3; // switch to chainsaw
        select.Play(); // play sound
    }
    public void p2Chainsaw() // Player 2's chainsaw button
    {
        p2Barrel = 3;
        select.Play();
    }

    public void SelectGrass()
    {
        currentArena = GrassArena; // changes arena to grass arena
        select.Play(); // play select sound
    }
    public void SelectIce()
    {
        currentArena = IceArena; // change arena to ice arena
        select.Play();
    }
    public void SelectFuture()
    {
        currentArena = FutureArena; // change arena to future arena
        select.Play();
    }

    public void P1Blue() // these functions change player 1's color
    {
        P1currentColor = 1; // 1 is blue
        select.Play();
    }
    public void P1Red()
    {
        P1currentColor = 2; // 2 is red
        select.Play();
    }
    public void P1Green()
    {
        P1currentColor = 3; // 3 is green
        select.Play();
    }
    public void P1Yellow()
    {
        P1currentColor = 4; // 4 is yellow
        select.Play();
    }
    public void P1White()
    {
        P1currentColor = 5; // 5 is white
        select.Play();
    }
    public void P1Black()
    {
        P1currentColor = 6; // 6 is black
        select.Play();
    }

    public void P2Blue() // these functions change player 2's color
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

    public void Finish() // Once everything has been selected, clicking the finish button makes it all happen
    {
        select.Play(); // play button select
        Cursor.lockState = CursorLockMode.Locked; // this locks the cursor to the screen so we can turn around with the mouse
        Cursor.visible = false; // this hides the cursor
        GameObject arena = Instantiate(currentArena); // instantiate the prefab of whatever arena was last chosen
        var starts = arena.GetComponentsInChildren<Transform>();

        // Creating Player1
        GameObject Player1 = (GameObject)Instantiate(Player, new Vector3(0, 5, -120), Quaternion.identity); // instantiate a player prefab at certain location
        Player1.GetComponent<MoveCar>().barrel = p1Barrel; // assign player a barrel
        Player1.tag = "P1"; // set player 1's tag
        Player1.name = "Player 1"; // set player 1's name
        if (P1currentColor == 1) // depending on what color was chosen...
        {
            Player1.GetComponent<Renderer>().material.color = Color.blue; // ...use these to change color of material
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
        GameObject Player2 = (GameObject)Instantiate(Player, new Vector3(0, 5, 50), Quaternion.identity); // instantiate another player prefab at certain location
        Player2.GetComponent<MoveCar>().barrel = p2Barrel; // assign player a barrel
        Player2.tag = "P2"; // set player 2's tag
        Player2.name = "Player 2"; // set player 2's name
        if (P2currentColor == 1) // depending on what color was chosen...
        {
            Player2.GetComponent<Renderer>().material.color = Color.blue; // ...use these to change color of material
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
