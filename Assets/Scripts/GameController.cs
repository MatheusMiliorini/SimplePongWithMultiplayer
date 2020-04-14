using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private GameObject ball;
    private Text timer;
    private float waitTime = 3f;
    private float remainingTime;
    private bool reduceTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        timer = GameObject.Find("Timer").GetComponent<Text>();

        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (reduceTimer)
        {
            remainingTime -= Time.deltaTime;

            timer.text = ((int)remainingTime).ToString();

            if (remainingTime <= 0f)
            {
                ball.GetComponent<BallController>().RandDirection();
                StopTimer();
            }
        }
    }

    public void ResetTimer()
    {
        timer.GetComponent<Text>().enabled = true;
        reduceTimer = true;
        remainingTime = waitTime;
    }

    private void StopTimer()
    {
        reduceTimer = false;
        timer.GetComponent<Text>().enabled = false;
    }
}
