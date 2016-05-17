using UnityEngine;
using System.Collections;

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
        GameObject Player1 = (GameObject)Instantiate(Player, new Vector3(0, 5, -120), Quaternion.identity);
        Player1.GetComponent<MoveCar>().barrel = p1Barrel;
        Player1.tag = "P1";
        GameObject Player2 = (GameObject)Instantiate(Player, new Vector3(0, 5, 50), Quaternion.identity);
        Player2.GetComponent<MoveCar>().barrel = p2Barrel;
        Player2.tag = "P2";
        this.GetComponentInParent<Transform>().gameObject.SetActive(false);
    }
}
