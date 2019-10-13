using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DashSceneController : MonoBehaviour
{

    public static bool isInvincible = false;
    public float boostMeterMaxValue = 50;
    private float timeLimit = 60;

    private float timeAdded = 0f;

    public Text timerText;

    public Text distanceText;
    public Slider boostMeter;



    // Start is called before the first frame update
    void Start()
    {
        boostMeter.maxValue = boostMeterMaxValue;
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    void Update()
    {
        timerText.text = timeLimit + "";
        if (timeLimit <= 0)
        {
            timerText.text = 0f + "";
            EndGame();
        }

        if (boostMeter.value >= boostMeter.maxValue)
        {
            ResetBoostMeter();
        }
    }

    public void StopGame()
    {
        GameStatus.Play = false;
    }

    public void ChangeBoostMeterValue(float deltaMeter)
    {
        boostMeter.value += deltaMeter;
    }

    public void ResetBoostMeter()
    {
        boostMeter.value = 0;
    }

    private void ChangeTimeLimit(float deltaTime)
    {
        timeLimit += deltaTime;
    }

    private void UpdateTimer()
    {
        ChangeTimeLimit(-1f + timeAdded );
        timeAdded = 0f;
    }

    public void AddToTimer(float deltaTime)
    {
        timeAdded += deltaTime;
    }

    public float GetTimeLimit()
    {
        return timeLimit;
    }

    public float GetBoostMeterValue()
    {
        return boostMeter.value;
    }


    public void EndGame()
    {
        CancelInvoke();
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }

}
