using UnityEngine;
using Views.TutorialFail;
using Zenject;

namespace StateMachines
{
    public class TutorialPracticeFailState: IGameState
    {
        private TutorialFailService _tutorialFailService;
        
        [Inject]
        public TutorialPracticeFailState(TutorialFailService tutorialFailService)
        {
            _tutorialFailService = tutorialFailService;
        }
        
        public void Enter()
        {
            _tutorialFailService.ActivateService();
        }

        public void Update()
        {
         
        }

        public void Exit()
        {
           
        }
    }
}