using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private int progress;

    private void LoadProgress()
    {
        switch (progress)
        {
            case 0:
                UnlockStart();
                break;
            case 1:
                UnlockHonoria();
                break;
            case 2:
                UnlockKatia();
                break;
            case 3:
                UnlockSerre();
                break;
            case 4:
                UnlockMotherRoom();
                break;
            case 5:
                UnlockBibli();
                break;
            case 6:
                UnlockSecreteCave();
                break;
            default:
                UnlockStart();
                break;
        }
        
    }
    private void UnlockStart()
    {
        FindObjectOfType<StoryGame>().START = false;
        //Honoria
        FindObjectOfType<StoryGame>().CollierKatia = false;
        //cave
        FindObjectOfType<StoryGame>().Secateur = false;
        //serre
        FindObjectOfType<StoryGame>().BolRituel = false;
        FindObjectOfType<StoryGame>().dague = false;
        FindObjectOfType<StoryGame>().journalHonoria = false;
        //katia
        FindObjectOfType<StoryGame>().coffre = false;
        //mother
        FindObjectOfType<StoryGame>().BrosseACheveux = false;
        FindObjectOfType<StoryGame>().CleSecretaire = false;
        FindObjectOfType<StoryGame>().PageLivre = false;
        FindObjectOfType<StoryGame>().Lockpick = false;
        //bibli
        FindObjectOfType<StoryGame>().LivreRituel = false;

        FindObjectOfType<StoryGame>().DoorToSerre = false;
        FindObjectOfType<StoryGame>().DoorToBibli = false;
        FindObjectOfType<StoryGame>().DoorToMother = false;
        FindObjectOfType<StoryGame>().DoorToSecreteCave = false;

        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockHonoria()
    {
        UnlockStart();
        FindObjectOfType<StoryGame>().START = true;
        FindObjectOfType<StoryGame>().CollierKatia = true;
        //trigger cin salon
        //trigger cin before room 
        //trigger cin room 

        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockKatia()
    {
        UnlockHonoria();
        FindObjectOfType<StoryGame>().coffre = true;
        //trigger cin coffre

        FindObjectOfType<StoryGame>().DoorToMother = true;

        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockSerre()
    {
        UnlockHonoria();
        FindObjectOfType<StoryGame>().BolRituel = true;
        FindObjectOfType<StoryGame>().dague = true;
        //trigger cin verre 

        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockMotherRoom()
    {
        UnlockKatia();
        FindObjectOfType<StoryGame>().BrosseACheveux = true;
        FindObjectOfType<StoryGame>().CleSecretaire = true;
        FindObjectOfType<StoryGame>().PageLivre = true;
        FindObjectOfType<StoryGame>().Lockpick = true;

        FindObjectOfType<StoryGame>().DoorToBibli = true;
        FindObjectOfType<StoryGame>().DoorToSecreteCave = false;

        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockBibli()
    {
        UnlockMotherRoom();
        FindObjectOfType<StoryGame>().LivreRituel = true;
        //trigger cin enter

        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockSecreteCave()
    {
        UnlockBibli();
        //trigger cin before take trappe
        //trigger cin enter
        //trigger cin drap
        //trigger cin bougie

        FindObjectOfType<GameManager>().openStep();
    }
}

