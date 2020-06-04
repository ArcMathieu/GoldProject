using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataSave
{
    public int progress;

    public DataSave(SaveSystem save)
    {
        progress = save.progress;
    }
}
