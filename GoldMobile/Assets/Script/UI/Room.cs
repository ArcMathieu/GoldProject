using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int layerRoom = 17;
    public string CurrentTag;
    public bool Boss;
    public GameObject darkJZ;

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
            FindObjectOfType<GameManager>().Saving();
            
            if (Boss)
            {
                darkJZ.SetActive(true);
                Debug.Log("boss");
            }
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
        if (CurrentTag == "Boss")
        {
            FindObjectOfType<DarkJayZ>().gameObject.SetActive(true);
            Debug.Log("boss");
        }
    }

    private void DesactivateEnemies()
    {
        //Debug.Log("isEntitiesUnActivated");
    }
}
