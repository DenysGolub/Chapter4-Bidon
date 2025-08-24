using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppInfoSlot : MonoBehaviour
{
    public AppSO data;
    private Button btn;
    private TextMeshProUGUI[] titles;
    private Image splash;

    void Awake()
    {
        btn = GetComponentInChildren<Button>();
        titles = GetComponentsInChildren<TextMeshProUGUI>();
        splash = GetComponentInChildren<Image>();
    }

    void Start()
    {
        btn.image.sprite = data.icon;
        titles[0].text = data.title;
        titles[1].text = data.genres[0].ToString();
        titles[2].text = data.userRating.ToString();
        splash.sprite = data.splashArt;

    }
}