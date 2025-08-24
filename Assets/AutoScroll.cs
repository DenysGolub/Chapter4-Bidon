using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ScrollRect scrollRect;
    public RectTransform viewPortTransform;
    public RectTransform contentPanelTransform;
    public HorizontalLayoutGroup HLG;
    public RectTransform[] itemList;

    public float autoScrollSpeed = 100f; 
    bool autoScroll = true;

    void Start()
    {
        int itemsToAdd = Mathf.CeilToInt(viewPortTransform.rect.width / (itemList[0].rect.width + HLG.spacing));

        for (int i = 0; i < itemsToAdd; i++)
        {
            RectTransform RT = Instantiate(itemList[i % itemList.Length], contentPanelTransform);
            RT.SetAsLastSibling();
        }

        for (int i = 0; i < itemsToAdd; i++)
        {
            int num = itemList.Length - i - 1;
            while (num < 0)
                num += itemList.Length;

            RectTransform RT = Instantiate(itemList[num], contentPanelTransform);
            RT.SetAsFirstSibling();
        }
    }

    void Update()
    {
        if (autoScroll)
        {
            for (int i = 0; i < contentPanelTransform.childCount; i++)
            {
                RectTransform child = contentPanelTransform.GetChild(i) as RectTransform;
                child.anchoredPosition -= new Vector2(autoScrollSpeed * Time.deltaTime, 0);

                float width = child.rect.width + HLG.spacing;

                if (child.anchoredPosition.x < -width * 2)
                {
                    RectTransform last = contentPanelTransform.GetChild(contentPanelTransform.childCount - 1) as RectTransform;
                    float newX = last.anchoredPosition.x + last.rect.width + HLG.spacing;

                    child.anchoredPosition = new Vector2(newX, child.anchoredPosition.y);
                    child.SetAsLastSibling();
                }
            }
        }
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        autoScroll = false;
        Debug.Log("Pointer down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer up");
        autoScroll = true;
    }
}
