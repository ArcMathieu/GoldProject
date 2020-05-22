using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLock : MonoBehaviour
{
    public GameObject UILock;
    public bool CodeFound;
    public GameObject Clee;

    private void Start()
    {
        UILock = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<cadena>(true).gameObject;
    }

    private void Update()
    {
        if(CodeFound == true)
        {
            Clee.GetComponent<ObjectsInteractable>().isReadyForCinematic = true;
            Destroy(gameObject);
        }
    }
    public  void Action(GameObject Player)
    {
        UILock.SetActive(true);
        UILock.GetComponent<cadena>().CoffreClosed = gameObject;
        Player.GetComponent<PlayerManager>().Waiting();
    }
}
