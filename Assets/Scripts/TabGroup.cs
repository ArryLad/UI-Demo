using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;
    public TabButton selectedTab;
    public List<GameObject> tabPages;
    //public PanelGroup panelGroup;
    public void Subscribe(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        
        tabButtons.Add(button);
        tabButtons.Sort((x, y) => x.transform.GetSiblingIndex().CompareTo(y.transform.GetSiblingIndex()));
        OnTabSelected(tabButtons[0]);
        //ResetTabs();
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.color = tabHover;
        }
        
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        if(selectedTab != null)
        {
            selectedTab.Deselect();
        }

        selectedTab = button;


        selectedTab.Select();

        ResetTabs();
        button.background.color = tabActive;  
        int index = button.transform.GetSiblingIndex();
        
        for (int i=0; i< tabPages.Count; i++)
        {
            if(i == index)
            {
                tabPages[i].SetActive(true);
            }
            else
            {
                tabPages[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab)
                continue;
            button.background.color = tabIdle;
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            PreviousTab();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            NextTab();
        }
    }

    public void NextTab()
    {
        int currentIndex = tabButtons.IndexOf(selectedTab);
        int nextIndex = (currentIndex + 1) % tabButtons.Count;
        OnTabSelected(tabButtons[nextIndex]);
    }

    public void PreviousTab()
    {
        int currentIndex = tabButtons.IndexOf(selectedTab);
        int previousIndex = (currentIndex - 1 + tabButtons.Count) % tabButtons.Count;
        OnTabSelected(tabButtons[previousIndex]);
    }
}
