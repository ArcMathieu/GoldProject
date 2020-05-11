using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MentaBar : MonoBehaviour
{
    private Image bar;
    private Mental mental;

    private void Awake()
    {
        bar = transform.Find("bar").GetComponent<Image>();

        //bar.fillAmount = 0.4f;
        mental = new Mental();
    }

    private void Update()
    {
        mental.Update();
        bar.fillAmount = mental.GetMentalNormalized();
        if(bar.fillAmount == 1f)
        {
            SceneManager.LoadScene("Menu");
        }
    }

}

public class Mental
{
    public const int Mental_Max = 100;

    private float mentalAmount;
    private float mentalDamage;

    public Mental()
    {
        mentalAmount = 0;
        mentalDamage = 1f;
    }

    public void Update()
    {
        mentalAmount += mentalDamage * Time.deltaTime;

    }

    public float GetMentalNormalized()
    {
        return mentalAmount / Mental_Max;
    }
}

