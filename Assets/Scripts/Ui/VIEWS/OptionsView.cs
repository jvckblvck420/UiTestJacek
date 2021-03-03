using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsView : UiView
{

    public Toggle HdRumble;
   

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(HdRumble.gameObject);
    }
    private void OnDisable()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
