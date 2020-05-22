using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    private TextMeshProUGUI tmpro;
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
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        tmpro = TextBox.GetComponent<TextMeshProUGUI>();
    }

    public void DialPass(DialogueData thisDial)
    {
        dial = thisDial;
        dialState = - 1;
        DoneDisplaying = true;
        DoneTalking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (DoneDisplaying == true)
        {
            if (isAutomatique == false)
            {
                NextDial();
            } else
            {
                if (!DoneTalking)
                {
                    StartCoroutine(DisplayTextOverTime(displaySPD));
                } else
                {
                    tmpro.text = null;
                }
            }
        } else if (DoneDisplaying == false)
        {
            tmpro.text = dial.LesDialogues[dialState];
            totalvisibleChara = tmpro.textInfo.characterCount;
        } 
    }

    public void NextDial()
    {
        if (!DoneTalking)
        {
            StartCoroutine(DisplayTextOverTime(displaySPD));
        }
        else if (DoneTalking)
        {
            tmpro.text = null;
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
            if (Time.timeScale == 1)
            {
                Audio.pitch = Random.Range(0.9f, 1.1f);
                Audio.Play();
            }
            visibleC = counter % (totalvisibleChara + 1);
            tmpro.maxVisibleCharacters = visibleC;

            if (visibleC >= totalvisibleChara)
                yield return new WaitForSeconds(0.2f);
            counter++;
            yield return new WaitForSeconds(DisplaySpd);

            if (visibleC == totalvisibleChara)
            {

                if (dialState >= dial.LesDialogues.Count - 1)
                {
                    yield return new WaitForSeconds(1f);
                        DoneDisplaying = true;
                    DoneTalking = true;
                }
                else
                {
                    if (isAutomatique)
                    {
                        yield return new WaitForSeconds(1f);
                    } else
                    {
                        yield return new WaitForSeconds(displaySPD);
                    }
                    DoneDisplaying = true;
                }
            }
        }
    }
}
