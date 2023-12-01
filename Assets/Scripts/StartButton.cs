using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame(string gameMode)
    {
        GameManager.gameMode = (GameMode)System.Enum.Parse(typeof(GameMode), gameMode);
        SceneManager.LoadScene(1);
    }
}