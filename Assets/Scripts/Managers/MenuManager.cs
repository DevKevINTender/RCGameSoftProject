using StateMachines.MainMenuStates;
using StateMachines;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        private StateMachine _stateMachine;
        // [Inject] private TutorialPracticeGenerateState _tutorialPracticeGenerateState;
        [Inject] private MainMenuStartState _mainMenuStartState;

        [Inject]
        public void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        void Start()
        {
            _stateMachine.SetState(_mainMenuStartState);
        }
    }
}