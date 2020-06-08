using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public int progress;
    public ObjectsInteractable[] triggers;
    public List<GameObject> ItemToDelete;
    public GameObject TpRevive;
    public GameObject TpBoss;
    private bool revive = false;

    public void Save()
    {
        DataSaveProgress.SaveProgression(this);
    }
    public void Reestart()
    {
        progress = 0;
        DataSaveProgress.SaveProgression(this);
    }
    public void Load()
    {
        DataSave data = DataSaveProgress.LoadSave();
        progress = data.progress;
    }
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
            case 7:
                GoBoss();
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
            FindObjectOfType<PlayerManager>().transform.position = new Vector2(TpRevive.transform.position.x, TpRevive.transform.position.y);
            FindObjectOfType<GhostManager>().transform.position = new Vector2(TpRevive.transform.position.x +1, TpRevive.transform.position.y);
            triggers[1].isTrigger = false;
        }
        else
        {
            triggers[0].isReadyForCinematic = false;
            FindObjectOfType<PlayerManager>().transform.position = new Vector2(TpRevive.transform.position.x, TpRevive.transform.position.y+2);
        }
        LoadProgress();
    }

    private void UnlockStart()
    {
        //Story Bool disabled
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
        //triggersCinematique enabled
        foreach (ObjectsInteractable trigger in triggers)
        {
            trigger.isReadyForCinematic = true;
        }
        triggers[0].isReadyForCinematic = false;
        triggers[4].isReadyForCinematic = false;
        triggers[6].isReadyForCinematic = false;
        //triggers[7].isReadyForCinematic = false;
        triggers[8].isReadyForCinematic = false;
        //listObjectpickable disabled
        foreach (GameObject objects in ItemToDelete)
        {
            objects.SetActive(true);
        }
        FindObjectOfType<InventorySystem>().RemoveItems();
        //Actualise le gameManager
        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockHonoria()
    {
        UnlockStart();
        FindObjectOfType<StoryGame>().START = true;

        FindObjectOfType<StoryGame>().CollierKatia = true;
        FindObjectOfType<InventorySystem>().AddItem("CollierK");
        ItemToDelete[0].SetActive(false);

        if (revive)
        {
            triggers[0].isReadyForCinematic = true;
            triggers[0].HasTalked = false;
            triggers[0].notFirstTalkP = false;
            revive = false;
        }

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
        FindObjectOfType<StoryGame>().Secateur = true;
        FindObjectOfType<InventorySystem>().AddItem("Secateur");
        FindObjectOfType<InventorySystem>().AddItem("Recipient Rituel");
        FindObjectOfType<InventorySystem>().AddItem("Dague Ensanglantée");
        ItemToDelete[5].SetActive(false);
        ItemToDelete[1].SetActive(false);
        ItemToDelete[2].SetActive(false);
        triggers[4].isReadyForCinematic = false;//cinCouloirUp
        triggers[5].isReadyForCinematic = false;//Verre

        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockKatia()
    {
        UnlockSerre();
        FindObjectOfType<StoryGame>().coffre = true;
        FindObjectOfType<InventorySystem>().AddItem("CleChambreParents");
        ItemToDelete[8].SetActive(false);
        //trigger cin coffre

        FindObjectOfType<StoryGame>().DoorToMother = true;

        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockMotherRoom()
    {
        UnlockKatia();
        FindObjectOfType<StoryGame>().BrosseACheveux = true;
        FindObjectOfType<StoryGame>().CleSecretaire = true;
        //FindObjectOfType<StoryGame>().PageLivre = true;
        FindObjectOfType<StoryGame>().Lockpick = true;
        FindObjectOfType<InventorySystem>().AddItem("Brosse Cheveux Honoria");
        FindObjectOfType<InventorySystem>().AddItem("CleSecretaire");
        //FindObjectOfType<InventorySystem>().AddItem("Pages Manquantes");
        FindObjectOfType<InventorySystem>().AddItem("Lockpick");
        ItemToDelete[3].SetActive(false);
        ItemToDelete[9].SetActive(false);

        FindObjectOfType<StoryGame>().DoorToBibli = true;
        FindObjectOfType<StoryGame>().DoorToSecreteCave = false;
        //triggers[7].isReadyForCinematic = false;//Secretaire
        triggers[8].isReadyForCinematic = false;//Brosse
        FindObjectOfType<GameManager>().openStep();
    }
    private void UnlockBibli()
    {
        UnlockMotherRoom();
        FindObjectOfType<StoryGame>().LivreRituel = true;
        FindObjectOfType<InventorySystem>().AddItem("Livre Rituel");
        ItemToDelete[4].SetActive(false);
        for (int i = 9; i < 16; i++)
        {
            triggers[i].isReadyForCinematic = false;//Bibli
        }
        triggers[6].isReadyForCinematic = false;//cinAfterCoffre
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
    private void GoBoss()
    {
        UnlockSecreteCave();
        FindObjectOfType<GameManager>().openStep();
        FindObjectOfType<PlayerManager>().transform.position = new Vector2(TpBoss.transform.position.x + 1, TpBoss.transform.position.y);
        FindObjectOfType<GhostManager>().transform.position = new Vector2(TpBoss.transform.position.x, TpBoss.transform.position.y - 1);
    }
}

