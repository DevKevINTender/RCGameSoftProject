using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.TutorialFail
{
    public class TutorialFailView : MonoBehaviour
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
}