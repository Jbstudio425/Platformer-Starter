﻿using UnityEngine;
using UnityEngine.SceneManagement;
using LP.Saving;

namespace LP.Core
{
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Reset()
        {
            SaveLoadSystem.DeleteAllSaveFiles();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}