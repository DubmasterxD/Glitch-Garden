using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] AttackerSpawner[] spawners = null;
    [SerializeField] GameObject winLabel = null;
    int enemiesAlive = 0;
    bool timerEnded = false;
    [SerializeField] float timeToLoadNextScene = 3f;
    bool levelEnd = false;

    private void Start()
    {
        winLabel.SetActive(false);
    }

    private void Update()
    {
        CountEnemies();
        CheckIfFinished();
    }

    private void CountEnemies()
    {
        enemiesAlive = 0;
        foreach (AttackerSpawner spawner in spawners)
        {
            enemiesAlive += spawner.transform.childCount;
        }
    }

    private void CheckIfFinished()
    {
        if (timerEnded && enemiesAlive == 0)
        {
            if (levelEnd == false)
            {
                LevelFinished();
            }
        }
    }

    private void LevelFinished()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        StartCoroutine(FindObjectOfType<LevelLoader>().WaitForNextScene(timeToLoadNextScene));
        levelEnd = true;
    }

    public void TimerEnded()
    {
        timerEnded = true;
        foreach(AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
