using System;
using UnityEngine;

public class ChosenAppEvent : MonoBehaviour
{
    public static event Action<AppSO> app;

    public void RaiseEvent(AppSO data)
    {
        app.Invoke(data);
    }
}
