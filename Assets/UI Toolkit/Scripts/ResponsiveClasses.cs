using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class SafeAreaDocument : MonoBehaviour
{
    [SerializeField] float cornerPadding = 20f; // запас для заокруглених кутів
    private UIDocument _uiDocument;
    private VisualElement _root;
    private Rect _lastSafeArea;
    private ScreenOrientation _lastOrientation;
    void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        _root = _uiDocument.rootVisualElement;

        _root.RegisterCallback<GeometryChangedEvent>(evt => ApplySafeArea());

    }


    void Update()
    {
        Rect safe = Screen.safeArea;
        ApplySafeArea();
        _lastSafeArea = safe;
        _lastOrientation = Screen.orientation;
    }

    private void ApplySafeArea()
    {
        Rect safe = Screen.safeArea;

        float topPadding = cornerPadding;
        float bottomPadding = cornerPadding;
        float leftPadding = cornerPadding-10;
        float rightPadding = cornerPadding-10;



        float topInset = safe.y;
        float bottomInset = Screen.height - (safe.y + safe.height) + bottomPadding;
        float leftInset = safe.x + leftPadding;
        float rightInset = Screen.width - (safe.x + safe.width) + rightPadding;
        _root.style.marginTop = topInset+topPadding;
        _root.style.marginBottom = bottomInset;
        _root.style.marginLeft = leftInset;
        _root.style.marginRight = rightInset;
    }

}
