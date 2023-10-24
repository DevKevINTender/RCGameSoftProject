using UnityEngine;
using Views.TutorialComplete;
using Zenject;

namespace StateMachines
{
    public class TutorialPracticeCompleteState: IGameState
    {
        private TutorialCompleteService _tutorialCompleteService;
        private TuttorialChalengeState _tuttorialChalengeState;

        [Inject]
        public TutorialPracticeCompleteState(TutorialCompleteService tutorialCompleteService, TuttorialChalengeState tuttorialChalengeState)
        {
            _tutorialCompleteService = tutorialCompleteService;
            _tuttorialChalengeState = tuttorialChalengeState;
        }

        public void Enter()
        {
            _tutorialCompleteService.ActivateService();
        }

        public void Update()
        {
         
        }

        public void Exit()
        {
           
        }
    }
}