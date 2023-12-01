using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;

    public static GameMode gameMode = GameMode.EasyAI;

    private static GameManager Instance = null;

    void Start()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void StartGame(int gameMode)
    {
        GameManager.gameMode = (GameMode)gameMode;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();

    }
}

public enum GameMode
{
    LocalPvP,
    OnlinePvP,
    EasyAI,
    MediumAI,
    HardAI,
}
