using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCompleteView : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button startTuttorialChalengeButton;
    [SerializeField] private Button openMenuButton;
    private Action _restart;
    private Action _startTuttorialChalenge;
    private Action _openMenu;
    public void ActivateView(Action restart, Action startTuttorialChalenge, Action openMenu)
    {
        _restart = restart;
        _startTuttorialChalenge = startTuttorialChalenge;   
        _openMenu = openMenu;
        restartButton.onClick.AddListener(Restart);
        startTuttorialChalengeButton.onClick.AddListener(StartTuttorialChalenge);
        openMenuButton.onClick.AddListener(OpenMenu);
    }

    private void Restart()
    {
        _restart?.Invoke();
    }

    private void StartTuttorialChalenge()
    {
        _startTuttorialChalenge?.Invoke();
    }

    private void OpenMenu()
    {
        _openMenu?.Invoke();
    }
}
