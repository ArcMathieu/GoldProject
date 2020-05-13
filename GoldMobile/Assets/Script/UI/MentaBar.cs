using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MentaBar : MonoBehaviour
{
    private Image bar;
    private Mental mental;
    private bool illnessUp;
    private void Awake()
    {
        bar = transform.Find("bar").GetComponent<Image>();

        //bar.fillAmount = 0.4f;
        mental = new Mental();
    }

    private void Update()
    {
        if (illnessUp)
        {
            mental.increase();
        }
        else
        {
            mental.decreased();
        }
        bar.fillAmount = mental.GetMentalNormalized();
        if(bar.fillAmount == 1f)
        {
            
            Debug.Log("Loose");
            //SceneManager.LoadScene("Menu");
        }
    }

    public void modifyBar(bool increased)
    {
        illnessUp = increased;
    }

}

public class Mental
{
    public const int Mental_Max = 100;

    private float mentalAmount;
    private float mentalDamage;
    public bool mentalIncrease;
    public Mental()
    {
        mentalAmount = 0;
        mentalDamage = 1f;
    }

    public void increase()
    {
        if (mentalAmount < 100) 
        {
            mentalDamage = 1f;
            mentalAmount += mentalDamage * Time.deltaTime;
                
        }
    }
    public void decreased()
    {
        if (mentalAmount > 0)
        {
            mentalDamage = 2f;
            mentalAmount -= mentalDamage * Time.deltaTime;

        }
    }

    public float GetMentalNormalized()
    {
        return mentalAmount / Mental_Max;
    }
}

