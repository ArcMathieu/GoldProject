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
    private bool DoneDisplaying = true;
    private bool DoneTalking = false;


    public float displaySPD;
    private int dialState = 0;
    private int totalvisibleChara;
    private int visibleC;
    // Start is called before the first frame update
    void Start()
    {
        tmpro = TextBox.GetComponent<TextMeshProUGUI>();
        dialState = dial.LesDialogues.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (DoneDisplaying == true)
        {
            if (isAutomatique == false)
            {
                if (Input.GetKeyDown("e") && !DoneTalking)
                {
                    StartCoroutine(DisplayTextOverTime(displaySPD));
                }
                else if (Input.GetKeyDown("e") && DoneTalking)
                {
                    tmpro.text = null;
                }
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
        }
        if (DoneDisplaying == false)
        {
            tmpro.text = dial.LesDialogues[dialState];
            totalvisibleChara = tmpro.textInfo.characterCount;
        } 
    }
    IEnumerator DisplayTextOverTime(float DisplaySpd = 0.03f)
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
