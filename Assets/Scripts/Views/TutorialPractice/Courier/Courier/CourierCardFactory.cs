using Services;
using UnityEngine;
using Views.TutorialPractice.Instrument.InstrumentCard;
using Zenject;

namespace Views.TutorialPractice.Curier.Curier
{
    public class CourierCardFactory
    {
        [Inject] private PrefabsStorageService _prefabsStorageService;

        public CourierCardService CreateCourierCard(Transform anchor)
        {
            CourierCardService courierCardService = new CourierCardService();
            CourierCardView courierCardViewPb = _prefabsStorageService.GetPrefabByType<CourierCardView>();
            CourierCardView courierCardView = MonoBehaviour.Instantiate(courierCardViewPb, anchor);
            courierCardService.ActivateService(courierCardView);
            return courierCardService;
        }
    }
}