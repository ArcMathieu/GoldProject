using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cadena : MonoBehaviour
{
    public GameObject number1;
    public GameObject number2;
    public GameObject number3;
    public GameObject Cadena;
    public List<int> pasword;
    public bool noRepeat;

    public void numberUp(GameObject number)
    {
        if(number.GetComponent<currentNumber>().number + 1 > 9)
        {
            number.GetComponent<currentNumber>().number = 0;
        }
        else
        {
            number.GetComponent<currentNumber>().number++;
            FindObjectOfType<SoundManager>().PlaySfx("Roulette");
        }

    }

    public void numberDown(GameObject number)
    {
        if (number.GetComponent<currentNumber>().number - 1 < 0)
        {
            number.GetComponent<currentNumber>().number = 9;
        }
        else
        {
            number.GetComponent<currentNumber>().number--;
            FindObjectOfType<SoundManager>().PlaySfx("Roulette");
        }
    }

    private void Start()
    {
    
    }

    private void Update()
    {
       if(!noRepeat)
       {
            if (pasword[0] == number1.GetComponent<currentNumber>().number)
            {
                if (pasword[1] == number2.GetComponent<currentNumber>().number)
                {
                    if (pasword[2] == number3.GetComponent<currentNumber>().number)
                    {
                        Debug.Log("coucou");
                        //Cadena.SetActive(false);
                        noRepeat = true;
                        FindObjectOfType<Achievement>().UnlockWhatinTheBox();
                    }
                }
            }
        }
    }
}
