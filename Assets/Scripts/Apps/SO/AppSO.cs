using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewApp", menuName = "Market/App")]
public class AppSO : ScriptableObject
{
    public string title;
    public string description;
    [Range(0, 5)] public float userRating;
    public Sprite icon;
    public Sprite splashArt;
    public int downloads;
    public string developer;
    public GameRating gameRating;

    public List<GenreType> genres;
    public List<Sprite> tempScreens;

}
