using System;
using UnityEngine;
using UnityEngine.UI;
public class InfinityScroller : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform viewPortTransform;
    public RectTransform contentPanelTransform;
    public HorizontalLayoutGroup HLG;
    public RectTransform[] itemList;
    Vector2 oldVelocity;
    bool isUpdated;
    void Start()
    {
        isUpdated = false;
        oldVelocity = Vector2.zero;
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
            {
                num += itemList.Length;
            }
            RectTransform RT = Instantiate(itemList[num], contentPanelTransform);
            RT.SetAsFirstSibling();
        }

        contentPanelTransform.localPosition = new Vector3((0 - (itemList[0].rect.width + HLG.spacing) * itemsToAdd), 
        contentPanelTransform.localPosition.y,
        contentPanelTransform.localPosition.z);
    }
    void Update()
    {
        if (isUpdated)
        {
            scrollRect.velocity = oldVelocity;
            isUpdated = false;
        }

        float itemWidth = itemList[0].rect.width + HLG.spacing;
        float totalWidth = itemList.Length * itemWidth;

        Vector2 pos = contentPanelTransform.anchoredPosition;

        if (pos.x > 0)
        {
            pos.x -= totalWidth;
        }
        else if (pos.x < -totalWidth)
        {
            pos.x += totalWidth;
        }

        contentPanelTransform.anchoredPosition = pos;
    }


}
