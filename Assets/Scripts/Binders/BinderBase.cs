namespace Binders
{
    using UnityEngine;

    public abstract class BinderBase : MonoBehaviour
    {
        private AppManager appManager;
        public abstract void UpdateUI(AppSO so);

        public void Awake()
        {
            appManager = FindAnyObjectByType<AppManager>(FindObjectsInactive.Include);
        }

        public void OnEnable()
        {
            appManager.OnChanged += UpdateUI;
        }

        public void OnDisable()
        {
            appManager.OnChanged -= UpdateUI;
        }
    }

}