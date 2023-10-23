using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class PrefabsStorageService
    {
        private List<GameObject> prefabs = new List<GameObject>();
        private string assetPath = "Prefabs/";

        public PrefabsStorageService()
        {
            prefabs.AddRange(Resources.LoadAll<GameObject>(assetPath));
        }
        
        public T GetPrefabByType<T>()
        {
            GameObject obj = null;
            
            foreach (GameObject item in prefabs)
            {
                // Проверить, есть ли у игрового объекта компонент с заданным именем
                Component targetComponent = item.GetComponent(typeof(T).Name);

                if (targetComponent != null) obj = item;
            }

            if (obj == null) Debug.LogError($"Not found Prefabs with type {typeof(T).Name} in {assetPath}");
                return obj.GetComponent<T>();
        }
    }
}