using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5)){
            Save();
        }

        if(Input.GetKeyDown(KeyCode.F8)){
            Load();
        }       
    }

    void Save()
    {
        TestData newData = new TestData{
            playerScore = 5
        };
        
        Debug.Log(JsonUtility.ToJson(newData));
        SaveLoadSystem.Save(newData, "TestData");
        Debug.Log("Saved");
    }

    void Load()
    {

    }

    public class TestData
    {
        public int playerScore = 0;
    } 
}
