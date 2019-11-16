using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    public static void Save<T>(T objectToSave, string key)
    {
        string path =  Application.persistentDataPath + "/saves/";
        Directory.CreateDirectory(path);
        string json = null;

        using (FileStream fileStream = new FileStream(path + key + ".json", FileMode.Create))
        {
            json = JsonUtility.ToJson(objectToSave);
        }
    }

    public static T Load<T>(string key)
    {
        string path =  Application.persistentDataPath + "/saves/";
        string json = null;
        
        using (FileStream fileStream = new FileStream(path + key + ".json", FileMode.Open))
        {
            json = fileStream.ToString();
        }
        
        T returnValue = default(T);
        if(json != null) returnValue = JsonUtility.FromJson<T>(json);

        return returnValue;
    }

    public static bool SaveExists(string key)
    {
        string path =  Application.persistentDataPath + "/saves/" + key + ".json";
        return File.Exists(path);
    }

    public static void DeleteAllSaveFiles()
    {
        string path =  Application.persistentDataPath + "/saves/";
        DirectoryInfo directory = new DirectoryInfo(path); 
        directory.Delete();
        Directory.CreateDirectory(path);
    }
}
