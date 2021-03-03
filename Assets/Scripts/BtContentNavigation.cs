using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtContentNavigation : MonoBehaviour
{
    private Button [] PauseButtons;
    private int index=0;
    private int previousIndex;
    public UiView Pause;

    private void Awake()
    {
        PauseButtons = GetComponentsInChildren<Button>();
        PauseButtons[index].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            previousIndex = index;
            if (index >= 4)
            {
                index = 0;
            }
            else 
            {
                index++;
            }
            PauseButtons[index].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            PauseButtons[previousIndex].transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            previousIndex = index;

            if (index <= 0)
            {
                index = 4;
            }
            else
            {
                index--;
            }
            PauseButtons[previousIndex].transform.localScale = new Vector3(1f, 1f, 1f);
            PauseButtons[index].transform.localScale = new Vector3(1.2f,1.2f,1.2f);
           
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (index == 0)
            {
                GUIController.Insntace.PauseView.BackButon.onClick.Invoke();
            }
            if (index == 1)
            {
                GUIController.Insntace.InGameGUIButton_OnClick(GUIController.Insntace.MenuViews[0]);
                Pause.DisableView_OnClick(Pause);
                
            }
            if (index == 2)
            {
                GUIController.Insntace.InGameGUIButton_OnClick(GUIController.Insntace.MenuViews[1]);
                Pause.DisableView_OnClick(Pause);
            }
            if (index == 3)
            {
                GUIController.Insntace.InGameGUIButton_OnClick(GUIController.Insntace.MenuViews[2]);
                Pause.DisableView_OnClick(Pause);
            }
        }
    }
}
