using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CreateAppSlots : MonoBehaviour
{
    public GameObject prefab;
    public string[] sprites;
    public GameObject[] slots;
    bool isFeatured = true;
    void Start()
    {
        sprites = Directory.GetFiles(Application.streamingAssetsPath + "/SplashArts");
        if (isFeatured)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                prefab.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(sprites[0]);
                Instantiate(prefab, this.transform.GetChild(0).GetChild(0));
                slots.Append(prefab);
            }
        }
        else
        {

        }
    }

    
}
