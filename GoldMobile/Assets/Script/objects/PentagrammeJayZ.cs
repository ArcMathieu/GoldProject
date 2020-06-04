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

        if (!lol)
        {
            //  spr.color = Color.Lerp(new Color(255, 255, 255, 0), new Color(255, 255, 255, 1), t);
            t += 0.8f * Time.deltaTime;
            //if (t >= 1.0f)
            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                lol = true;
            }
        }
        else
        {
            spr.color = Color.Lerp(new Color(255, 0, 0, 0), new Color(255, 0, 0, 1), t);
            t -= 0.3f * Time.deltaTime;
            if (t <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lol && collision.gameObject.CompareTag("Player"))
        {
        //    FindObjectOfType<DarkJayZ>().Player.GetComponentInChildren<SpriteRenderer>().enabled = false;
            StartCoroutine(FindObjectOfType<DarkJayZ>().GameOver());
        }
    }
}
