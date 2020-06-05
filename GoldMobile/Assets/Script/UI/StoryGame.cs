using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGame : MonoBehaviour
{
    //début du jeu
    public bool START;
          
    //fin du jeu
    public bool cinENDING;
          
    //objectPicked
    public bool CollierKatia; //ouvre la chambre Honoria
    public bool Secateur; //enleve ronces dans la serre
    public bool BolRituel; //A colecter for ending
    public bool journalHonoria; //Dialogue
    public bool BrosseACheveux; //Dialogue
    public bool CleSecretaire; //openBibli
    public bool PageLivre; //Dialogue
    public bool Lockpick; //openTrappe
    public bool LivreRituel; //A colecter for ending
    public bool dague; //A colecter for ending
           
    //door 
    public bool DoorToSerre;
    public bool DoorToBibli;
    public bool DoorToMother;
    public bool DoorToSecreteCave;
          
    //Enigme
    public bool coffre;//coffre fort de katia


    private void Update()
    {
        if (Input.GetKeyDown("[1]"))
        {
            FindObjectOfType<SaveSystem>().progress = 0;
            FindObjectOfType<SaveSystem>().LoadProgress();
        }
        if (Input.GetKeyDown("[2]"))
        {
            FindObjectOfType<SaveSystem>().progress = 1;
            FindObjectOfType<SaveSystem>().LoadProgress();
        }
        if (Input.GetKeyDown("[3]"))
        {
            FindObjectOfType<SaveSystem>().progress = 2;
            FindObjectOfType<SaveSystem>().LoadProgress();
        }
        if (Input.GetKeyDown("[4]"))
        {
            FindObjectOfType<SaveSystem>().progress = 3;
            FindObjectOfType<SaveSystem>().LoadProgress();
        }
        if (Input.GetKeyDown("[5]"))
        {
            FindObjectOfType<SaveSystem>().progress = 4;
            FindObjectOfType<SaveSystem>().LoadProgress();
        }
        if (Input.GetKeyDown("[6]"))
        {
            FindObjectOfType<SaveSystem>().progress = 5;
            FindObjectOfType<SaveSystem>().LoadProgress();
        }
        if (Input.GetKeyDown("[7]"))
        {
            FindObjectOfType<SaveSystem>().progress = 6;
            FindObjectOfType<SaveSystem>().LoadProgress();
        }
        if (Input.GetKeyDown("[8]"))
            FindObjectOfType<SaveSystem>().Save();
        if (Input.GetKeyDown("[9]"))
            FindObjectOfType<SaveSystem>().Load();
        if (Input.GetKeyDown("[0]"))
            FindObjectOfType<SaveSystem>().Revive();
    }

    public void load1(int number)
    {
        FindObjectOfType<SaveSystem>().progress = number;
        FindObjectOfType<SaveSystem>().Revive();
    }

}
