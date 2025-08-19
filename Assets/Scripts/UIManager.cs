using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public Animator sideMenuAnimator;

    public void ShowAppPage()
    {
        var btn = EventSystem.current.currentSelectedGameObject;

        string appTitle = btn.GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log($"Selected app is {appTitle}");

        //TODO: Make transition to app page
    }


    public void ShowSideMenu()
    {
        sideMenuAnimator.Play("SideMenuIn");
    }

    public void HideSideMenu()
    {
        sideMenuAnimator.Play("SideMenuOut");
    }

}
