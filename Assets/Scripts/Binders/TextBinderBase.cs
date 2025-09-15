using System;
using Binders;
using TMPro;
using UnityEngine;

public class TextBinderBase : BinderBase
{
    private protected TextMeshProUGUI target;
    public void Start()
    {
        target = GetComponent<TextMeshProUGUI>();
    }

    public override void UpdateUI(AppSO so)
    {
        return;
    }

   
}