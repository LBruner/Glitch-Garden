using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip ("Level Timer in Seconds")]
    [SerializeField] float LevelTime = 10f;

    bool triggerlevelFinished = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    public  void Timer()
    {
        if (triggerlevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / LevelTime;
        bool TimerFineshed = (Time.timeSinceLevelLoad >= LevelTime);
        if (TimerFineshed)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggerlevelFinished = true;
        }
    }
}
