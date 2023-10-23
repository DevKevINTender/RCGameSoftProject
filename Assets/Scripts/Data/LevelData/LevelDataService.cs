using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Data
{
    public class LevelDataService
    {
        private const string PlayerPrefsKey = "HeroDataList";
        private LevelDataSl _levelDataSl;
        private string path = "ScrObj/";
        private List<LevelDataSo> list = new List<LevelDataSo>();

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
            LevelData levelData = new LevelData();
            levelData.LevelDataSo = list[_levelDataSl.currentLevel];
            return levelData;
        }
    }
}