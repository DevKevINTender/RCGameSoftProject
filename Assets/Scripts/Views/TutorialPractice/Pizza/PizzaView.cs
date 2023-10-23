using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Views.TutorialPractice.Pizza;

public class PizzaView : MonoBehaviour
{
    [SerializeField] private Animation cutAnimation;
    public GameObject basePizza;
    public List<PartsForCheckView> cutedPizzaTypes = new List<PartsForCheckView>();
    private Action _pizzaCuted;
    private int _id;

    public void InitView()
    {
        
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
}
