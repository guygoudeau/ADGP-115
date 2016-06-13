using UnityEngine;
using System.Collections;

public class MinimapScript : MonoBehaviour {

    public GameObject Player1;  //A GameObject to reference the actual Player1 GameObject.
    public GameObject Player2;  //A GameObject to reference the actual Player2 GameObject.
    public GameObject HealthP1; //A GameObject to reference the First Health Pickup Spawner GameObject.
    public GameObject HealthP2; //A GameObject to reference the Second Health Pickup Spawner GameObject.
    public GameObject SpeedP1;  //A GameObject to reference the First Speed/Boost Pickup Spawner GameObject.
    public GameObject SpeedP2;  //A GameObject to reference the First Speed/Boost Pickup Spawner GameObject.
    public GameObject RocketP;  //A GameObject to reference the Rocket Pickup Spawner GameObject.

    public GameObject MapPlayer1;   //A GameObject to represent the Player 1 Minimap GameObject.
    public GameObject MapPlayer2;   //A GameObject to represent the Player 2 Minimap GameObject.
    public GameObject MapHealth1;   //A GameObject to represent the First Health Pickup Spawner Minimap GameObject.
    public GameObject MapHealth2;   //A GameObject to represent the Second Health Pickup Spawner Minimap GameObject.
    public GameObject MapSpeed1;    //A GameObject to represent the First Speed/Boost Pickup Spawner Minimap GameObject.
    public GameObject MapSpeed2;    //A GameObject to represent the Second Speed/Boost Pickup Spawner Minimap GameObject.
    public GameObject MapRocket;    //A GameObject to represent the Rocket Pickup Spawner Minimap GameObject.

    // Use this for initialization
    void Start () {
        Component[] minimap = transform.parent.GetComponentsInChildren<Transform>();    //Creates an array of Components called minimap that contain Transforms.
        foreach (Transform mm in minimap)   //Loops through each Transform in minimap and sets the Minimap Representation GameObjects to the GameObjects with the corresponding name in the if and else if statements.
        {
            if (mm.gameObject.name == "MapPlayer1")
                MapPlayer1 = mm.gameObject;
            else if (mm.gameObject.name == "MapPlayer2")
                MapPlayer2 = mm.gameObject;
            else if (mm.gameObject.name == "MapHealth1")
                MapHealth1 = mm.gameObject;
            else if (mm.gameObject.name == "MapHealth2")
                MapHealth2 = mm.gameObject;
            else if (mm.gameObject.name == "MapSpeed1")
                MapSpeed1 = mm.gameObject;
            else if (mm.gameObject.name == "MapSpeed2")
                MapSpeed2 = mm.gameObject;
            else if (mm.gameObject.name == "MapRocket")
                MapRocket = mm.gameObject;
        }
        MapPlayer1.GetComponent<Renderer>().material.color = Player1.GetComponent<Renderer>().material.color;   //Sets the Material color for MapPlayer1 to the Material color for Player1.
        MapPlayer2.GetComponent<Renderer>().material.color = Player2.GetComponent<Renderer>().material.color;   //Sets the Material color for MapPlayer1 to the Material color fot Player2.
        MapHealth1.GetComponent<Renderer>().material.color = HealthP1.GetComponent<Spawner>().PowerUp.GetComponent<Renderer>().sharedMaterial.color;    //Sets the Material color for MapHealth1 to the Material color for HealthP1.
        MapHealth2.GetComponent<Renderer>().material.color = HealthP2.GetComponent<Spawner>().PowerUp.GetComponent<Renderer>().sharedMaterial.color;    //Sets the Material color for MapHealth2 to the Material color for HealthP2.
        MapSpeed1.GetComponent<Renderer>().material.color = SpeedP1.GetComponent<Spawner>().PowerUp.GetComponent<Renderer>().sharedMaterial.color;  //Sets the Material color for MapSpeed1 to the Material color for SpeedP1.
        MapSpeed2.GetComponent<Renderer>().material.color = SpeedP2.GetComponent<Spawner>().PowerUp.GetComponent<Renderer>().sharedMaterial.color;  //Sets the Material color for MapSpeed2 to the Material color for SpeedP2.
        MapRocket.GetComponent<Renderer>().material.color = RocketP.GetComponent<Spawner>().PowerUp.GetComponent<Renderer>().sharedMaterial.color;  //Sets the Material color for MapRocket to the Material color for RocketP.
    }
	
