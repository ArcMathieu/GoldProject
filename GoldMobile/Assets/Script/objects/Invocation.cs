using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
    public GameObject switchButton;
    public GameObject ghostAppears;
    
    public bool firstTime = true;
    public bool OnCircle = false;
    public bool CanChange = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCircle = true;
        }
    }

    private void Update()
    {
        if (OnCircle && firstTime)
        {
            CanChange = true;
        }
        else CanChange = false;
    }

    public void setAction()
    {
        if (CanChange)
        {
            //fait apparaitre la petite fille
            GameManager._instance.showGhost(true);
            GameManager._instance.IsFollowingGirl();
            //referme la porte de la chambre
            GameManager._instance.tp[5].precedentlyOpened = false;
            //setAnimBougie true
            firstTime = false;
            //fait apparaitre le bouton de switch de perso
            switchButton.SetActive(true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnCircle = false;
    }


}
