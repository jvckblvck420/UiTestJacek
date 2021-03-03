using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableMenuHider : MonoBehaviour
{
    [SerializeField] private GameObject MenuPause;

    private void OnEnable()
    {
        MenuPause.SetActive(false);
    }
    private void OnDisabel()
    {
        MenuPause.SetActive(true);
    }
    // Start is called before the first frame update
    void Awake()
    {
        MenuPause = GameObject.Find("PAUSE_VIEW");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
