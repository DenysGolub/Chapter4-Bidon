using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AppManager : MonoBehaviour
{
    public AppSO app;
    public GameObject appPage;
    public GameObject mainPage;


    public void RedirectToAppPage()
    {
        mainPage.SetActive(false);
        appPage.SetActive(true);

        RaiseChanged();
    }



    public event Action<AppSO> OnChanged;

    public void RaiseChanged()
    {
        OnChanged?.Invoke(app);
        Debug.Log($"Sended + {app}");
    }
}
