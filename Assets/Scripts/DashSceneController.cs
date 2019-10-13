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

    private float distanceCovered = 0f;

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
        distanceCovered += InfinitelyMovingFloor.movementSpeed * Time.deltaTime;
        distanceText.text = distanceCovered + "";
        timerText.text = timeLimit + "";
        if (timeLimit <= 0)
        {
            timerText.text = 0f + "";
            EndGame();
        }

        if (boostMeter.value >= boostMeter.maxValue && !isInvincible)
        {

            isInvincible = true;
            InfinitelyMovingFloor.movementSpeed = InfinitelyMovingFloor.movementSpeed * 2;
            Invoke("EndInvincibleMode", 5f);

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

    public void ChangeTimeLimit(float deltaTime)
    {
        timeLimit += deltaTime;
    }

    private void UpdateTimer()
    {
        ChangeTimeLimit(-1f);
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


    private void EndInvincibleMode()
    {
        isInvincible = false;
        InfinitelyMovingFloor.movementSpeed = InfinitelyMovingFloor.movementSpeed / 2f;
        ResetBoostMeter();
    }
}
