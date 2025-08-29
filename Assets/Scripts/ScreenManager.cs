using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject landscapeLayout;
    public GameObject portraitLayout;

    private bool lastIsLandscape;

    void Start()
    {
        ApplyLayout();
    }

    void LateUpdate()
    {
        bool isLandscape = DetectOrientation();

        if (isLandscape != lastIsLandscape)
        {
            ApplyLayout();
        }
    }

    bool DetectOrientation()
    {
        switch (Input.deviceOrientation)
        {
            case DeviceOrientation.LandscapeLeft:
            case DeviceOrientation.LandscapeRight:
                return true;

            case DeviceOrientation.Portrait:
            case DeviceOrientation.PortraitUpsideDown:
                return false;

            default:
                return Screen.width > Screen.height;
        }
    }

    void ApplyLayout()
    {
        bool isLandscape = DetectOrientation();

        landscapeLayout.SetActive(isLandscape);
        portraitLayout.SetActive(!isLandscape);

        lastIsLandscape = isLandscape;

        Debug.Log($"[ScreenManager] Orientation: {Input.deviceOrientation}, Width: {Screen.width}, Height: {Screen.height}, Landscape: {isLandscape}");
    }

}
