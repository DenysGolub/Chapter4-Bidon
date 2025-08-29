using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject mainPage;
    public GameObject appPage;
    public void RedirectToMainPage()
    {
        mainPage.SetActive(true);
        appPage.SetActive(false);
    }

}