	// Update is called once per frame
	void Update () {
        MapPlayer1.transform.position = new Vector3(Player1.transform.position.x, MapPlayer1.transform.position.y, Player1.transform.position.z);   //Sets the x and z position of MapPlayer1 to the x and z position of Player1, and keeps the y at the y position of MapPlayer1
        MapPlayer2.transform.position = new Vector3(Player2.transform.position.x, MapPlayer2.transform.position.y, Player2.transform.position.z);   //Sets the x and z position of MapPlayer1 to the x and z position of Player2, and keeps the y at the y position of MapPlayer2
        MapHealth1.transform.position = new Vector3(HealthP1.transform.position.x, MapHealth1.transform.position.y, HealthP1.transform.position.z); //Sets the x and z position of MapHealth1 to the x and z position of HealthP1, and keeps the y at the y position of MapHealth1
        MapHealth2.transform.position = new Vector3(HealthP2.transform.position.x, MapHealth2.transform.position.y, HealthP2.transform.position.z); //Sets the x and z position of MapHealth2 to the x and z position of HealthP2, and keeps the y at the y position of MapHealth2
        MapSpeed1.transform.position = new Vector3(SpeedP1.transform.position.x, MapSpeed1.transform.position.y, SpeedP1.transform.position.z); //Sets the x and z position of MapSpeed1 to the x and z position of SpeedP1, and keeps the y at the y position of MapSpeed1
        MapSpeed2.transform.position = new Vector3(SpeedP2.transform.position.x, MapSpeed2.transform.position.y, SpeedP2.transform.position.z); //Sets the x and z position of MapSpeed2 to the x and z position of SpeedP2, and keeps the y at the y position of MapSpeed2
        MapRocket.transform.position = new Vector3(RocketP.transform.position.x, MapRocket.transform.position.y, RocketP.transform.position.z); //Sets the x and z position of MapRocket to the x and z position of RocketP, and keeps the y at the y position of MapRocket
        if (!HealthP1.GetComponent<Spawner>().PUexists) //Checks to see if Health Powerup 1 exists, if it does, the MapHealth1's meshrenderer is enabled, if it isn't, the MapHealth1's meshrenderer is disabled.
            MapHealth1.GetComponent<MeshRenderer>().enabled = false;
        else
            MapHealth1.GetComponent<MeshRenderer>().enabled = true;
        if (!HealthP2.GetComponent<Spawner>().PUexists) //Checks to see if Health Powerup 2 exists, if it does, the MapHealth2's meshrenderer is enabled, if it isn't, the MapHealth2's meshrenderer is disabled.
            MapHealth2.GetComponent<MeshRenderer>().enabled = false;
        else
            MapHealth2.GetComponent<MeshRenderer>().enabled = true;
        if (!SpeedP1.GetComponent<Spawner>().PUexists)  //Checks to see if Speed/Boost Powerup 1 exists, if it does, the MapSpeed1's meshrenderer is enabled, if it isn't, the MapSpeed1's meshrenderer is disabled.
            MapSpeed1.GetComponent<MeshRenderer>().enabled = false;
        else
            MapSpeed1.GetComponent<MeshRenderer>().enabled = true;
        if (!SpeedP2.GetComponent<Spawner>().PUexists)  //Checks to see if Speed/Boost Powerup 2 exists, if it does, the MapSpeed2's meshrenderer is enabled, if it isn't, the MapSpeed2's meshrenderer is disabled.
            MapSpeed2.GetComponent<MeshRenderer>().enabled = false;
        else
            MapSpeed2.GetComponent<MeshRenderer>().enabled = true;
        if (!RocketP.GetComponent<Spawner>().PUexists)  //Checks to see if Rocket Powerup exists, if it does, the MapRocket's meshrenderer is enabled, if it isn't, the MapRocket's meshrenderer is disabled.
            MapRocket.GetComponent<MeshRenderer>().enabled = false;
        else
            MapRocket.GetComponent<MeshRenderer>().enabled = true;
        if (Input.GetKeyDown(KeyCode.Return))   //Checks if the user pressed the Return key. If the User has and the Minimap's Camera is visible, it disables it, else, it enables the Minimap's Camera.
        {
            if (this.gameObject.GetComponent<Camera>().enabled == true)
                this.gameObject.GetComponent<Camera>().enabled = false;
            else
                this.gameObject.GetComponent<Camera>().enabled = true;
        }
	}
}
