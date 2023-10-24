using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;

namespace Data
{
    public class LevelDataService
    {
        private const string PlayerPrefsKey = "HeroDataList";
        private LevelDataSl _levelDataSl;
       
        private string path = "ScrObj/";
        private List<LevelDataSo> list = new List<LevelDataSo>();

        private LevelData _levelData;

        public LevelDataService()
        {
            list.AddRange(Resources.LoadAll<LevelDataSo>(path));
            LoadLevelData();
        }
        
        private void SaveLevelData()
        {
            string heroDataJson = JsonConvert.SerializeObject(_levelDataSl);
            PlayerPrefs.SetString(PlayerPrefsKey, heroDataJson);
            PlayerPrefs.Save();
        }

        // Метод для загрузки данных из PlayerPrefs
        private void LoadLevelData()
        {
            if (PlayerPrefs.HasKey(PlayerPrefsKey))
            {
                string heroDataJson = PlayerPrefs.GetString(PlayerPrefsKey);
                _levelDataSl = JsonConvert.DeserializeObject<LevelDataSl>(heroDataJson);
            }
            else
            {
                _levelDataSl = new LevelDataSl();
                _levelDataSl.currentLevel = 0;
                SaveLevelData();
            }
        }

        public void CreateCustomLevelDataSl(LevelDataSl levelDataSl)
        {
            _levelDataSl = levelDataSl;
            SaveLevelData();
        }
        
        public List<LevelDataSo> GetLevelsData()
        {
            return list;
        }

        public LevelData GetCurrentLevelData()
        {
            if(_levelData == null) _levelData = new LevelData();
            _levelData.LevelDataSo = list[_levelDataSl.currentLevel];
            _levelData.LevelDataSl = _levelDataSl;
            return _levelData;
        }

        internal void SetCurrentLevel(int id)
        {
            if(list.Count > id)
            {
                _levelDataSl.currentLevel = id;
                SaveLevelData();
            }
        }

        internal void SetCurrentAnswer(int id)
        {
           _levelData.currentAnswer = id;
        }

        internal void RaiseLevel()
        {
            if(list.Count > _levelData.LevelDataSl.currentLevel + 1)
            {
                _levelData.LevelDataSl.currentLevel++;
                SaveLevelData();
            }
        }
    }
}