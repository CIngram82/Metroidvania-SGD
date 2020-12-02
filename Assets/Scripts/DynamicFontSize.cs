/******************************************************************************
 * Dynamic Font Size
 * Author: Robert Secoura
 * 
 * Dynamically resizes fonts within specified size ranges.
 * Attach to Canvas GameObject so it resizes with change in screen resolution.
 * 
 * Modified: 11/09/2020
 *****************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

[System.Serializable]
public class TextGroup
{
#pragma warning disable 0649
    [SerializeField] float minFontSize;
    [SerializeField] List<TextMeshProUGUI> textGroupList;
#pragma warning restore 0649

    public float MinFontSize { get { return minFontSize; } set { minFontSize = value; } }
    public List<TextMeshProUGUI> TextGroupList { get { return textGroupList; } set { textGroupList = value; } }
}

public class DynamicFontSize : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] List<TextGroup> textGroupLists;
#pragma warning restore 0649


    public void OnScreenResize()
    {
        foreach (var textGroup in textGroupLists)
            foreach (var text in textGroup.TextGroupList)
            {
                text.enableAutoSizing = true;
            }
        SetStandardFontSize();
    }

    public void SetStandardFontSize()
    {
        foreach (var textGroup in textGroupLists)
            foreach (var text in textGroup.TextGroupList)
            {
                text.enableAutoSizing = false;
                text.fontSize = textGroup.MinFontSize;
            }
    }

    void LoadTextGroups(List<TextMeshProUGUI> textGroupList)
    {
        textGroupList = textGroupList.OrderByDescending(text => text.fontSize).ToList();
        int subIndex = 0;
        bool inRange;

        for (int index = 0; index < textGroupLists.Count; index++)
        {
            inRange = true;
            while (subIndex < textGroupList.Count && inRange)
            {
                if (textGroupList[subIndex].fontSize > textGroupLists[index].MinFontSize)
                {
                    textGroupLists[index].TextGroupList.Add(textGroupList[subIndex]);
                    subIndex++;
                }
                else
                {
                    textGroupLists[index].MinFontSize = textGroupList[subIndex - 1].fontSize;
                    inRange = false;
                }
            }
        }
        SetStandardFontSize();
    }

    void OnRectTransformDimensionsChange()
    {
        OnScreenResize();
    }

    void Start()
    {
        textGroupLists = textGroupLists.OrderByDescending(text => text.MinFontSize).ToList();
        LoadTextGroups(FindObjectsOfType<TextMeshProUGUI>().ToList());
    }
}





