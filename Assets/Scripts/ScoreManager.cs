using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public int scoreToReach;
    private int player1Score = 0;
    private int player2Score = 0;
    public bool isGameOver = false;

    public Text player1Text;
    public Text player2Text;
    public GameObject winText, endSoundEffect;
    public PostProcessVolume postProcessVolume;

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

    private IEnumerator RestartGame()
    {
        Bloom bloom;
        postProcessVolume.profile.TryGetSettings(out bloom);
        var amount = 0.001f;
        while (bloom.intensity.value < 250)
        {
            bloom.intensity.value += amount;
            amount += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        GameManager.gameMode = GameMode.LocalPvP;
        SceneManager.LoadScene(0);
    }

    public void CheckScore()
    {
        var textMeshPro = winText.GetComponent<TextMeshProUGUI>();
        if (player1Score == scoreToReach || player2Score == scoreToReach)
        {
            isGameOver = true;
            textMeshPro.color = player1Score == scoreToReach ? new Color32(31, 81, 255, 255) : new Color32(62, 255, 0, 255);
            textMeshPro.text = player1Score == scoreToReach ? "BLUE WINS!" : "GREEN WINS!";
            Instantiate(endSoundEffect);
            StartCoroutine(RestartGame());
        }
    }
}
