using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using StateMachines;
using UnityEngine;
using Views.Pages;
using Zenject;

public class TuttorialManager : MonoBehaviour
{
    private StateMachine _stateMachine;
   // [Inject] private TutorialPracticeGenerateState _tutorialPracticeGenerateState;
    [Inject] private TutorialStartState _tutorialStartState;
    
    [Inject]
    public void Construct(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    void Start()
    {
        _stateMachine.SetState(_tutorialStartState);
    }
}
