using UnityEngine;
using Views.TutorialPractice.Curier;
using Views.TutorialPractice.Instrument;
using Views.TutorialPractice.Page;
using Zenject;

namespace StateMachines
{
    public class TutorialPracticeGenerateState: IGameState
    {
        private StateMachine _stateMachine;
        private PizzaService _pizzaService;
        private InstrumentsPanelService _instrumentsPanelService;
        private CouriersPanelService _couriersPanelService;
        private TutorialPageService _tutorialPageService;
        [Inject] private TutorialPracticePizzaCutState _tutorialPracticePizzaCutState;
        
        [Inject]
        public TutorialPracticeGenerateState
        (
            StateMachine stateMachine,
            PizzaService pizzaService,
            InstrumentsPanelService instrumentsPanelService,
            CouriersPanelService couriersPanelService,
            TutorialPageService tutorialPageService
        )
        {
            _stateMachine = stateMachine;
            _pizzaService = pizzaService;
            _instrumentsPanelService = instrumentsPanelService;
            _couriersPanelService = couriersPanelService;
            _tutorialPageService = tutorialPageService;
        }
        
        public void Enter()
        {
            Debug.Log("Start " + this);
            
            _tutorialPageService.ActivateService();
            _pizzaService.ActivateService();
            _instrumentsPanelService.ActivateService();
            _couriersPanelService.ActivateService();
            
            _instrumentsPanelService.SetSelectInstrumentInstruction(SelectInstrument);
        }
        
        public void Update()
        {
            
        }

        public void Exit()
        {
            _instrumentsPanelService.DeactivateService();
        }

        private void SelectInstrument()
        {
            _stateMachine.SetState(_tutorialPracticePizzaCutState);
        }
    }
}