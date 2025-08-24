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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
    void Update()
    {
        if (isUpdated)
        {
            scrollRect.velocity = oldVelocity;
            isUpdated = false;
        }

        float totalWidth = itemList.Length * (itemList[0].rect.width + HLG.spacing);

        if (contentPanelTransform.localPosition.x > 0)
        {
            oldVelocity = scrollRect.velocity;
            contentPanelTransform.localPosition -= new Vector3(totalWidth, 0, 0);
            isUpdated = true;
        }

        if (contentPanelTransform.localPosition.x < -totalWidth)
        {
            oldVelocity = scrollRect.velocity;
            contentPanelTransform.localPosition += new Vector3(totalWidth, 0, 0);
            isUpdated = true;
        }
    }
}
