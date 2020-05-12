using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameObject P1;
    public GameObject P2;

    public float playerSpeed;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ChangeCamera(bool cam)
    {
        if (!cam)
        {
            P1.gameObject.SetActive(true);
            P2.gameObject.SetActive(false);
        }else if (cam)
        {
            P1.gameObject.SetActive(false);
            P2.gameObject.SetActive(true);
        }
    }
}
