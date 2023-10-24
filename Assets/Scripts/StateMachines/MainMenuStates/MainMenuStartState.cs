using StateMachines;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Views.MainMenuPages;
using Zenject;

namespace StateMachines.MainMenuStates
{
    public class MainMenuStartState : IGameState
    {

        private MainMenuPageService _mainMenuPageService;

        [Inject]
        public MainMenuStartState(MainMenuPageService mainMenuPageService)
        {
            _mainMenuPageService = mainMenuPageService;
        }

        public void Enter()
        {
            _mainMenuPageService.ActivateService();
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            
        }
    }
}