using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (Input.touchCount > 0)
        {
            Debug.Log("je sais pas");
        }
    }
}
