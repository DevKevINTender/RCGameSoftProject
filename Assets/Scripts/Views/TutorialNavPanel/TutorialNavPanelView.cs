using System.Collections;
using System.Collections.Generic;
using Data.Enum;
using UnityEngine;
using UnityEngine.UI;

public class TutorialNavPanelView : MonoBehaviour
{
    [SerializeField] private List<Image> navPoints = new List<Image>();

    public void InitView()
    {
        
    }

    public void UpdateNavPoints(int currentPoint)
    {
        for (int i = 0; i < navPoints.Count; i++)
        {
            navPoints[i].color = ColorSatic.main;
            if(currentPoint == i)  navPoints[i].color = ColorSatic.white;
        }
    }

    public int GetPointCount()
    {
        return navPoints.Count;
    }

    public void HideAllPoints()
    {
        for (int i = 0; i < navPoints.Count; i++)
        {
            navPoints[i].color = new Color32(0,0,0,0);
        }
    }
}
