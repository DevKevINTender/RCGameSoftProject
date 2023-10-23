using System;
using Data;
using UnityEngine;
using Zenject;

namespace Views.TutorialPractice.Instrument.InstrumentCard
{
    public class InstrumentCardService 
    {
        private InstrumentCardView _instrumentCardView;
        private int _answerVariantId;
        private Action<int> _selectInstrument;

        public void ActivateService(InstrumentCardView instrumentCardView, int answerVariantId, int answerVariant)
        {
            _instrumentCardView = instrumentCardView;
            _answerVariantId = answerVariantId;
            _instrumentCardView.InitView(answerVariant, SelectInstrument);
        }
        
        public void SelectInstrument()
        {
            _selectInstrument?.Invoke(_answerVariantId);
        }

        public InstrumentCardView GetView()
        {
            return _instrumentCardView;
        }

        public void SetSelectedAction(Action<int> selectInstrument)
        {
            _selectInstrument = selectInstrument;
        }

        public void DeactivateService()
        {
            _instrumentCardView.DeactivateView();
            MonoBehaviour.Destroy(_instrumentCardView.gameObject);
        }
    }
}