using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    public static void Init()
    {
        if(!Directory.Exists(SAVE_FOLDER)){
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString)
    {
        int saveNumber = 1;
        while(File.Exists(SAVE_FOLDER + "save_" + saveNumber + ".json")){
            saveNumber++;
        }
        File.WriteAllText(SAVE_FOLDER + "/save_" + saveNumber + ".json", saveString);
    }

    public static string Load()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles("*.json");
        FileInfo recentFile = null;

        foreach(FileInfo fileInfo in saveFiles){
            if(recentFile == null){
                recentFile = fileInfo;
            }
            else{
                if(fileInfo.LastWriteTime > recentFile.LastWriteTime){
                    recentFile = fileInfo;
                }
            }
        }

        if(recentFile != null){
            string saveString = File.ReadAllText(recentFile.FullName);
            return saveString;          
        }
        else{
            return null;
        }
    }
}
