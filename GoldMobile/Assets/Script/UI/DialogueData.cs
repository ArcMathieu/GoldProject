using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue", order = 1)]
public class DialogueData : ScriptableObject
{
    public List<string> LesDialogues;
    public List<float> SpeedDialogues;
}
