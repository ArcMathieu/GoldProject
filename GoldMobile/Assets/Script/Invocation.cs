using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
    public PlayerManager player;
    public GhostManager ghost;
    public GameObject ghostAppears;
    public InteractionManager interact;
    private bool firstTime = true;
    private bool CanChange = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (firstTime && !CanChange)
            {
                CanChange = true;
            }
        }
    }
    
    public void setAction()
    {
        if (firstTime && CanChange)
        {
            player.ChangeControl();
            ghostAppears.SetActive(true);
            firstTime = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CanChange = false;
    }


}
