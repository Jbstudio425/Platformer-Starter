using UnityEngine;
using System.IO;

public class SaveLoadSystem
{
    public static void Save<T>(T objectToSave, string key)
    {
        string path =  Application.persistentDataPath + "/saves/";
        if(!Directory.Exists(path)) Directory.CreateDirectory(path);

        string json = JsonUtility.ToJson(objectToSave);
        File.WriteAllText(path + key + ".json", json);

        Debug.Log("Saved");
    }

    public static T Load<T>(string key)
    {
        string path =  Application.persistentDataPath + "/saves/";
        string json = File.ReadAllText(path + key + ".json"); 
        
        T returnValue = default(T);
        if(json != null) returnValue = JsonUtility.FromJson<T>(json);

        Debug.Log("Loaded");

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
        directory.Delete(true);
        Directory.CreateDirectory(path);
    }
}
