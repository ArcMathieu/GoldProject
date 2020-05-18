using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    //public ObjectsInteractable[] Obj;
    public PlayerManager player;
    public Invocation Circle;
    public ObjectsInteractable Interactable;
    public void onClick()
    {
        if (player.CurrentInteraction != null)
        {
        //Lance la fonction setAction sur l'objet avec lequel le perso est en collision
            foreach(GameObject myObject in player.CurrentInteraction)
            {
                myObject.SendMessage("setAction");

            }
        }
     

        StartCoroutine(changeColor());
        IEnumerator changeColor()
        {
            GetComponent<Image>().color = Color.green;
      //      player.OnObject = true;
            yield return new WaitForSeconds(0.2f);
            GetComponent<Image>().color = Color.black;
          //  player.OnObject = false;

        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player.CurrentInteraction != null)
            {
                foreach (GameObject myObject in player.CurrentInteraction)
                {
                    myObject.SendMessage("setAction");

                }
            }
    
            StartCoroutine(changeColor());
            IEnumerator changeColor()
            {
                GetComponent<Image>().color = Color.green;
            //    player.OnObject = true;
                yield return new WaitForSeconds(0.2f);
                GetComponent<Image>().color = Color.black;
              //  player.OnObject = false;

            }
        }
    }
}
