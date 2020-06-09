using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataSave
{
    public int progress;
    public bool getObjRit1;
    public bool getObjRit2;

    public DataSave(SaveSystem save)
    {
        progress = save.progress;
        getObjRit1 = save.getObjRit1;
        getObjRit2 = save.getObjRit2;
    }
}
