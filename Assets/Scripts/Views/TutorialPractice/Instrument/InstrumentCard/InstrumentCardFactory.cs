using Services;
using UnityEngine;
using Zenject;

namespace Views.TutorialPractice.Instrument.InstrumentCard
{
    public class InstrumentCardFactory
    {

        [Inject] private PrefabsStorageService _prefabsStorageService;

        public InstrumentCardService CreateInstrumentCard(int answerVariantId ,int answerVariant, Transform anchor)
        {
            InstrumentCardService instrumentCardService = new InstrumentCardService();
            InstrumentCardView instrumentCardViewPb = _prefabsStorageService.GetPrefabByType<InstrumentCardView>();
            InstrumentCardView instrumentCardView = MonoBehaviour.Instantiate(instrumentCardViewPb, anchor);
            instrumentCardService.ActivateService(instrumentCardView,answerVariantId,answerVariant) ;
            return instrumentCardService;
        }
    }
}