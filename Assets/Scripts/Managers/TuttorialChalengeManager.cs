using StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TuttorialChalengeManager : MonoBehaviour
{
    private StateMachine _stateMachine;
    // [Inject] private TutorialPracticeGenerateState _tutorialPracticeGenerateState;
    [Inject] private TuttorialChalengeState _tuttorialChalengeState;

    [Inject]
    public void Construct(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    void Start()
    {
        _stateMachine.SetState(_tuttorialChalengeState);
    }
}
