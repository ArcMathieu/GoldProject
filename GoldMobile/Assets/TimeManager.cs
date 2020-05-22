using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    private DisplayText Dialogues;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.U))
        {
            Debug.Log("Faster");
            Time.timeScale = 3f;
        } else if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("Fasterrrrrrrrrr");
            Time.timeScale = 5f;
        } else if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 10f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }
}
