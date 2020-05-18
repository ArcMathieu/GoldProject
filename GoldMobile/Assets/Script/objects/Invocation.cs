using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
    public GameObject switchButton;
    public GameObject ghostAppears;
    
    public bool firstTime = true;
    public bool CanChange = false;
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
            Debug.Log("fr");
            GameManager._instance.showGhost(true);
            GameManager._instance.IsFollowingGirl();
            //setAnimBougie true
            firstTime = false;
            switchButton.SetActive(true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CanChange = false;
    }


}
