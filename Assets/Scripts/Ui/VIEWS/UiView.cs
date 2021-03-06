﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiView : MonoBehaviour
{

    [Header("UI VIEW elements")]

    [SerializeField] private bool UnpauseOnClose = false;
    [SerializeField] private bool CloseOnNewView = true;
    [SerializeField] public Button BackButon;
    private UiView ParentView;
    public virtual void Awake()
    {
        BackButon.onClick.AddListener(()=> DisableView_OnClick(this));
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackButon.onClick.Invoke();
        }
    }
    
  
    public void ActiveView_OnClick(UiView viewToActive)
    {
        viewToActive.SetParentView(this);       
        viewToActive.ActiveView();
        this.ActiveView(!CloseOnNewView);
    }
   

    public void DisableView_OnClick(UiView viewToDisable)
    {
        viewToDisable.DisableView();
    }

    public void DestroyView_OnClick(UiView viewToDisable)
    {
        viewToDisable.DestroyView();
    }

    public void SetParentView(UiView parentView)
    {
        ParentView = parentView;
        
    }

    public void ActiveView(bool active)
    {
        this.gameObject.SetActive(active);
       
    }

    public void ActiveView(Action onBackButtonAction = null)
    {
        if (onBackButtonAction != null)
            BackButon.onClick.AddListener(() => onBackButtonAction());


        if(!gameObject.activeSelf)
            this.ActiveView(true);
    }

    public void DisableView()
    {
        if (ParentView != null)
        {
            ParentView.ActiveView();
        }


        if(UnpauseOnClose)
            GameControlller.Instance.IsPaused = false;

        this.ActiveView(false);      
    }

    public void DestroyView()
    {
        if (ParentView != null)
        {
            ParentView.ActiveView();
        }

        Destroy(this.gameObject);
    }

    public void DisableBackButton()
    {
        BackButon.gameObject.SetActive(false);
    }

    public Button GetBackButton()
    {
        return BackButon;
    }
}




