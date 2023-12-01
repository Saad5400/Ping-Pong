using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public int scoreToReach;
    private int player1Score = 0;
    private int player2Score = 0;

    public Text player1Text;
    public Text player2Text;

    public void Player1Goal()
    {
        player1Score++;
        player1Text.text = player1Score.ToString();
        CheckScore();
    }


    public void Player2Goal()
    {
        player2Score++;
        player2Text.text = player2Score.ToString();
        CheckScore();
    }

    public void CheckScore()
    {
        if (player1Score == scoreToReach || player2Score == scoreToReach)
        {
            SceneManager.LoadScene(0);
        }
    }
}
