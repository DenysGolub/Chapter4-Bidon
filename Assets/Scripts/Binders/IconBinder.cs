using UnityEngine;
using UnityEngine.UI;

namespace Binders
{
    public class IconBinder: BinderBase
    {
        public override void UpdateUI(AppSO so)
        {
            GetComponent<Image>().sprite = so.icon;
        }
    }
}