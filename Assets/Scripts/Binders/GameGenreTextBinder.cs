using TMPro;
using UnityEngine;

namespace Binders
{
    public class GameGenreTextBinder : TextBinderBase
    {
        public void Start()
        {
            target = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        public override void UpdateUI(AppSO so)
        {
            if (target) target.text = so.genres[0].ToString();
        }
    }
}