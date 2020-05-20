using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cadena : MonoBehaviour
{
    public float currentTime = 0;
    public GameObject number1;
    public GameObject number2;
    public GameObject number3;
    public GameObject Cadena;
    public GameObject Coffre;
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

    void Start()
    {
        Time.timeScale = 0;
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
                        Time.timeScale = 1;
                        currentTime += 1 * Time.deltaTime;
                        if (currentTime >= 0.7)
                        {
                            Cadena.SetActive(false);
                            Coffre.SetActive(false);
                            noRepeat = true;
                            FindObjectOfType<Achievement>().UnlockWhatinTheBox();
                        }
                    }
                }
            }
        }

    }
}
