using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class GameControllerMultiplayer : NetworkBehaviour
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
        if (reduceTimer && NetworkServer.connections.Count == 2)
        {
            if (isServer)
                remainingTime -= Time.deltaTime;

            RpcUpdateTimer(remainingTime);

            if (remainingTime <= 0f)
            {
                ball.GetComponent<BallControllerMultiplayer>().RandDirection();
                StopTimer();
            }
        }
    }

    [ClientRpc]
    void RpcUpdateTimer(float time)
    {
        timer.text = ((int)time).ToString();
    }

    public void ResetTimer()
    {
        RpcShowOrHideTimer(false);
        reduceTimer = true;
        remainingTime = waitTime;
    }

    private void StopTimer()
    {
        reduceTimer = false;
        RpcShowOrHideTimer(true);
    }

    [ClientRpc]
    void RpcShowOrHideTimer(bool hide)
    {
        if (hide)
        {
            timer.GetComponent<Text>().enabled = false;
        }
        else
        {
            timer.GetComponent<Text>().enabled = true;
        }
    }
}
