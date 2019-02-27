using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender = null;
    StarsDisplay starsDisplay = null;
    Camera mainCam = null;

    private void Start()
    {
        starsDisplay = FindObjectOfType<StarsDisplay>();
        mainCam = Camera.main;
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = Input.mousePosition;
        Vector2 worldPos = mainCam.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    public void SetSelectedDefender(Defender newDefender)
    {
        defender = newDefender;
    }

    private void AttemptToPlaceDefender(Vector2 gridPos)
    {
        int defenderCost = defender.GetStarsCost();
        if(starsDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starsDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        float newX = Mathf.RoundToInt(worldPos.x);
        float newY = Mathf.RoundToInt(worldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 gridPos)
    {
        var newDefender = Instantiate(defender, gridPos, Quaternion.identity);
    }
}
