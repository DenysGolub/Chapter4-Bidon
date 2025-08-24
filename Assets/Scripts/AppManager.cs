using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<AppSO> apps;
    void Start()
    {
        foreach (var app in apps)
        {
            slotPrefab.GetComponent<AppInfoSlot>().data = app;
            Instantiate(slotPrefab, this.transform);
        }   
    }
}
