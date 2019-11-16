using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;

    void Awake()
    {
        if(instance == null) instance =  this;
        else if(instance != this) Destroy(gameObject);
         DontDestroyOnLoad(gameObject);        
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

            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            playerObject.transform.position = saveObj.playerPosition;

            playerObject.GetComponent<Collector>().SetPoints(saveObj.playerScore);

            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
            List<GameObject> coinsToDestroy = new List<GameObject>();

            for(int i = 0; i < coins.Length; i++){
                if(i < saveObj.coinsPosition.Count){
                    coins[i].transform.position = saveObj.coinsPosition[i];
                }
                else{
                    coinsToDestroy.Add(coins[i]);
                }
            }
            foreach(GameObject coin in coinsToDestroy){
                Destroy(coin);
            }
            
        }
        else{
            Debug.Log("No save file found!");
        }
    }

    IEnumerator LoadLevel (string sceneName)
    {
        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        
        while (!asyncLoadLevel.isDone){
            print("Loading the Scene"); 
            yield return null;
        }
    }
    
    private void Save()
    {
        SaveData saveObj = new SaveData();
        GetInfoFromLevel(saveObj);

        string json = JsonUtility.ToJson(saveObj);
        SaveSystem.Save(json);
    }

    private void GetInfoFromLevel(SaveData data)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        data.playerScore = player.GetComponent<Collector>().GetPoints();
        data.playerPosition = player.transform.position;

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Coin")){
            data.coinsPosition.Add(obj.transform.position);
        }

        data.sceneName = SceneManager.GetActiveScene().name;
    }

    public class SaveData
    {
        public int playerScore = 0;
        public Vector3 playerPosition = Vector3.zero;
        public List<Vector3> coinsPosition = new List<Vector3>();
        public string sceneName = null;
    }
}
