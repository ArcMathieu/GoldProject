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
    //public bool CleParentsRoom; //Dialogue && ouvre chambre
    public bool placardMoved; //Retenir position
    public bool BrosseACheveux; //Dialogue
    public bool CleSecretaire; //openBibli
    public bool PageLivre; //Dialogue
    public bool Lockpick; //openTrappe
    public bool LivreRituel; //A colecter for ending
    public bool dague; //A colecter for ending
    public bool SecretCave;

    //door
    public bool Tuto;
    public bool DoorToSerre;
    public bool DoorToBibli;
    public bool DoorToMother;
    public bool DoorToSecreteCave;

    //obj bonus
    public bool dessin;
    public bool lettreFamille;
    public bool bibleChevet;

    //Enigme
    public bool coffre;//coffre fort de katia


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            FindObjectOfType<GameManager>().openStep();
        }
    }

}
