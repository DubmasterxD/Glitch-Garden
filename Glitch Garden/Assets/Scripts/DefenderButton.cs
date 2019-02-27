using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab = null;
    DefenderButton[] buttons = null;
    DefenderSpawner defenderSpawner = null;
    SpriteRenderer spriteRenderer = null;

    private void Start()
    {
        buttons = FindObjectsOfType<DefenderButton>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void OnMouseDown()
    {
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(77, 77, 77, 255);
        }
        spriteRenderer.color = Color.white;
        defenderSpawner.SetSelectedDefender(defenderPrefab);
    }
}
