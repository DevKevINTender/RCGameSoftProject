using System.Collections.Generic;
using UnityEngine;

namespace Views.TutorialPractice.Pizza
{
    public class PartsForCheckView : MonoBehaviour
    {
        [SerializeField] private List<Transform> partsForCheck = new List<Transform>();

        public List<Transform> GetPartsForCheck()
        {
            return partsForCheck;
        }
    }
}