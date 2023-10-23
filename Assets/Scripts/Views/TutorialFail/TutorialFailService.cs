using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views.TutorialPractice.Page;
using Zenject;

namespace Views.TutorialFail
{
    public class TutorialFailService
    {
        private TutorialFailView _tutorialFailView;
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
            TutorialFailView tutorialFailViewPb = _prefabsStorageService.GetPrefabByType<TutorialFailView>();
            Transform anchorPanel = _tutorialPageService.GetTransformByMarker<FullSizePanelMarker>();
            _tutorialFailView = MonoBehaviour.Instantiate(tutorialFailViewPb, anchorPanel);
            _tutorialFailView.ActivateView(Restart);
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}