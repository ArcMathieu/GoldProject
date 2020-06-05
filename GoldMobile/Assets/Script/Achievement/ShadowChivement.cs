using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowChivement : MonoBehaviour
{
    private bool Once = true;
    public bool allShadow;
    void Update()
    {
        if(gameObject.transform.childCount == 0 && Once)
        {
            Once = false;
            GameManager._instance.Shadow = true;
            FindObjectOfType<Achievement>().UnlockShadows();
        }
        if (allShadow)
        {
            GameManager._instance.Shadow = true;
        }

    }
}
