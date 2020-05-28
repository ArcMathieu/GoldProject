using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReconstructedMemory : MonoBehaviour
{

    public void Start()
    {
        FindObjectOfType<Achievement>().UnlockReconstructedMemory();
    }
}
