using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataSaveProgress
{
    public static bool isStart;
   public static void SaveProgression(SaveSystem save)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saves.progress";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataSave data = new DataSave(save);

        formatter.Serialize(stream, data);
        stream.Close();
    }
   public static DataSave LoadSave()
    {
        isStart = true;

        string path = Application.persistentDataPath + "/saves.progress";
        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataSave data = formatter.Deserialize(stream) as DataSave;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    
    public static void Restart()
    {
        isStart = false;
    }
}
