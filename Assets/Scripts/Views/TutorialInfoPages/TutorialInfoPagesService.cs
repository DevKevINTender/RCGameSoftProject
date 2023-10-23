using System;
using Services;
using StateMachines;
using UnityEngine;
using Views.TutorialPractice.Page;
using Zenject;

namespace Views.Pages
{
    public class TutorialInfoPagesService: IServiceState
    {
        private TutorialInfoPagesView _tutorialInfoPagesView;
        private TutorialNavPanelService _tutorialNavPanelService;
        private TutorialInfoState _tutorialInfoState;
        private PrefabsStorageService _prefabsStorageService;

        private Action _completeTutorialInfo;
        
        [Inject]
        public TutorialInfoPagesService(TutorialNavPanelService tutorialNavPanelService, PrefabsStorageService prefabsStorageService)
        {
            _tutorialNavPanelService = tutorialNavPanelService;
            _prefabsStorageService = prefabsStorageService;
        }

        public void ActivateService(Action completeTutorialInfo)
        {
            _completeTutorialInfo = completeTutorialInfo;
            _tutorialInfoPagesView = MonoBehaviour.Instantiate(_prefabsStorageService.GetPrefabByType<TutorialInfoPagesView>());
            _tutorialInfoPagesView.InitView(NextPage);
            _tutorialNavPanelService.ActivateService(GetMarkerAnchor<TutorialNavPanelMarker>(_tutorialInfoPagesView.transform));
            _tutorialInfoPagesView.ShowCurrentPage(_tutorialNavPanelService.GetCurrentPageId());
        }
        
        public void NextPage()
        {
           int nextPageId = _tutorialNavPanelService.NextPage();
           if (nextPageId == -1)
           {
               _completeTutorialInfo?.Invoke();
               return;
           }
           _tutorialInfoPagesView.ShowCurrentPage(nextPageId);
        }

        public void Enter()
        {
            
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            _tutorialInfoPagesView.HideAllPages();
            _tutorialNavPanelService.HideAllPoints();
            _tutorialInfoPagesView.HidePageView();
        }
        
        private Transform GetMarkerAnchor<T>(Transform parent)
        {
            foreach (Transform child in parent)
            {
                Component targetComponent = child.GetComponent(typeof(T).Name);

                if (targetComponent != null) return child.transform;
                
                GetMarkerAnchor<T>(child);
            }
            return null;
        }
    }
}