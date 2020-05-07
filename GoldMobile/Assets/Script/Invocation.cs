using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
    public PlayerManager player;
    public GhostManager ghost;
    public GameObject ghostAppears;
    public InteractionManager interact;
    public bool isAppears = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isAppears && collision.gameObject.CompareTag("Player"))
        {
            if (interact.isPressedButton)
            {
                player.ChangeControl();
                ghostAppears.SetActive(true);
                isAppears = true;
            }
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (isAppears && collision.gameObject.CompareTag("Player"))
    //    {
    //        isAppears = false;
    //    }
    //}


}
