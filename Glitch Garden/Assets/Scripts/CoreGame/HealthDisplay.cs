using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int healthPoints = 10;
    [SerializeField] GameObject gameLost = null;
    Text healthText = null;
    float waitTime = 1f;

    private void Start()
    {
        gameLost.SetActive(false);
        healthText = GetComponent<Text>();
        DisplayHealth();
    }

    public void DecreaseHealth()
    {
        if (healthPoints > 0)
        {
            healthPoints--;
            DisplayHealth();
            if (healthPoints == 0)
            {
                GameLost();
            }
        }           
    }

    private void GameLost()
    {
        gameLost.SetActive(true);
        GetComponent<AudioSource>().Play();
        StartCoroutine(FindObjectOfType<LevelLoader>().LoadLooseScene(waitTime));
    }

    private void DisplayHealth()
    {
        healthText.text = healthPoints.ToString();
    }
}
