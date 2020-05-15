using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
    public GameObject switchButton;
    public GameObject ghostAppears;
    
    private bool firstTime = true;
    private bool CanChange = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (/*firstTime && */!CanChange)
            {
                CanChange = true;
            }
        }
    }
    
    public void setAction()
    {
        if (firstTime && CanChange)
        {
            
            //ghostAppears.SetActive(true);
            GameManager._instance.showGhost(true);
            GameManager._instance.IsFollowingGirl();
            firstTime = false;
            switchButton.SetActive(true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CanChange = false;
    }


}
