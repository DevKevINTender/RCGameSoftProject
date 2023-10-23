using UnityEngine;
using Zenject;

namespace StateMachines
{
    public class TutorialStartState: IGameState
    {
        private StateMachine _stateMachine;
        private TutorialInfoState _tutorialInfoState;
        
        [Inject]
        public TutorialStartState(StateMachine stateMachine, TutorialInfoState tutorialInfoState)
        {
            _stateMachine = stateMachine;
            _tutorialInfoState = tutorialInfoState;
        }

        public void Enter()
        {
           _stateMachine.SetState(_tutorialInfoState);
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}