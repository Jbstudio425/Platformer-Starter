using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataSet : MonoBehaviour
{
    //public HashSet<string> removedObjects {get; private set; } = new HashSet<string>();
    public List<string> removedObjects {get; private set; } = new List<string>();
    
    private void Awake()
    {
        GameEvents.SaveInitiated += Save;
        GameEvents.LoadInitiated += Load;
        Load();
    }

    void Save()
    {
        Debug.Log(removedObjects);
        SaveLoadSystem.Save(removedObjects, "RemovedObjects");
    }

    void Load()
    {
        if(SaveLoadSystem.SaveExists("RemovedObjects")){
            removedObjects = SaveLoadSystem.Load<List<string>>("RemovedObjects");
        }
    }
}
