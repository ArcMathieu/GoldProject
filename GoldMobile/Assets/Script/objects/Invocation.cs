using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
    public GameObject ghostAppears;
    public StoryGame storyManager;
    public ObjectsInteractable collier;
    
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
            storyManager.cinRituel = true;
            GameManager._instance.openStep();
            collier.isPickable = true;
            //setAnimBougie true
            firstTime = false;
            //fait apparaitre le bouton de switch de perso
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnCircle = false;
    }


}
