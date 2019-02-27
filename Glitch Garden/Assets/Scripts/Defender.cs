using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starsCost = 100;
    [SerializeField] int starsGenerating = 5;
    StarsDisplay starsDisplay = null;

    private void Start()
    {
        starsDisplay = FindObjectOfType<StarsDisplay>();
    }

    public void AddStars()
    {
        starsDisplay.AddStars(starsGenerating);
    }

    public int GetStarsCost()
    {
        return starsCost;
    }
}
