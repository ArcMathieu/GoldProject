using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int layerRoom = 17;
    //public bool RoomQuest = false;
    public Switch switchButton;
    public string CurrentTag;

    // Use this for initialization
    void Start()
    {
        DesactivateEnemies();
    }
    //List<string> namesOfActive = new List<string>();
    //private int numActiveObj = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != layerRoom && other.gameObject.CompareTag("Player") || other.gameObject.layer != layerRoom && other.gameObject.CompareTag("GhostPlayer"))
        {
            //Debug.Log(other.gameObject.name);
            MainCamera.Instance.RoomEnter(this);
            //Debug.Log(other.gameObject.name);
            ActivateEnemies();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != layerRoom && other.gameObject.CompareTag("Player") || other.gameObject.layer != layerRoom && other.gameObject.CompareTag("GhostPlayer"))
        {
            //Debug.Log(other.name);
            DesactivateEnemies();
        }

    }

    private void ActivateEnemies()
    {
        //Debug.Log("isEntitiesActivated");
    }

    private void DesactivateEnemies()
    {
        //Debug.Log("isEntitiesUnActivated");
    }
}
