using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject landscapeLayout;
    public GameObject portraitLayout;

    void Start()
    {
        ChangeCanvas(); 
    }

    void Update()
    {
        ChangeCanvas();
    }

    void ChangeCanvas()
    {
#if UNITY_EDITOR
        bool isLandscape = Screen.width > Screen.height;
#else
        bool isLandscape = 
            Input.deviceOrientation == DeviceOrientation.LandscapeLeft || 
            Input.deviceOrientation == DeviceOrientation.LandscapeRight;
#endif

        if (isLandscape)
        {
            landscapeLayout.SetActive(true);
            portraitLayout.SetActive(false);
        }
        else
        {
            landscapeLayout.SetActive(false);
            portraitLayout.SetActive(true);
        }
    }
}
