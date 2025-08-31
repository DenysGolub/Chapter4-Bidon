using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppInfoSlot : MonoBehaviour
{
    public AppSO data;
    private Button btn;
    private TextMeshProUGUI[] titles;
    private Image splash;
    public AppManager manager;

    void Awake()
    {
        btn = GetComponentInChildren<Button>();
        titles = GetComponentsInChildren<TextMeshProUGUI>();
        splash = GetComponentInChildren<Image>();
        manager = FindFirstObjectByType<AppManager>(FindObjectsInactive.Include);
    }

    void Start()
    {
        btn.image.sprite = data.icon;
        titles[0].text = data.title;
        titles[1].text = data.genres[0].ToString();
        titles[2].text = data.userRating.ToString();
        splash.sprite = data.splashArt;

    }

    void OnEnable()
    {
        btn.onClick.AddListener(OnAppClicked);
        btn.onClick.AddListener(manager.RedirectToAppPage);
    }
    void OnDisable()
    {
        btn.onClick.RemoveListener(OnAppClicked);
        btn.onClick.RemoveListener(manager.RedirectToAppPage);

    }
    public void OnAppClicked()
    {
        manager.app = GetComponentInParent<AppInfoSlot>().data;
        Debug.Log(data);
    }
}