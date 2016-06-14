using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selection : MonoBehaviour {

    public GameObject Player;  //Gameobject that is used for instantiating two player prefabs for the first and second player.
    public int p1Barrel = 2;   //An integer variable that represents what kind of barrel player one will have with numbers. It's default is the machine gun barrel.
    public int p2Barrel = 2;   //An integer variable that represents what kind of barrel player two will have with numbers. It's default is the machine gun barrel.
    public GameObject GrassArena;   //Gameobject that is used for instantiating a grass arena.
    public GameObject IceArena;     //Gameobject that is used for instantiating an ice arena.
    public GameObject FutureArena;  //Gameobject that is used for instantiating a future arena.
    GameObject currentArena;    //A Gameobject that will be set to one of the above three arenas to instantiate the arena.
    public GameObject RocketPowerup;    //A powerup GameObject that gives a player a rocket.
    public GameObject HealthPowerup;    //A powerup GameObject that gives a player health.
    public GameObject BoostPowerup;     //A powerup GameObject that gives a player a boost.
    public AudioSource select;      //An audiosource used to play an audioclip when a button is pressed.
    public int P1currentColor = 6;  //An integer variable that represents what color player one will be with numbers. It's default is black.
    public int P2currentColor = 6;  //An integer variable that represents what color player two will be with numbers. It's default is black.
    public GameObject Minimap;  //GameObject used to reference the minimap and gameobject for setting the players and pickup objects for the minimap to use.
    
    void Start()
    {
        currentArena = GrassArena;  //Sets the currentArena GameObject to be the grass arena.
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
        p1Barrel = 1; // this changes weapon to shotgun
        select.Play(); // this plays a sound when you click the button
    }
    public void p2Shotgun() // Player 2's shotgun button
    {
        p2Barrel = 1; // this changes weapon to shotgun
        select.Play(); // this plays a sound when you click the button
    }
    public void p1MachineG() // Player 1's machine gun button
    {
        p1Barrel = 2; // this changes weapon to machine gun
        select.Play(); // this plays a sound when you click the button
    }
    public void p2MachineG() // Player 2's machine gun button
    {
        p2Barrel = 2; // this changes weapon to machine gun
        select.Play(); // this plays a sound when you click the button
    }
    public void p1Chainsaw() // Player 1's chainsaw button
    {
        p1Barrel = 3; // this changes weapon to chainsaw
        select.Play(); // this plays a sound when you click the button
    }
    public void p2Chainsaw() // Player 2's chainsaw button
    {
        p2Barrel = 3; // this changes weapon to chainsaw
        select.Play(); // this plays a sound when you click the button
    }

    public void SelectGrass() //Button for setting the currentArena to the grass arena.
    {
        currentArena = GrassArena; // changes arena to grass arena
        select.Play(); // this plays a sound when you click the button
    }
    public void SelectIce() //Button for setting the currentArena to the ice arena.
    {
        currentArena = IceArena; // change arena to ice arena
        select.Play(); // this plays a sound when you click the button
    }
    public void SelectFuture() //Button for setting the currentArena to the future arena.
    {
        currentArena = FutureArena; // change arena to future arena
        select.Play(); // this plays a sound when you click the button
    }

    public void P1Blue() // This button change player 1's color to blue
    {
        P1currentColor = 1; // 1 is blue
        select.Play(); // this plays a sound when you click the button
    }
    public void P1Red()  // This button change player 1's color to red
    {
        P1currentColor = 2; // 2 is red
        select.Play(); // this plays a sound when you click the button
    }
    public void P1Green() // This button change player 1's color to green
    {
        P1currentColor = 3; // 3 is green
        select.Play(); // this plays a sound when you click the button
    }
    public void P1Yellow() // This button change player 1's color to yellow
    {
        P1currentColor = 4; // 4 is yellow
        select.Play(); // this plays a sound when you click the button
    }
    public void P1White() // This button change player 1's color to white
    {
        P1currentColor = 5; // 5 is white
        select.Play(); // this plays a sound when you click the button
    }
    public void P1Black() // This button change player 1's color to black
    {
        P1currentColor = 6; // 6 is black
        select.Play(); // this plays a sound when you click the button
    }

    public void P2Blue() // This button change player 2's color to blue
    {
        P2currentColor = 1; // 1 is blue
        select.Play(); // this plays a sound when you click the button
    }
    public void P2Red()  // This button change player 2's color to red
    {
        P2currentColor = 2; // 2 is red
        select.Play(); // this plays a sound when you click the button
    }
    public void P2Green() // This button change player 2's color to green
    {
        P2currentColor = 3; // 3 is green
        select.Play(); // this plays a sound when you click the button
    }
    public void P2Yellow() // This button change player 2's color to yellow
    {
        P2currentColor = 4; // 4 is yellow
        select.Play(); // this plays a sound when you click the button
    }
    public void P2White() // This button change player 2's color to white
    {
        P2currentColor = 5; // 5 is white
        select.Play(); // this plays a sound when you click the button
    }
    public void P2Black() // This button change player 2's color to black
    {
        P2currentColor = 6; // 6 is black
        select.Play(); // this plays a sound when you click the button
    }

    public void Finish() // Once everything has been selected, clicking the finish button will instantiate objects and set variables
    {
        select.Play(); // this plays a sound when you click the button
        Cursor.lockState = CursorLockMode.Locked; // this locks the cursor to the screen so we can turn around with the mouse
        Cursor.visible = false; // this hides the cursor
        GameObject arena = Instantiate(currentArena); // instantiate the prefab of whatever arena was last chosen
        var starts = arena.GetComponentsInChildren<Transform>();    // Creates an array of Transform objects for use with setting where the players and power ups spawn

        // Creating Player1
        GameObject Player1 = (GameObject)Instantiate(Player, new Vector3(0, 5, -120), Quaternion.identity); // instantiate a player prefab at certain location
        Player1.GetComponent<MoveCar>().barrel = p1Barrel; // assign player a barrel
        Player1.tag = "P1"; // set player 1's tag
        Player1.name = "Player 1"; // set player 1's name
        if (P1currentColor == 1) // depending on what color was chosen...
        {
            foreach (Renderer piece in Player1.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.blue;
            Player1.GetComponent<Renderer>().material.color = Color.blue; // ...use these to change color of material
        }
        if (P1currentColor == 2)
        {
            foreach (Renderer piece in Player1.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.red;
            Player1.GetComponent<Renderer>().material.color = Color.red;
        }
        if (P1currentColor == 3)
        {
            foreach (Renderer piece in Player1.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.green;
            Player1.GetComponent<Renderer>().material.color = Color.green;
        }
        if (P1currentColor == 4)
        {
            foreach (Renderer piece in Player1.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.yellow;
            Player1.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (P1currentColor == 5)
        {
            foreach (Renderer piece in Player1.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.white;
            Player1.GetComponent<Renderer>().material.color = Color.white;
        }
        if (P1currentColor == 6)
        {
            foreach (Renderer piece in Player1.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.black;
            Player1.GetComponent<Renderer>().material.color = Color.black;
        }

        // Creating Player2 
        GameObject Player2 = (GameObject)Instantiate(Player, new Vector3(0, 5, 50), Quaternion.identity); // instantiate another player prefab at certain location
        Player2.GetComponent<MoveCar>().barrel = p2Barrel; // assign player a barrel
        Player2.tag = "P2"; // set player 2's tag
        Player2.name = "Player 2"; // set player 2's name
        if (P2currentColor == 1) // depending on what color was chosen...
        {
            foreach (Renderer piece in Player2.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.blue;
            Player2.GetComponent<Renderer>().material.color = Color.blue; // ...use these to change color of material
        }
        if (P2currentColor == 2)
        {
            foreach (Renderer piece in Player2.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.red;
            Player2.GetComponent<Renderer>().material.color = Color.red;
        }
        if (P2currentColor == 3)
        {
            foreach (Renderer piece in Player2.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.green;
            Player2.GetComponent<Renderer>().material.color = Color.green;
        }
        if (P2currentColor == 4)
        {
            foreach (Renderer piece in Player2.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.yellow;
            Player2.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (P2currentColor == 5)
        {
            foreach (Renderer piece in Player2.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.white;
            Player2.GetComponent<Renderer>().material.color = Color.white;
        }
        if (P2currentColor == 6)
        {
            foreach (Renderer piece in Player2.GetComponentsInChildren<Renderer>())
                piece.material.color = Color.black;
            Player2.GetComponent<Renderer>().material.color = Color.black;
        }
        Player2.GetComponentInChildren<Camera>().rect = new Rect(.5f, 0, .5f, 1);

        foreach (var st in starts)  //runs a loop that searches through all the transforms to set the player and powerups to game objects that have been set as some of the standards of making an arena.
        {
            if (st.gameObject.name == "P1Start")    //When it finds the P1Start game object among the transforms, it will set the Player1's position and rotation to that of the P1Start's position and rotation.
            {
                Player1.transform.position = st.position;
                Player1.transform.rotation = st.rotation;
            }
            if (st.gameObject.name == "P2Start")    //When it finds the P2Start game object among the transforms, it will set the Player2's position and rotation to that of the P2Start's position and rotation.
            {
                Player2.transform.position = st.position;
                Player2.transform.rotation = st.rotation;
            }
            if (st.gameObject.name == "Rspawn")     //When it finds the Rspawn game object among the transforms, it will set the PowerUp GameObject variable of Rspawn's Spawner script to the RocketPowerup GameObject.
                st.gameObject.GetComponent<Spawner>().PowerUp = RocketPowerup;
            if (st.gameObject.name == "Hspawn1" || st.gameObject.name == "Hspawn2") //When it finds an Hspawn game object among the transforms, it will set the PowerUp GameObject variable of the Hspawn's Spawner script to the HealthPowerup GameObject.
                st.gameObject.GetComponent<Spawner>().PowerUp = HealthPowerup;
            if (st.gameObject.name == "Bspawn1" || st.gameObject.name == "Bspawn2") //When it finds a Bspawn game object among the transforms, it will set the PowerUp GameObject variable of the Bspawn's Spawner script to the BoostPowerup GameObject.
                st.gameObject.GetComponent<Spawner>().PowerUp = BoostPowerup;
        }

        Component[] sliders = transform.GetComponentInParent<Transform>().parent.GetComponentsInChildren<Slider>();     //An array is created and populated with all the Slider objects in the Canvas.
        foreach (Slider hb in sliders)  //Searches through the array for all Sliders.
        {
            if (hb.name == "P1Slider")  //When the P1Slider is found, it sets the Player1's healthSlider variable in it's MoveCar script to the P1Slider to have a working health bar display.
                Player1.GetComponent<MoveCar>().healthSlider = hb;
            else if (hb.name == "P2Slider") //When the P2Slider is found, it sets the Player2's healthSlider variable in it's MoveCar script to the P2Slider to have a working health bar display.
                Player2.GetComponent<MoveCar>().healthSlider = hb;
        }
        Component[] texts = transform.GetComponentInParent<Transform>().parent.GetComponentsInChildren<Text>(); //An array is created and populated with all the Text objects in the Canvas.
        foreach (Text weapon in texts)   //Searches through the array for all Texts.
        {
            if (weapon.name == "P1Weapon")  //When the P1Weapon is found, it sets the Player1's currentWeapon variable in it's MoveCar script to the P1Weapon to have a display on the screen that print's out Player1's weapon.
                Player1.GetComponent<MoveCar>().currentWeapon = weapon;
            else if (weapon.name == "P2Weapon") //When the P2Weapon is found, it sets the Player2's currentWeapon variable in it's MoveCar script to the P2Weapon to have a display on the screen that print's out Player2's weapon.
                Player2.GetComponent<MoveCar>().currentWeapon = weapon;
        }
        Component[] listeners = transform.GetComponentInParent<Transform>().parent.GetComponentsInChildren<AudioListener>();    //An array is created and populated with AudioListener objects from the Canvas.
        foreach (AudioListener al in listeners) //Searches through the array for all AudioListeners.
            if (al.name == "AudioListener") //Finds the AudioListener AudioListener and enables it so AudioSources can be heard.
                al.enabled = true;
        foreach (Transform ws in transform.GetComponentInParent<Transform>().parent.GetComponentsInChildren<Transform>())    //Searches through every Transform object in the Canvas.
        {
            if (ws.gameObject.name == "P1Win")  //When the P1Win gameObject is found it sets Player2's winScreen variable in it's MoveCar script to P1Win and sets the P1Win active trait to false.
            {
                Player2.GetComponent<MoveCar>().winScreen = ws;
                ws.gameObject.SetActive(false);
            }
            if (ws.gameObject.name == "P2Win")  //When the P2Win gameObject is found it sets Player1's winScreen variable in it's MoveCar script to P2Win and sets the P2Win active trait to false.
            {
                Player1.GetComponent<MoveCar>().winScreen = ws;
                ws.gameObject.SetActive(false);
            }
            if (ws.gameObject.name == "HUDCanvas")  //When the HUDCanvas gameObject is found both Players' HUD variables in their MoveCar scripts are set to the HUDCanvas.
            {
                Player1.GetComponent<MoveCar>().HUD = ws;
                Player2.GetComponent<MoveCar>().HUD = ws;
            }
        }
        Minimap.GetComponentInChildren<MinimapScript>().Player1 = Player1;  //Sets the MinimapScript's Player1 to the instantiated Player1 GameObject.
        Minimap.GetComponentInChildren<MinimapScript>().Player2 = Player2;  //Sets the MinimapScript's Player2 to the instantiated Player2 GameObject.
        foreach (var powerups in starts)    //Searches all the variables in the Arena Transform Array and sets the MinimapScript's powerup references to the actual powerup spawn objects.
        {
            if (powerups.gameObject.name == "Hspawn1")
                Minimap.GetComponentInChildren<MinimapScript>().HealthP1 = powerups.gameObject;
            else if (powerups.gameObject.name == "Hspawn2")
                Minimap.GetComponentInChildren<MinimapScript>().HealthP2 = powerups.gameObject;
            else if (powerups.gameObject.name == "Bspawn1")
                Minimap.GetComponentInChildren<MinimapScript>().SpeedP1 = powerups.gameObject;
            else if (powerups.gameObject.name == "Bspawn2")
                Minimap.GetComponentInChildren<MinimapScript>().SpeedP2 = powerups.gameObject;
            else if (powerups.gameObject.name == "Rspawn")
                Minimap.GetComponentInChildren<MinimapScript>().RocketP = powerups.gameObject;
        }
        Minimap.GetComponentInChildren<MinimapScript>().enabled = true; //Starts the MinimapScript
        this.transform.GetComponentInParent<Transform>().gameObject.SetActive(false);   //The last thing the Finish function does, the Selection Menu's active trait is set to false.
    }
}
