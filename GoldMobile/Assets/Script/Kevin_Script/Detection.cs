using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public GameObject barM;
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
                    barM.SetActive(false);
                }
                else
                {
                    barM.SetActive(true);
                }
            }
        }
    }

}
