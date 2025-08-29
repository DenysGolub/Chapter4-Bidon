using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class AppBinder : MonoBehaviour
{
    public AppManager appManager;
    public AppSO app;
    public BindType bindType;

    [Header("Single UI targets")]
    public TMP_Text textTarget;
    public Image imageTarget;

    [Header("List targets")]
    public Transform contentParent;        
    public GameObject listItemPrefab;


    void Awake()
    {
        appManager = transform.root.GetComponent<AppManager>();
    }

    void OnEnable()
    {
        appManager.OnChanged += UpdateUI;
    }

    void OnDisable()
    {
        appManager.OnChanged -= UpdateUI;
    }

    private void UpdateUI(AppSO so)
    {
        app = so;
        Debug.Log("Received");
        switch (bindType)
        {
            case BindType.Title:
                if (textTarget) textTarget.text = so.title;
                break;

            case BindType.Description:
                if (textTarget) textTarget.text = so.description;
                break;

            case BindType.UserRating:
                if (textTarget) textTarget.text = so.userRating.ToString("0.0");
                break;

            case BindType.Downloads:
                if (textTarget) textTarget.text = so.downloads.ToString();
                break;

            case BindType.Developer:
                if (textTarget) textTarget.text = so.developer;
                break;

            case BindType.Icon:
                if (imageTarget) imageTarget.sprite = so.icon;
                break;

            case BindType.SplashArt:
                if (imageTarget) imageTarget.sprite = so.splashArt;
                break;

            case BindType.GameRating:
                if (textTarget) textTarget.text = so.gameRating.ToString();
                break;

            case BindType.Genres:
                if (textTarget) textTarget.text = so.genres[0].ToString();
                break;

            case BindType.TempScreens:
                PopulateListSprites(so.tempScreens);
                break;
        }
    }

    private void PopulateList(List<string> items)
    {
        if (contentParent == null || listItemPrefab == null) return;

        foreach (Transform t in contentParent)
            Destroy(t.gameObject);

        foreach (var s in items)
        {
            var go = Instantiate(listItemPrefab, contentParent);
            var text = go.GetComponentInChildren<TMP_Text>();
            if (text) text.text = s;
        }
    }

    private void PopulateListSprites(List<Sprite> sprites)
    {
        if (contentParent == null || listItemPrefab == null) return;

        foreach (Transform t in contentParent)
            Destroy(t.gameObject);

        foreach (var sp in sprites)
        {
            var go = Instantiate(listItemPrefab, contentParent);
            var img = go.GetComponentInChildren<Image>();
            if (img) img.sprite = sp;
        }
    }
}

public enum BindType
{
    Title,
    Description,
    UserRating,
    GameRating,
    Downloads,
    Developer,
    Icon,
    SplashArt,
    Genres,
    TempScreens
}
