using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public GameObject barMental;
    public Transform Player;
    public bool detected;
    public float distanceDetect = 10f;

    void Update()
    {
        if(Player)
        {
            float distance = (Player.position - transform.position).sqrMagnitude;
            if (distance < distanceDetect * distanceDetect)
            {
                detected = true;
                if(detected == true)
                {
                    barMental.SetActive(false);
                }
                else
                {
                    barMental.SetActive(true);
                }
            }
            else
            {
                detected = false;
            }
        }

    }

}
