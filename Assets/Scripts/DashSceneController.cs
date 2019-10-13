using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashSceneController : MonoBehaviour
{
    private int boostMeterValue = 0;
    private float timeLimit = 60;

    public Text timerText;

    public Slider boostMeter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopGame()
    {
        GameStatus.Play = false;
    }

    public void ChangeBoostMeterValue(int deltaMeter)
    {
        boostMeterValue += deltaMeter;
    }

    public void ResetBoostMeter()
    {
        boostMeterValue = 0;
    }

    public void IncreaseTimeLimit(float increaseValue)
    {
        timeLimit += increaseValue;
    }

    public float GetTimeLimit()
    {
        return timeLimit;
    }

    public int GetBoostMeterValue()
    {
        return boostMeterValue;
    }


}
