using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRectEx : ScrollRect
{
    private ChiScrollRect parentScroll;

    private void Awake()
    {
    }

    public override void OnDrag(PointerEventData eventData)
    {
        parentScroll = GetComponentInParent<ChiScrollRect>();

        // Рух тільки по горизонталі
        if (horizontal)
            content.anchoredPosition += new Vector2(eventData.delta.x, 0f);

        // Вертикаль передаємо батьку
        if (parentScroll != null)
            parentScroll.OnDrag(eventData);
    }


    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        parentScroll?.OnBeginDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        parentScroll?.OnEndDrag(eventData);
    }

    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        base.OnInitializePotentialDrag(eventData);
        parentScroll?.OnInitializePotentialDrag(eventData);
    }
}
