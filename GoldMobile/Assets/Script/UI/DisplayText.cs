using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI tmpro;
    public GameObject TextBox;
    public DialogueData dial;

    public bool isAutomatique = false;
    public bool DoneDisplaying = true;
    public bool DoneTalking = false;

    public float displaySPD;
    private int dialState = 0;
    private int totalvisibleChara;
    private int visibleC;
    public AudioSource Audio;
    public AudioClip KeyStroke;

    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Audio = GetComponent<AudioSource>();
        tmpro = TextBox.GetComponent<TextMeshProUGUI>();
    }

    public void DialPass(DialogueData thisDial)
    {
        dial = thisDial;
        dialState = -1;
        DoneDisplaying = true;
        DoneTalking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (DoneDisplaying == true)
        {
            if (isAutomatique)
            {
                if (!DoneTalking)
                {
                    StartCoroutine(DisplayTextOverTime(displaySPD));
                }
                else
                {
                    tmpro.text = null;
                }
            }
        }
        else if (DoneDisplaying == false)
        {
            tmpro.text = dial.LesDialogues[dialState];
            totalvisibleChara = tmpro.textInfo.characterCount;
        }
    }

    public bool FirstTalk = true;
    private bool WantsToSkip = false;
    public void NextDial()
    {

        if (FirstTalk == true)
        {
            FirstTalk = false;
            StartCoroutine(DisplayTextOverTime(displaySPD));
        }
        else {
            if (!DoneDisplaying)
            {
                WantsToSkip = true;
                tmpro.maxVisibleCharacters = totalvisibleChara;
               Debug.Log("skip");
            }
            else
            {
               
                if (!DoneTalking)
                {
                    StartCoroutine(DisplayTextOverTime(displaySPD));
                }
                else
                {
                    foreach (GameObject inter in Player.GetComponent<PlayerManager>().CurrentInteraction)
                    {
                        //Anti loop
                        if (inter.GetComponent<ObjectsInteractable>().DoorSytem != null)
                        {
                            inter.GetComponent<ObjectsInteractable>().UnlockTheDoor();
                        }
                        if (inter.GetComponent<ObjectsInteractable>().HasTalked && !inter.GetComponent<ObjectsInteractable>().isTrigger)
                        {
                            inter.GetComponent<ObjectsInteractable>().PickUpObject();
                        }

                        if (inter.GetComponent<ObjectsInteractable>().isTrigger)
                        {
                            inter.GetComponent<ObjectsInteractable>().HasTalked = true;
                        }
                        //if (inter.GetComponent<ObjectsInteractable>().LockSytem != null)
                        //{
                        //    inter.GetComponent<ObjectsInteractable>().LockSytem.Action(Player);
                        //}
                        FirstTalk = true;
                        tmpro.text = null;
                        if(inter.GetComponent<ObjectsInteractable>().LockSytem == null && !inter.GetComponent<ObjectsInteractable>().isTrigger)
                        Destroy(inter.gameObject);
                    }
                }
            }
        }

    }
    public IEnumerator DisplayTextOverTime(float DisplaySpd = 0.03f)
    {


        if (dialState >= dial.LesDialogues.Count - 1)
        {
            dialState = 0;
        }
        else
        {
            dialState++;
        }

        if (dial.SpeedDialogues[dialState] != 0)
        {
            DisplaySpd = dial.SpeedDialogues[dialState];
            displaySPD = dial.SpeedDialogues[dialState];
        }
        else
        {
            DisplaySpd = 0.02f;
            displaySPD = 0.02f;
        }
        DoneDisplaying = false;
        int counter = 0;
        while (!DoneDisplaying)
        {
            {
                if (Time.timeScale == 1)
                {
                    Audio.pitch = Random.Range(0.9f, 1.1f);
                    Audio.Play();
                }
                if (!WantsToSkip)
                {
                    visibleC = counter % (totalvisibleChara + 1);
                    tmpro.maxVisibleCharacters = visibleC;
                }

                if (visibleC >= totalvisibleChara)
                    yield return new WaitForSeconds(0.2f);
                counter++;
                yield return new WaitForSeconds(DisplaySpd);
            }
            if (visibleC == totalvisibleChara || WantsToSkip == true)
            {

                if (dialState >= dial.LesDialogues.Count - 1)
                {
                    DoneDisplaying = true;
                    DoneTalking = true;
                    WantsToSkip = false;
               
                    foreach (GameObject inter in Player.GetComponent<PlayerManager>().CurrentInteraction)
                    {
                        if (inter.GetComponent<ObjectsInteractable>().DoorSytem != null)
                        {
                            inter.GetComponent<ObjectsInteractable>().UnlockTheDoor();
                        }
                        if (inter.GetComponent<ObjectsInteractable>().isPickable && inter.GetComponent<ObjectsInteractable>().Cinematic == null && !inter.GetComponent<ObjectsInteractable>().isTrigger)
                           
                        { 
                            inter.GetComponent<ObjectsInteractable>().PickUpObject();
                        }
                        if (inter.GetComponent<ObjectsInteractable>().LockSytem != null)
                        {
                            inter.GetComponent<ObjectsInteractable>().LockSytem.Action(Player);
                            tmpro.text = null;
                        }
                   
                    }
                }
                else
                {
                    if (isAutomatique)
                    {
                        yield return new WaitForSeconds(1f);
                    }
                    else
                    {
                        yield return new WaitForSeconds(displaySPD);
                    }
                    WantsToSkip = false;
                    DoneDisplaying = true;
                }
            }
        }
    }
}
