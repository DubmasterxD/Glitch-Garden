using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds.")]
    [SerializeField] float levelTime = 10f;

    private void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(timerFinished)
        {
            FindObjectOfType<LevelController>().TimerEnded();
        }
    }
}
