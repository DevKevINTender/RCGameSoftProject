using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Services;
using UnityEngine;
using Views.TutorialPractice.Page;
using Views.TutorialPractice.Pizza;
using Zenject;

public class PizzaService
{

    private PizzaView _pizzaView;
    private Action _pizzaCuted;
    private LevelData _levelData;
    private TutorialPageService _tutorialPageService;
    private PrefabsStorageService _prefabsStorageService;
   
    
    [Inject]
    public  void Constructor(LevelDataService levelDataService, TutorialPageService tutorialPageService, PrefabsStorageService prefabsStorageService)
    {
        _levelData = levelDataService.GetCurrentLevelData();
        _tutorialPageService = tutorialPageService;
        _prefabsStorageService = prefabsStorageService;
    }
    
    public void ActivateService()
    {
        _pizzaView = MonoBehaviour.Instantiate(_prefabsStorageService.GetPrefabByType<PizzaView>(), _tutorialPageService.GetTransformByMarker<PizzaViewMarker>());
        _pizzaView.InitView();

    }

    public void SetPizzaCutedInstruction(Action pizzaCuted)
    {
        _pizzaCuted = pizzaCuted;
        int _pizzaCutedCount = _levelData.LevelDataSo.answerVariants[_levelData.currentAnswer];
        _pizzaView.PizzaCut(_pizzaCutedCount, PizzCuted);
    }
    
    private void PizzCuted()
    {
        _pizzaCuted?.Invoke();
    }

    public List<Transform> GetPizzParts()
    {
        return _pizzaView.GetPizzParts();
    }
}
