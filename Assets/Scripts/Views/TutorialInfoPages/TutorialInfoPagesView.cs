using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInfoPagesView : MonoBehaviour
{
    [SerializeField] private GameObject pageView;
    
    [SerializeField] private List<GameObject> pages = new List<GameObject>();
    [SerializeField] private List<Button> nextButtons = new List<Button>();

    private Action _nextPage;
    
    public void InitView(Action nextPage)
    {
        pageView.SetActive(true);
        _nextPage = nextPage;
        foreach (var button in nextButtons)
        {
            button.onClick.AddListener(NextPage);
        }
    }

    public void NextPage()
    {
        _nextPage?.Invoke();
    }

    public void ShowCurrentPage(int id)
    {
        HideAllPages();
        pages[id].SetActive(true);
    }

    public void HideAllPages()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(false);
        }
    }

    public void HidePageView()
    {
        pageView.SetActive(false);
    }


   
}
