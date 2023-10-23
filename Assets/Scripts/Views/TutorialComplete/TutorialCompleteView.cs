using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCompleteView : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    private Action _restart;
    
    public void ActivateView(Action restart)
    {
        _restart = restart;
        restartButton.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        _restart?.Invoke();
    }
}
