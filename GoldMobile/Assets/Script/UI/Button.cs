using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    //public ObjectsInteractable[] Obj;
    public PlayerManager player;
    public Invocation Circle;
    public void onClick()
    {

        Circle.setAction();

        StartCoroutine(changeColor());
        IEnumerator changeColor()
        {
            GetComponent<Image>().color = Color.green;
            player.OnObject = true;
            yield return new WaitForSeconds(0.2f);
            GetComponent<Image>().color = Color.black;
            player.OnObject = false;

        }
    }
}
