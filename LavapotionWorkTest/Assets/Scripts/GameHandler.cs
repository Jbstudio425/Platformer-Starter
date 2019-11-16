using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour
{
    private GameObject playerObject = null;

    void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        SaveSystem.Init();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5)){
            Save();
        }

        if(Input.GetKeyDown(KeyCode.F8)){
            Load();
        }
    }

    private void Load()
    {
        string saveString = SaveSystem.Load();
        
        if(saveString != null){
            SaveData saveObj = JsonUtility.FromJson<SaveData>(saveString);

            playerObject.transform.position = saveObj.playerPosition;
            playerObject.GetComponent<Collector>().SetPoints(saveObj.playerScore);
        }
        else{
            Debug.Log("No save file found!");
        }
    }

    private void Save()
    {
        Vector3 position = playerObject.transform.position;
        int score = playerObject.GetComponent<Collector>().GetPoints();

        SaveData saveObj = new SaveData {
            playerScore = score,
            playerPosition = position
        };

        string json = JsonUtility.ToJson(saveObj);
        SaveSystem.Save(json);
    }

    public class SaveData
    {
        public int playerScore = 0;
        public Vector3 playerPosition = Vector3.zero;
    }
}
