using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewActivedElo : MonoBehaviour
{

    public static bool ViewActived = false;

    private void OnEnable()
    {
        ViewActived = true;
    }

    private void OnDisable()
    {
        ViewActived = false;
    }
}
