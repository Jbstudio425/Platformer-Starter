using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5)){
            Save();
        }

        if(Input.GetKeyDown(KeyCode.F8)){
            Load();
        }     

        if(Input.GetKeyDown(KeyCode.F1)){
            Reset();
        }    
    }
    
    private void Save()
    {
        GameEvents.OnSaveInitiated();
    }

    private void Load()
    {
        GameEvents.OnLoadInitiated();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Reset()
    {
        SaveLoadSystem.DeleteAllSaveFiles();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
