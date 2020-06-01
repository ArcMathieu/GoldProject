using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PentagrammeJayZ : MonoBehaviour
{
    private SpriteRenderer spr;
    private Light2D Light;

    private float t = 0f;

    private bool lol = false;
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        Light = GetComponentInChildren<Light2D>();
    }

    void Update()
    {
        Light.intensity = Mathf.Lerp(0, 4.65f, t);
        spr.color = Color.Lerp(new Color(255, 255, 255, 0), new Color(255, 255, 255, 1), t);
        if (!lol)
        {
            Debug.Log("hi");
            t += 0.5f * Time.deltaTime;
            if (t >= 1.0f)
            {
                lol = true;
            }
        } else
        {
            t -= 0.5f * Time.deltaTime;
            if (t <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (lol && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("^^");
        }
    }
}
