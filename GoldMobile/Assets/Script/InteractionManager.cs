using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private int isPressed = 0;
    public bool isPressedButton = false;

    public void InteractionWithObject()
    {
        isPressed = 1;
        ButtonPressed();
    }

    public void ButtonPressed()
    {
        StartCoroutine(WaitTime());
        IEnumerator WaitTime(){
            yield return new WaitForSeconds(0.2f);
            isPressed = 0;
        }

    }

    private void Update()
    {
        if (isPressed != 0)
        {
            isPressedButton = true;
        }
        else isPressedButton = false;
    }

    
}
