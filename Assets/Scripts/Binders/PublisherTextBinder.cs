using TMPro;
using UnityEngine;

public class PublisherTextBinder : TextBinderBase
{
    public override void UpdateUI(AppSO so)
    {
        if (target) target.text = so.developer;
    }
}