using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeur : MonoBehaviour
{
    public float currentTime = 0;

   // [SerializeField] Text compteur;


    //Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
       // compteur.text = currentTime.ToString("0");
       // int second = (int)(currentTime % 60);
       // int minute = (int)(currentTime / 60);


        //string timerString = string.Format("{0:0}:{1:00}", minute, second);

        //compteur.text = timerString;


        if (currentTime >= 600)  // && rajouter une condition pour quand le jeu se termine
        {
            FindObjectOfType<Achievement>().UnlockTripleParked();

        }

    }

}
