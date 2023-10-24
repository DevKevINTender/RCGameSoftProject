using Assets.Scripts.Services;
using Services;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views.TutorialPractice.Page;
using Zenject;

namespace Views.TutorialComplete
{
    public class TutorialCompleteService
    {
        private TutorialCompleteView _tutorialCompleteView;
        private TutorialPageService _tutorialPageService;
        private PrefabsStorageService _prefabsStorageService;
        private TuttorialChalengeSetLevelService _tuttorialChalengeService;

        [Inject]
        public void Construct(TutorialPageService tutorialPageService, PrefabsStorageService prefabsStorageService, TuttorialChalengeSetLevelService tuttorialChalengeService)
        {
            _tutorialPageService = tutorialPageService;
            _prefabsStorageService = prefabsStorageService;
            _tuttorialChalengeService = tuttorialChalengeService;
        }

        public void ActivateService()
        {
            TutorialCompleteView tutorialCompleteViewPb = _prefabsStorageService.GetPrefabByType<TutorialCompleteView>();
            Transform anchorPanel = _tutorialPageService.GetTransformByMarker<FullSizePanelMarker>();
            _tutorialCompleteView = MonoBehaviour.Instantiate(tutorialCompleteViewPb, anchorPanel);
            _tutorialCompleteView.ActivateView(Restart, StartTuttorialChalenge, OpenMenu);

        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void StartTuttorialChalenge()
        {
            _tuttorialChalengeService.CompleteLevel();
            SceneManager.LoadScene((int)Scenes.TuttorialChalenge);
        }

        private void OpenMenu()
        {
            SceneManager.LoadScene((int)Scenes.Menu);
        }
    }
}