using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private int isPressed = 0;
    public bool isPressedButton = false;

    public void InteractionWithObject()
    {
        if (!isPressedButton)
        {
            isPressedButton = true;
            ButtonPressed();
        }
    }

    public void ButtonPressed()
    {
        StartCoroutine(WaitTime());
        IEnumerator WaitTime(){
            yield return new WaitForSeconds(1);
            isPressedButton = false;
        }
    }

    
}
