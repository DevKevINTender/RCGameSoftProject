using UnityEngine;
using Zenject;

namespace StateMachines
{
    public class TutorialPracticePizzaCutState: IGameState
    {
        private PizzaService _pizzaService;
        private StateMachine _stateMachine;
        [Inject] private TutorialPracticeCheckState _tutorialPracticeCheckState;

        
        [Inject]
        public TutorialPracticePizzaCutState
        (
            PizzaService pizzaService,
            StateMachine stateMachine
        )
        {
            _pizzaService = pizzaService;
            _stateMachine = stateMachine;
 
        }
        
        public void Enter()
        {
            Debug.Log("Start " + this);
            _pizzaService.SetPizzaCutedInstruction(PizzaCuted);
        }
        
        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }

        private void PizzaCuted()
        {
            _stateMachine.SetState(_tutorialPracticeCheckState);
        }
    }
}