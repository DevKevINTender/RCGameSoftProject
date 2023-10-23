
using System.Collections.Generic;
using Zenject;
using Services;
using UnityEngine;

namespace Views.TutorialPractice.Page
{
    public class TutorialPageService
    {
        private TutorialPageView _tutorialPageView;
        [Inject] private PrefabsStorageService _prefabsStorageService;
        
        
        public TutorialPageService()
        {
          
        }

        public void ActivateService()
        {
            Debug.Log(_prefabsStorageService);
            _tutorialPageView = MonoBehaviour.Instantiate(_prefabsStorageService.GetPrefabByType<TutorialPageView>()).GetComponent<TutorialPageView>();
        }

        public Transform GetTransformByMarker<T>()
        {
            Transform markerTransform = null;
            List<GameObject> markers = _tutorialPageView.GetMarkers();
            
            foreach (GameObject item in markers)
            {
                // Проверить, есть ли у игрового объекта компонент с заданным именем
                Component targetComponent = item.GetComponent(typeof(T).Name);

                if (targetComponent != null) markerTransform = item.transform;
            }
            
            return markerTransform;
        }
    }
}