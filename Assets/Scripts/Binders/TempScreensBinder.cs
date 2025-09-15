using UnityEngine;
using UnityEngine.UI;

namespace Binders
{
    public class TempScreensBinder: BinderBase
    {
        
        
        public GameObject tempScreenPrefab;
        public override void UpdateUI(AppSO so)
        {
            DestroyAllChildren();
            gameObject.SetActive(true);
            foreach (var item in so.tempScreens)
            {
                tempScreenPrefab.GetComponent<Image>().sprite = item;
                Instantiate(tempScreenPrefab, transform);
            }
        }
        
        
        public void DestroyAllChildren()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Transform child = transform.GetChild(i);

                Destroy(child.gameObject);
            }
        }
    }
}