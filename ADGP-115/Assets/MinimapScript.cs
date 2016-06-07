using UnityEngine;
using System.Collections;

public class MinimapScript : MonoBehaviour {

    public GameObject Player1;
    public GameObject Player2;
    public GameObject HealthP1;
    public GameObject HealthP2;
    public GameObject SpeedP1;
    public GameObject SpeedP2;
    public GameObject RocketP;

    public GameObject MapPlayer1;
    public GameObject MapPlayer2;
    public GameObject MapHealth1;
    public GameObject MapHealth2;
    public GameObject MapSpeed1;
    public GameObject MapSpeed2;
    public GameObject MapRocket;

    // Use this for initialization
    void Start () {
        Component[] minimap = transform.parent.GetComponentsInChildren<Transform>();
        foreach (Transform mm in minimap)
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
        MapPlayer1.GetComponent<Renderer>().material.color = Player1.GetComponent<Renderer>().material.color;
        MapPlayer2.GetComponent<Renderer>().material.color = Player2.GetComponent<Renderer>().material.color;
        MapHealth1.GetComponent<Renderer>().material.color = HealthP1.GetComponent<Spawner>().PowerUp.GetComponent<Renderer>().sharedMaterial.color;
        MapHealth2.GetComponent<Renderer>().material.color = HealthP2.GetComponent<Spawner>().PowerUp.GetComponent<Renderer>().sharedMaterial.color;
        MapSpeed1.GetComponent<Renderer>().material.color = SpeedP1.GetComponent<Spawner>().PowerUp.GetComponent<Renderer>().sharedMaterial.color;
        MapSpeed2.GetComponent<Renderer>().material.color = SpeedP2.GetComponent<Spawner>().PowerUp.GetComponent<Renderer>().sharedMaterial.color;
        MapRocket.GetComponent<Renderer>().material.color = RocketP.GetComponent<Spawner>().PowerUp.GetComponent<Renderer>().sharedMaterial.color;
    }
	
	// Update is called once per frame
	void Update () {
        MapPlayer1.transform.position = new Vector3(Player1.transform.position.x, MapPlayer1.transform.position.y, Player1.transform.position.z);
        MapPlayer2.transform.position = new Vector3(Player2.transform.position.x, MapPlayer2.transform.position.y, Player2.transform.position.z);
        MapHealth1.transform.position = new Vector3(HealthP1.transform.position.x, MapPlayer1.transform.position.y, HealthP1.transform.position.z);
        MapHealth2.transform.position = new Vector3(HealthP2.transform.position.x, MapPlayer2.transform.position.y, HealthP2.transform.position.z);
        MapSpeed1.transform.position = new Vector3(SpeedP1.transform.position.x, MapSpeed1.transform.position.y, SpeedP1.transform.position.z);
        MapSpeed2.transform.position = new Vector3(SpeedP2.transform.position.x, MapSpeed2.transform.position.y, SpeedP2.transform.position.z);
        MapRocket.transform.position = new Vector3(RocketP.transform.position.x, MapRocket.transform.position.y, RocketP.transform.position.z);
        if (!HealthP1.GetComponent<Spawner>().PUexists)
            MapHealth1.GetComponent<MeshRenderer>().enabled = false;
        else
            MapHealth1.GetComponent<MeshRenderer>().enabled = true;
        if (!HealthP2.GetComponent<Spawner>().PUexists)
            MapHealth2.GetComponent<MeshRenderer>().enabled = false;
        else
            MapHealth2.GetComponent<MeshRenderer>().enabled = true;
        if (!SpeedP1.GetComponent<Spawner>().PUexists)
            MapSpeed1.GetComponent<MeshRenderer>().enabled = false;
        else
            MapSpeed1.GetComponent<MeshRenderer>().enabled = true;
        if (!SpeedP2.GetComponent<Spawner>().PUexists)
            MapSpeed2.GetComponent<MeshRenderer>().enabled = false;
        else
            MapSpeed2.GetComponent<MeshRenderer>().enabled = true;
        if (!RocketP.GetComponent<Spawner>().PUexists)
            MapRocket.GetComponent<MeshRenderer>().enabled = false;
        else
            MapRocket.GetComponent<MeshRenderer>().enabled = true;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (this.gameObject.GetComponent<Camera>().enabled == true)
                this.gameObject.GetComponent<Camera>().enabled = false;
            else
                this.gameObject.GetComponent<Camera>().enabled = true;
        }
	}
}
