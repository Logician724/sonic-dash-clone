using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSceneController : MonoBehaviour
{
    private int boostMeter = 0;
    private float timeLimit = 60;
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

    public void IncrementBoostMeter()
    {
        boostMeter++;
    }

    public void ResetBoostMeter()
    {
        boostMeter = 0;
    }

    public void IncreaseTimeLimit(float increaseValue)
    {
        timeLimit += increaseValue;
    }

    public float GetTimeLimit()
    {
        return timeLimit;
    }

    public int GetBoostMeter()
    {
        return boostMeter;
    }


}
