using Data;
using Services;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Views.MainMenuPages
{
    public class MainMenuPageService
    {
        private LevelDataService _levelDataService;
        private MainMenuPagesView _mainMenuPagesView;
        private PrefabsStorageService _prefabsStorageService;
        
        [Inject]
        public void Constract(PrefabsStorageService prefabsStorageService, LevelDataService levelDataService)
        {
            _prefabsStorageService = prefabsStorageService;
            _levelDataService = levelDataService;
        }

        public void ActivateService()
        {
            _mainMenuPagesView = MonoBehaviour.Instantiate(_prefabsStorageService.GetPrefabByType<MainMenuPagesView>());
            _mainMenuPagesView.InitView(StartTuttorialInfo, StartChallenge);
        }

        public void StartTuttorialInfo()
        {
            SceneManager.LoadScene((int)Scenes.TuttorialInfo);
        }

        public void StartChallenge(int id)
        {
            _levelDataService.SetCurrentLevel(id);
            SceneManager.LoadScene((int)Scenes.TuttorialChalenge);
        }
    }
}