using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.TutorialPractice.Instrument.InstrumentCard
{
    public class InstrumentCardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private Button _button;
        private Action _instrumentSelected;
        public void InitView(int answerVariant, Action instrumentSelected)
        {
            _text.text = answerVariant.ToString();
            _instrumentSelected = instrumentSelected;
            _button = GetComponent<Button>();
            _button.onClick.AddListener(SelectInstrument);
        }

        private void SelectInstrument()
        {
           
            _instrumentSelected?.Invoke();
        }

        public void DeactivateView()
        {
            
        }
    }
}