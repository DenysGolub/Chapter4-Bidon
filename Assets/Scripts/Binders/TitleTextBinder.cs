using Binders;
using TMPro;
using UnityEngine;

public class TitleTextBinder : TextBinderBase
{
    public override void UpdateUI(AppSO so)
    {
        if (target) target.text = so.title;
    }
}




