using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPagesView : MonoBehaviour
{

    private Action startTuttorial;
    private Action<int> startChallenge;

    public void InitView(Action startTuttorial, Action<int> startChallenge)
    {
        this.startTuttorial = startTuttorial;
        this.startChallenge = startChallenge;
    }

    public void StartTuttorialInfo()
    {
        startTuttorial?.Invoke();
    }

    public void StartChallenge(int id)
    {
        startChallenge?.Invoke(id); 
    }
}
