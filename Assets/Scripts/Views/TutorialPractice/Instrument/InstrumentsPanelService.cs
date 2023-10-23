using System;
using System.Collections.Generic;
using Data;
using Services;
using StateMachines;
using UnityEngine;
using Views.TutorialPractice.Instrument.InstrumentCard;
using Views.TutorialPractice.Page;
using Zenject;

namespace Views.TutorialPractice.Instrument
{
    public class InstrumentsPanelService
    {
        private TutorialPageService _tutorialPageService;
        private InstrumentCardFactory _instrumentCardFactory;
        private LevelData _levelData;
        
        private List<InstrumentCardService> _instrumentCardServices = new List<InstrumentCardService>();

        private Action _instrumentSelected;


        [Inject]
        public void Constructor(TutorialPageService tutorialPageService, InstrumentCardFactory instrumentCardFactory,LevelDataService levelDataService)
        {
            _tutorialPageService = tutorialPageService;
            _instrumentCardFactory = instrumentCardFactory;
            _levelData = levelDataService.GetCurrentLevelData();
        }
        
        public void ActivateService()
        {
            CreateInstrumentCardList();
            SetSelectedActionToCardServiceList();
        }
        
      
        public void SetSelectInstrumentInstruction(Action instrumentSelected)
        {
            _instrumentSelected = instrumentSelected;
        }
        
        
        private void SelectInstrument(int id)
        {
            _levelData.currentAnswer = id;
            Debug.Log("Click: " + id);
            _instrumentSelected?.Invoke();
        }
        
        private void CreateInstrumentCardList()
        {
            for (int i = 0; i < _levelData.LevelDataSo.answerVariants.Count; i++)
            {
                int answerId = i;
                int answer = _levelData.LevelDataSo.answerVariants[i];
                Transform anchor = _tutorialPageService.GetTransformByMarker<InstrumentsPanelMarker>();
                InstrumentCardService newCardService = _instrumentCardFactory.CreateInstrumentCard(answerId, answer, anchor); 
                _instrumentCardServices.Add(newCardService);
            }
        }
        
        private void SetSelectedActionToCardServiceList()
        {
            foreach (var card in _instrumentCardServices)
            {
                card.SetSelectedAction(SelectInstrument);
            }
        }

        public void DeactivateService()
        {
            foreach (var card in _instrumentCardServices)
            {
                card.DeactivateService();
            }
            _instrumentCardServices.Clear();
        }
    }
}