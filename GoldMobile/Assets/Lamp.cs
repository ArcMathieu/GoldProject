using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lamp : MonoBehaviour
{
    bool lightOn;

    public void setAction()
    {
        if (lightOn)
            lightOn = false;
        else if (!lightOn)
            lightOn = true;
    }

    private void Update()
    {
        if (lightOn)
        {
            transform.GetChild(0).GetComponent<Light2D>().intensity = Mathf.Lerp(transform.GetChild(0).GetComponent<Light2D>().intensity, 0, 0.2f);
        }
        else
        {
            transform.GetChild(0).GetComponent<Light2D>().intensity = Mathf.Lerp(transform.GetChild(0).GetComponent<Light2D>().intensity, 1.87f, 0.05f);
        }
    }
}
