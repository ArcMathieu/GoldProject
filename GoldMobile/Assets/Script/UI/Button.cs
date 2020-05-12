using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ObjectsInteractable[] Obj;
    public Invocation Circle;
    public void testDebug()
    {
        Debug.Log("Button B was pressed");
        for (int i = 0; i < Obj.Length; i++)
        {
            Obj[i].setAction();

        }
        Circle.setAction();
    }
}
