using Services;
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
        
        [Inject]
        public void Construct(TutorialPageService tutorialPageService, PrefabsStorageService prefabsStorageService)
        {
            _tutorialPageService = tutorialPageService;
            _prefabsStorageService = prefabsStorageService;
        }

        public void ActivateService()
        {
            TutorialCompleteView tutorialCompleteViewPb = _prefabsStorageService.GetPrefabByType<TutorialCompleteView>();
            Transform anchorPanel = _tutorialPageService.GetTransformByMarker<FullSizePanelMarker>();
            _tutorialCompleteView = MonoBehaviour.Instantiate(tutorialCompleteViewPb, anchorPanel);
            _tutorialCompleteView.ActivateView(Restart);
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}