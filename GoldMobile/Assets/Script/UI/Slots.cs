using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public bool isUsed = false;

    public void ChangeColor()
    {
        isUsed = true;
        this.gameObject.SetActive(false);
    }
}
