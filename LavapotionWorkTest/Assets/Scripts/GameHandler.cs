using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private GameObject playerObject = null;

    void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        SaveObject save = new SaveObject {
            playerScore = playerObject.GetComponent<Collector>().,
            playerPosition = new Vector3(0,0,0)
        };

        string json = JsonUtility.ToJson(save);
        Debug.Log(json);

        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
        Debug.Log(loadedSaveObject.playerPosition);
    }

    void Update()
    {
        
    }

    public class SaveObject
    {
        public int playerScore = 0;
        public Vector3 playerPosition = Vector3.zero;
    }
}
