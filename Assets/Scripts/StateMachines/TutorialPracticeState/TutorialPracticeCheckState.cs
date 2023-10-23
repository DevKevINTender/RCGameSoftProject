using UnityEngine;
using Views.TutorialPractice.Curier;
using Zenject;

namespace StateMachines
{
    public class TutorialPracticeCheckState: IGameState
    {
        private PizzaService _pizzaService;
        private CouriersPanelService _couriersPanelService;
        private StateMachine _stateMachine;
        [Inject] private TutorialPracticeCompleteState _tutorialPracticeCompleteState;
        [Inject] private TutorialPracticeFailState _tutorialPracticeFailState;

        
        [Inject]
        public TutorialPracticeCheckState
        (
            PizzaService pizzaService,
            StateMachine stateMachine,
            CouriersPanelService couriersPanelService
        )
        {
            _pizzaService = pizzaService;
            _stateMachine = stateMachine;
            _couriersPanelService = couriersPanelService;

        }
        public void Enter()
        {
            Debug.Log("Start " + this);
            _couriersPanelService.SetCheckResultInstructions(CompleteCheck, FailCheck);
        }

        public void Update()
        {
           
        }

        public void Exit()
        {
            
        }

        private void CompleteCheck()
        {
            _stateMachine.SetState(_tutorialPracticeCompleteState);
        }

        private void FailCheck()
        {
            _stateMachine.SetState(_tutorialPracticeFailState);
        }
    }
}