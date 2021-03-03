using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulItemNavigation : MonoBehaviour
{
    [SerializeField] private Button [] SoulItems;
    private int index = 0;
    private int previousIndex;
    public Scrollbar verticalScroll;
    public InventoryView Inventory;
    public PopUpView PopUp;

    private void Start()
    {
        SoulItems = GetComponentsInChildren<Button>();
        SoulItems[index].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }


    private void Update()
    {

        if (PopUpView.popUpActived)
        {
            return;

        }
        else
        {
            


            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                verticalScroll.value += 0.15f;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                verticalScroll.value -= 0.15f;
            }



            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (index == 11)
                {
                    verticalScroll.value = 0;
                }

                if (index >= SoulItems.Length - 1)
                {
                    return;
                }
                else
                {
                    index++;
                    previousIndex = index - 1;
                }


                SoulItems[index].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                SoulItems[previousIndex].transform.localScale = new Vector3(1f, 1f, 1f);

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (index == 10)
                {
                    verticalScroll.value = 1;
                }
                if (index <= 0)
                {
                    return;
                }
                else
                {
                    index--;
                    previousIndex = index + 1;
                }


                SoulItems[index].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                SoulItems[previousIndex].transform.localScale = new Vector3(1f, 1f, 1f);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Inventory.SoulItem_OnClick(SoulItems[index].GetComponent<SoulInformation>());
            }
        }

      
    }
    public void RefreshArray()
    {
        
        StartCoroutine(ReloadArray());
        //SoulItems = GetComponentsInChildren<Button>();
    }
    IEnumerator ReloadArray()
    {
        SoulItems = null;
        yield return new WaitForSecondsRealtime(0.5f);
        SoulItems = GetComponentsInChildren<Button>();
        index = 0;
        SoulItems[index].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
}
