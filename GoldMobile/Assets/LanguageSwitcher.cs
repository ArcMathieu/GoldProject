using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSwitcher : MonoBehaviour
{
  public static bool English;

    public GameObject Eng;
    public GameObject Fra;

    void Start()
    {
   //    DontDestroyOnLoad(this.gameObject);
    }
    public void ChangeLanguage()
    {
        if (English == false)
        {
            Eng.SetActive(true);
            Fra.SetActive(false);
            English = true;
        }
        else
        {
            Fra.SetActive(true);
            Eng.SetActive(false);
            English = false;
        }


    }
}
