﻿using System.Collections.Generic;
using UnityEngine;
using LP.Core;

namespace LP.Saving
{
    public interface ISceneDataSet
    {
        void Add(string id);
        bool Contains(string id);
    }

    public class SceneDataSet : ISceneDataSet
    {
        private  HashSet<string> removedObjectsSet = new HashSet<string>();

        private SceneDataSet()
        {
            GameEvents.SaveInitiated += Save;
            Load();
        }

        public void Add(string id)
        {
            removedObjectsSet.Add(id);
        }

        public bool Contains(string id)
        {
            return removedObjectsSet.Contains(id);
        }

        private void Save()
        {
            SaveData saveObj = new SaveData();
            GetLevelInfo(saveObj);
            SaveLoadSystem.Save(saveObj, "SaveData");
        }

        private void Load()
        {
            if(SaveLoadSystem.SaveExists("SaveData")){
                SaveData saveObj = new SaveData();
                saveObj = SaveLoadSystem.Load<SaveData>("SaveData");
                SetLevelInfo(saveObj);
            }
        }

        private void SetLevelInfo(SaveData data)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Collector>().SetPoints(data.playerScore);
            player.transform.position = data.playerPosition;

            removedObjectsSet.Clear();

            foreach(string str in data.removedObjects){
                removedObjectsSet.Add(str);
            }
        }

        private void GetLevelInfo(SaveData data)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            data.playerScore = player.GetComponent<Collector>().GetPoints();
            data.playerPosition = player.transform.position;

            foreach(string str in removedObjectsSet){
                data.removedObjects.Add(str);
            }
        }

        public class SaveData
        {
            public List<string> removedObjects = new List<string>();
            public Vector3 playerPosition = Vector3.zero;
            public int playerScore = 0;
        }
    }
}
