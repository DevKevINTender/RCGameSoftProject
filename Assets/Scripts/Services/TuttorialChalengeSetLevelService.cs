using Data;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Services
{
    public class TuttorialChalengeSetLevelService
    {
        private LevelDataService _levelDataService;

        [Inject]
        public void Constructor(LevelDataService levelDataService)
        {
            _levelDataService = levelDataService;
            Debug.Log("level: " + levelDataService.GetCurrentLevelData().LevelDataSl.currentLevel);
        }

        public void SetTuttorialLevel()
        {
            
        }

        public void CompleteLevel()
        {
            _levelDataService.RaiseLevel();
        }
    }
}