using UnityEngine;
using System.Collections.Generic;

public class TeacherTest : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Players = new List<GameObject>();
    [ContextMenu("GetPlayers")]
    void GetPlayers()
    {

        foreach(GameObject go in  GameObject.FindGameObjectsWithTag("Player"))
        {
            Players.Add(go);
        }
    }

    [ContextMenu("RemovePlayers")]
    void RemovePlayers()
    {
        Players.Clear();
        Players = null;
    }

    [SerializeField]
    GameObject P2Camera;
    [ContextMenu("GetPlayer2Camera")]
    void GetPlayer2Camera()
    {
        foreach(GameObject go in Players)
        {
            Debug.Log(go.name);
            if (go.name == "Player2")
            {                
                P2Camera = go.GetComponentInChildren<Camera>().gameObject;
            }
        }
    }

    [SerializeField]
    List<GameObject> children = new List<GameObject>();
    [ContextMenu("get child gameobject")]
    void GetChildren()
    {
        foreach(Transform t in transform)
        {
            children.Add(t.gameObject);
        }
    }
}
