using TMPro;
using UnityEngine;

namespace Binders
{
    public class RatingTextBinder : TextBinderBase
    {
        public void Start()
        {
            target = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        public override void UpdateUI(AppSO so)
        {
            if (target) target.text = so.userRating.ToString("0.0");
        }
    }
}