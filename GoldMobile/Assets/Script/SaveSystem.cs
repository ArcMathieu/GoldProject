using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public int progress;
    public ObjectsInteractable[] triggers;
    public GameObject TpRevive;
    private bool revive = false;
    public void LoadProgress()
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
                UnlockSerre();
                break;
            case 3:
                UnlockKatia();
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

    public void Revive()
    {
        revive = true;
        if (progress > 0)
        {
            FindObjectOfType<PlayerManager>().transform.position = TpRevive.transform.position;
            FindObjectOfType<GhostManager>().transform.position = new Vector2(TpRevive.transform.position.x +1, TpRevive.transform.position.y);

        }
        else
        {
            FindObjectOfType<PlayerManager>().transform.position = TpRevive.transform.position;
        }
        LoadProgress();
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
        //door
        FindObjectOfType<StoryGame>().DoorToSerre = false;
        FindObjectOfType<StoryGame>().DoorToBibli = false;
        FindObjectOfType<StoryGame>().DoorToMother = false;
        FindObjectOfType<StoryGame>().DoorToSecreteCave = false;
        foreach (ObjectsInteractable trigger in triggers)
        {
            trigger.isReadyForCinematic = true;
        }
        if (revive)
        {
            triggers[0].isReadyForCinematic = true;
            triggers[0].HasTalked = false;
            triggers[1].isReadyForCinematic = false;
            revive = false;
        }
        else
        {
            triggers[0].isReadyForCinematic = false;
            triggers[1].isReadyForCinematic = true;
        }
        triggers[4].isReadyForCinematic = false;
        triggers[6].isReadyForCinematic = false;
        triggers[7].isReadyForCinematic = false;
        triggers[8].isReadyForCinematic = false;
        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockHonoria()
    {
        UnlockStart();
        FindObjectOfType<StoryGame>().START = true;
        FindObjectOfType<StoryGame>().CollierKatia = true;

        triggers[1].isReadyForCinematic = false;//trigger cin salon
        triggers[2].isReadyForCinematic = false;//trigger cin before room 
        triggers[3].isReadyForCinematic = false;//trigger cin Hroom

        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockSerre()
    {
        UnlockHonoria();
        FindObjectOfType<StoryGame>().BolRituel = true;
        FindObjectOfType<StoryGame>().dague = true;
        triggers[4].isReadyForCinematic = false;//cinCouloirUp
        triggers[5].isReadyForCinematic = false;//Verre

        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockKatia()
    {
        UnlockSerre();
        FindObjectOfType<StoryGame>().coffre = true;
        //trigger cin coffre

        FindObjectOfType<StoryGame>().DoorToMother = true;

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
        triggers[6].isReadyForCinematic = false;//cinAfterCoffre
        triggers[7].isReadyForCinematic = false;//Secretaire
        triggers[8].isReadyForCinematic = false;//Brosse
        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockBibli()
    {
        UnlockMotherRoom();
        FindObjectOfType<StoryGame>().LivreRituel = true;
        for (int i = 9; i < 16; i++)
        {
            triggers[i].isReadyForCinematic = false;//Bibli
        }

        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockSecreteCave()
    {
        UnlockBibli();
        triggers[16].isReadyForCinematic = false;//trigger cin in trappe
        triggers[17].isReadyForCinematic = false;//trigger cin drap
        triggers[18].isReadyForCinematic = false;//trigger cin bougie

        FindObjectOfType<GameManager>().openStep();
    }
}

