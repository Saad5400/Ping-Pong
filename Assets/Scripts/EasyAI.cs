using UnityEngine;

public class EasyAI : Racket
{
    public GameObject ball;

    void Awake()
    {
        if (GameManager.gameMode == GameMode.EasyAI)
            enabled = true;
    }

    void Update()
    {
        var diff = ball.transform.position.y - gameObject.transform.position.y;
        var absDiff = Mathf.Abs(diff);
        float directionY = absDiff > 0.5 ? diff / absDiff : 0;
        racketDirection = new Vector2(0, directionY).normalized;
    }
}
