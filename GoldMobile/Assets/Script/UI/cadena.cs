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
    public GameObject itemUnlock;
    public GameObject CoffreClosed;
    public GameObject CoffreOpened;
    public GameObject joystick;
    public GameObject interactButton;
    public List<int> pasword;
    public bool noRepeat;

    public void numberUp(GameObject number)
    {
        if (number.GetComponent<currentNumber>().number + 1 > 9)
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
        //Time.timeScale = 0;
        joystick.SetActive(false);
        interactButton.SetActive(false);
    }


    public void TestCombinaison()
    {

        if (pasword[0] == number1.GetComponent<currentNumber>().number && pasword[1] == number2.GetComponent<currentNumber>().number && pasword[2] == number3.GetComponent<currentNumber>().number)
        {

           //Time.timeScale = 1;
            joystick.SetActive(true);
            interactButton.SetActive(true);
            CoffreClosed.GetComponent<ActivateLock>().CodeFound = true;
            CoffreOpened.SetActive(true);
            Cadena.SetActive(false);
            itemUnlock.SetActive(true);
            FindObjectOfType<SoundManager>().PlaySfx("Keys");

            FindObjectOfType<Achievement>().UnlockWhatinTheBox();
        }

        else
        {
            //Time.timeScale = 1;
            joystick.SetActive(true);
            interactButton.SetActive(true);
            Cadena.SetActive(false);
        }
    }
}
