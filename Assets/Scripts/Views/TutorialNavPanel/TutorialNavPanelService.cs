using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;
using Zenject;

public class TutorialNavPanelService
{
    private PrefabsStorageService _prefabsStorageService;
    private TutorialNavPanelView _tutorialNavPanelView;
    private int currentPoint = 0;
    private int maxPointCount = 0; 
    
    [Inject]
    public TutorialNavPanelService(PrefabsStorageService prefabsStorageService)
    {
        _prefabsStorageService = prefabsStorageService;
    }

    public void ActivateService(Transform anchor)
    {
        TutorialNavPanelView tutorialNavPanelViewPb = _prefabsStorageService.GetPrefabByType<TutorialNavPanelView>();
        _tutorialNavPanelView = MonoBehaviour.Instantiate(tutorialNavPanelViewPb,anchor);
        _tutorialNavPanelView.InitView();
        _tutorialNavPanelView.UpdateNavPoints(currentPoint);
        
        maxPointCount = _tutorialNavPanelView.GetPointCount();
    }
        
    public int NextPage()
    {
        if (currentPoint + 1 < maxPointCount)
        {
            currentPoint++;
            _tutorialNavPanelView.UpdateNavPoints(currentPoint);
            return currentPoint;
        }
        else
        {
            return -1;
        }
    }

    public int GetCurrentPageId()
    {
        return currentPoint;
    }

    public void HideAllPoints()
    {
        _tutorialNavPanelView.HideAllPoints();
    }
}
