using System.Collections.Generic;
using UnityEngine;

namespace Views.TutorialPractice.Page
{
    public class TutorialPageView : MonoBehaviour
    {
       public List<GameObject> markers = new List<GameObject>();


       public List<GameObject> GetMarkers()
       {
           return FindObjectsWithInterfaceRecursive(transform);
       }
       
       private List<GameObject>  FindObjectsWithInterfaceRecursive(Transform parent)
       {
           // Перебирайте все дочерние объекты
           foreach (Transform child in parent)
           {
               // Получите компоненты, реализующие интерфейс IMarker
               IMarker[] markersInChild = child.GetComponents<IMarker>();

               // Если найдены такие компоненты, добавьте объект в список
               if (markersInChild.Length > 0)
               {
                   markers.Add(child.gameObject);
               }

               // Рекурсивно вызывайте этот метод для поиска в дочерних объектах текущего объекта
               FindObjectsWithInterfaceRecursive(child);
           }

           return markers;
       }
    }
}