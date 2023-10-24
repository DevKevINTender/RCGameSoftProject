using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Views.TutorialPractice.Curier.Curier
{
    public class CourierCardView : MonoBehaviour
    {
        [SerializeField] private List<GameObject> messages = new List<GameObject>();
        [SerializeField] private TextMeshProUGUI _question;

        public void ActivateView(int answer)
        {
            _question.text = answer.ToString();
            ShowMessge(1);
        }
        
        public void ShowMessge(int id)
        {
            foreach (var item in messages)
            {
                item.SetActive(false);
            }
            messages[id].SetActive(true);
        }

        public void MoveToTarget(Transform target, Action reachedTarget)
        {
            StartCoroutine(MoveToTargetEnum(target, reachedTarget));
        }

        IEnumerator MoveToTargetEnum(Transform target, Action reachedTarget)
        {
            Vector3 velocity = new Vector3();
            while (Vector3.Distance(target.position, transform.position) > 0.1f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, 0.25f);
                yield return null;
            }
            reachedTarget?.Invoke();
        }

        public void MoveToHome(Transform target)
        {
            StartCoroutine(MoveToHomeEnum(target));
        }
        
        IEnumerator MoveToHomeEnum(Transform target)
        {
            Vector3 velocity = new Vector3();
            Vector3 startTargetPosition = target.position;
            target.SetParent(transform);
            target.SetAsFirstSibling();
            
            while (Vector3.Distance(startTargetPosition, transform.position) < 10f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, transform.position + Vector3.right, ref velocity, 0.25f);
                yield return null;
            }
        }
    }
}