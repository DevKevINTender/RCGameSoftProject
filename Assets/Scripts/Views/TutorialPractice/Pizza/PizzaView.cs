using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Views.TutorialPractice.Pizza;

public class PizzaView : MonoBehaviour
{
    [SerializeField] private Animation cutAnimation;
    public GameObject basePizza;
    [SerializeField] public Dictionary<int, PartsForCheckView> cutedPizzaTypes = new Dictionary<int, PartsForCheckView>();
    private Action _pizzaCuted;
    private int _id;

    public void InitView()
    {
        FillDictionaryWithParts(transform);
    }

    public void PizzaCut(int id, Action pizzaCuted)
    {
        _id = id;
        _pizzaCuted = pizzaCuted;
        StartCoroutine(AnimationDuration(cutAnimation.clip.length));
    }

    IEnumerator AnimationDuration(float animationLenght)
    {
        cutAnimation.Play();
        yield return new WaitForSeconds(animationLenght);
        basePizza.SetActive(false);
        cutedPizzaTypes[_id].gameObject.SetActive(true);
        _pizzaCuted?.Invoke();

    }

    public List<Transform> GetPizzParts()
    {
        return cutedPizzaTypes[_id].GetPartsForCheck();
    }

    void FillDictionaryWithParts(Transform parent)
    {
        // Перебираем все дочерние объекты
        foreach (Transform child in parent)
        {
            // Проверяем, есть ли на объекте компонент PartsForCheckView
            PartsForCheckView partsView = child.GetComponent<PartsForCheckView>();

            if (partsView != null)
            {
                // Запрашиваем значение count через метод GetPartsForCheck
                int count = partsView.GetPartsForCheck().Count;

                // Добавляем значение в словарь
                cutedPizzaTypes.Add(count, partsView);
            }

            // Рекурсивно вызываем этот метод для дочерних объектов
            FillDictionaryWithParts(child);
        }

        foreach (var item in cutedPizzaTypes)
        {
            Debug.Log($"key: {(int)item.Key}  value: {item.Value}");
        }
    }
}
