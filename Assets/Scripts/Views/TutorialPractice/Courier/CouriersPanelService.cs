using System;
using System.Collections.Generic;
using Data;
using StateMachines;
using UnityEngine;
using Views.TutorialPractice.Curier.Curier;
using Views.TutorialPractice.Instrument.InstrumentCard;
using Views.TutorialPractice.Page;
using Views.TutorialPractice.Pizza;
using Zenject;
using Random = UnityEngine.Random;

namespace Views.TutorialPractice.Curier
{
    public class CouriersPanelService
    {
        private TutorialPageService _tutorialPageService;
        private CourierCardFactory _courierCardFactory;
        private LevelData _levelData;

        private Action _completeCheck, _failCheck;
        
        private List<CourierCardService> _courierCardServices = new List<CourierCardService>();
        private CourierCardService _activeCourierCardService;
        List<Transform> _pizzaParts = new List<Transform>();
        [Inject] private PizzaService _pizzaService;
        
        [Inject]
        public void Constructor(TutorialPageService tutorialPageService, CourierCardFactory courierCardFactory, LevelDataService levelDataService)
        {
            _tutorialPageService = tutorialPageService;
            _courierCardFactory = courierCardFactory;
            _levelData = levelDataService.GetCurrentLevelData();
        }

        public void ActivateService()
        {
            CreateCourierCardList();
        }
        
        private void CreateCourierCardList()
        {
            Transform anchor = _tutorialPageService.GetTransformByMarker<CouriersPanelMarker>();
            foreach (var answer in _levelData.LevelDataSo.answerVariants)
            {
                _courierCardServices.Add(_courierCardFactory.CreateCourierCard(anchor));
            }
        }

        public void SetCheckResultInstructions(Action completeCheck, Action failCheck)
        {
            _completeCheck = completeCheck;
            _failCheck = failCheck;
            SendCouriersCheckResult();
        }

        private void SendCouriersCheckResult()
        {
            _pizzaParts = _pizzaService.GetPizzParts();
            Debug.Log("PizzaParts Count " + _pizzaParts.Count);
            if (_pizzaParts.Count > 0)
            {
                int randC = Random.Range(0,_courierCardServices.Count);
                int randP = Random.Range(0,_pizzaParts.Count);
                _activeCourierCardService = _courierCardServices[randC];
              
                _activeCourierCardService.SetTargetToCheckInstructions(_pizzaParts[randP].transform, CourierReachedTarget);
                _activeCourierCardService.ShowMessage(0);
                _courierCardServices.RemoveAt(randC);
                _pizzaParts.RemoveAt(randP);
                
            }
            else
            {
                CompletedAllCheck();
            }
        }

        private void CourierReachedTarget()
        {
            CheckAnswerForCorrect();
        }

        private void CheckAnswerForCorrect()
        {
            int correctAnswer = _levelData.LevelDataSo.correctAnswer;
            int currentAnswer = _levelData.LevelDataSo.answerVariants[_levelData.currentAnswer];
            if (correctAnswer == currentAnswer)
            {
                _activeCourierCardService.ShowMessage(2);
                CompleteCheck();
            }
            else
            {
                _activeCourierCardService.ShowMessage(3);
                FailedCheck();
            }
        }
        
        private void FailedCheck()
        {
            _failCheck?.Invoke();
        }

        private void CompleteCheck()
        {
            _activeCourierCardService.SetCompleteCheckInstuctions();
            SendCouriersCheckResult();
        }
        
        private void CompletedAllCheck()
        {
            _completeCheck?.Invoke();
        }
    }
}