using TMPro;
using UnityEngine;

namespace Binders
{
    public class DescriptionTextBinder : TextBinderBase
    {
        public override void UpdateUI(AppSO so)
        {
            if (target) target.text = so.description;
        }
    }
}