using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GUIController : MonoBehaviour
{

    #region singleton
    public static GUIController Insntace;

    private void Awake()
    {
        DisableOnStartObject.SetActive(false);
        Insntace = this;
    }
    #endregion

    [SerializeField] private GameObject DisableOnStartObject;

    [SerializeField] private RectTransform ViewsParent;
    [SerializeField] private GameObject InGameGuiObject;
    [SerializeField] private PopUpView PopUp;
    [SerializeField] private PopUpScreenBlocker ScreenBlocker;
    public UiView InvetoryView;
    public UiView PauseView;
    public List <UiView> MenuViews;

    private void Start()
    {
        if (ScreenBlocker)
            ScreenBlocker.InitBlocker();

    }
    void Update()
    {
        if (!PauseView.gameObject.activeSelf)
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (InvetoryView.gameObject.activeSelf)
                {
                    InvetoryView.BackButon.onClick.Invoke();
                }
                else
                {
                    InGameGUIButton_OnClick(InvetoryView);
                }
            }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!InvetoryView.gameObject.activeSelf)
                if (PauseView.gameObject.activeSelf)
                {
                    PauseView.BackButon.onClick.Invoke();
                }
                else
                {
                    InGameGUIButton_OnClick(PauseView);

                }

        }

    }

    private void ActiveInGameGUI(bool active)
    {
        InGameGuiObject.SetActive(active);
    }


    public void ShowPopUpMessage(PopUpInformation popUpInfo)
    {

        PopUpView newPopUp = Instantiate(PopUp, ViewsParent) as PopUpView;
        newPopUp.ActivePopUpView(popUpInfo);
    }

    public void ActiveScreenBlocker(bool active, PopUpView popUpView)
    {
        if (active)
            ScreenBlocker.AddPopUpView(popUpView);
        else
            ScreenBlocker.RemovePopUpView(popUpView);
    }


    #region IN GAME GUI Clicks
    public void InGameGUIButton_OnClick(UiView viewToActive)
    {
        viewToActive.ActiveView(() => ActiveInGameGUI(true));

        ActiveInGameGUI(false);
        GameControlller.Instance.IsPaused = true;

    }
    #endregion




}
