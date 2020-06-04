using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuScript : MonoBehaviour
{
    public GameObject timeLine;
    public GameObject line;

    public void StartMenu()
    {
        DataSaveProgress.Restart();
        timeLine.SetActive(true);
    }
    public void LoadSaveMenu()
    {
        string path = Application.persistentDataPath + "/saves.progress";
        if (File.Exists(path))
        {
            DataSaveProgress.LoadSave();
            FindObjectOfType<LoaderScene>().LoadingScene(1);
        }else
        {
            line.SetActive(true);
        }
        
    }
}
