using UnityEngine;
using Views.Pages;
using Zenject;

namespace StateMachines
{
    public class TutorialInfoState: IGameState
    {
        private StateMachine _stateMachine;
        private TutorialPracticeGenerateState _tutorialPracticeGenerateState;
        private TutorialInfoPagesService _tutorialInfoPagesService;
        
        [Inject]
        public TutorialInfoState(StateMachine stateMachine, TutorialPracticeGenerateState tutorialPracticeGenerateState, TutorialInfoPagesService tutorialInfoPagesService)
        {
            _stateMachine = stateMachine;
            _tutorialPracticeGenerateState = tutorialPracticeGenerateState;
            _tutorialInfoPagesService = tutorialInfoPagesService;
            

        }
        
        public void Enter()
        {
            _tutorialInfoPagesService.ActivateService(CompleteTutorialInfo);
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            _tutorialInfoPagesService.Exit();
        }
        
        public void CompleteTutorialInfo()
        {
            _stateMachine.SetState(_tutorialPracticeGenerateState);
        }
    }
}