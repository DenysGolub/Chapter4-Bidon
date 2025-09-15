using System.Collections.Generic;
using UnityEngine;

public class AppList : MonoBehaviour
{
    public List<AppSO> appList;
    
    public GameObject contentPanel;
    public GameObject slotPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (AppSO app in appList)
        {
            slotPrefab.GetComponent<AppInfoSlot>().data = app;
            Instantiate(slotPrefab, contentPanel.transform);
        } 
    }


}
