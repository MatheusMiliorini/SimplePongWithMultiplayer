using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PointsControllerMultiplayer : NetworkBehaviour
{
    public Text points;
    private GameObject ball;
    private GameObject gameController;

    private void Start()
    {
        ball = GameObject.FindWithTag("Ball");
        gameController = GameObject.FindWithTag("GameController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isServer)
        {
            RpcUpdatePoints();

            // Reset Ball
            ball.GetComponent<BallControllerMultiplayer>().ResetBall();
            gameController.GetComponent<GameControllerMultiplayer>().ResetTimer();

            RpcResetPlayers();
        }
    }

    [ClientRpc]
    private void RpcUpdatePoints()
    {
        int pointsInt = int.Parse(points.text);
        points.text = (pointsInt + 1).ToString();
    }

    [ClientRpc]
    private void RpcResetPlayers()
    {
        // Reset Players
        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.GetComponent<PlayerMoveMultiplayer>().ResetPlayer();
        }
    }
}
