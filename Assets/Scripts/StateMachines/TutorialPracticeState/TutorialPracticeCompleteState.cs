using UnityEngine;
using Views.TutorialComplete;
using Zenject;

namespace StateMachines
{
    public class TutorialPracticeCompleteState: IGameState
    {
        private TutorialCompleteService _tutorialCompleteService;
        
        [Inject]
        public TutorialPracticeCompleteState(TutorialCompleteService tutorialCompleteService)
        {
            _tutorialCompleteService = tutorialCompleteService;
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