using System;
using UnityEngine;

namespace Views.TutorialPractice.Curier.Curier
{
    public class CourierCardService
    {
        private CourierCardView _courierCardView;
        private Transform _target;
        private Action _reachedTarget;
        public void ActivateService(CourierCardView courierCardView)
        {
            _courierCardView = courierCardView;
            _courierCardView.ActivateView();
        }

        public void SetTargetToCheckInstructions(Transform target, Action reachedTarget)
        {
            _target = target;
            _reachedTarget = reachedTarget;
            _courierCardView.MoveToTarget(target,ReachedTarget);
        }

        public void ShowMessage(int id)
        {
            _courierCardView.ShowMessge(id);
        }
        
        public void SetCompleteCheckInstuctions()
        {
            _courierCardView.MoveToHome(_target);
        }
            
        private void ReachedTarget()
        {
            _reachedTarget?.Invoke();
        }
    }
}