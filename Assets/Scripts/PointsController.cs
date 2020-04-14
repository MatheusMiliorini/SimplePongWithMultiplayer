using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    public Text points;
    private GameObject ball;
    private GameObject gameController;

    private void Start()
    {
        ball = GameObject.Find("Ball");
        gameController = GameObject.Find("GameController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int pointsInt = int.Parse(points.text);
        points.text = (pointsInt + 1).ToString();

        // Reset Ball
        ball.GetComponent<BallController>().ResetBall();
        gameController.GetComponent<GameController>().ResetTimer();

        // Reset Players
        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.GetComponent<PlayerMove>().ResetPlayer();
        }
    }
}
