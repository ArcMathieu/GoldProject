using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowChivement : MonoBehaviour
{
    private bool Once = true;
    void Update()
    {
        if(gameObject.transform.childCount == 0 && Once)
        {
            Once = false;
            FindObjectOfType<Achievement>().UnlockShadows();
        }

    }
}
