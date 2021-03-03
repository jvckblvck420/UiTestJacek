using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{


    [SerializeField] private SoulEnemy[] Enemies;
    // Start is called before the first frame update
    private void Awake()
    {
        Enemies = GetComponentsInChildren<SoulEnemy>();
    }
    void Start()
    {
        RefreshEnemiesArray();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Enemies[0] == null)
            {
                RefreshEnemiesArray();
            }
            else
            {
                 Enemies[0].Combat_OnClick();
            }
           
            
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Enemies[1] == null)
            {
                RefreshEnemiesArray();
            }
            else
            {
                Enemies[1].Combat_OnClick();
            }
         
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Enemies[2] == null)
            {
                RefreshEnemiesArray();
            }
            else
            {
                Enemies[2].Combat_OnClick();
            }
           
        }
    }

    IEnumerator RefreshEnemiesCor()
    {
        Enemies = null;
        yield return new WaitForSecondsRealtime(0.9f);
        Enemies = GetComponentsInChildren<SoulEnemy>();
    }

    public void RefreshEnemiesArray()
    {
        StartCoroutine(RefreshEnemiesCor());
    }

    
}
