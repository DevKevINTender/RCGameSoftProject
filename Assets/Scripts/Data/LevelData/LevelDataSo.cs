using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelDataSO", menuName = "new LeveDataSO", order = 0)]
    public class LevelDataSo : ScriptableObject
    {
        public int correctAnswer;
        public List<int> answerVariants = new List<int>();

    }
}