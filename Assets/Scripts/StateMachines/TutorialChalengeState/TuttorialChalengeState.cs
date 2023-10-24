using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Services;
using StateMachines;
using UnityEngine;
using Views.Pages;
using Zenject;

public class TuttorialChalengeState : IGameState
{
    [Inject] private StateMachine _stateMachine;
    [Inject] private TutorialPracticeGenerateState _tutorialPracticeGenerateState;
    private TuttorialChalengeSetLevelService _tutorialChalengeSetLevelService;

    [Inject]
    public TuttorialChalengeState(TuttorialChalengeSetLevelService tutorialChalengeSetLevelService)
    {
        _tutorialChalengeSetLevelService = tutorialChalengeSetLevelService;
    }

    public void Enter()
    {
        _tutorialChalengeSetLevelService.SetTuttorialLevel();
        _stateMachine.SetState(_tutorialPracticeGenerateState);
    }

    public void Update()
    {

    }

    public void Exit()
    {
        
    }
}
