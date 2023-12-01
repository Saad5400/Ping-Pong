using UnityEngine;

public class Player2 : Racket
{
    void Awake()
    {
        enabled = GameManager.gameMode == GameMode.LocalPvP;
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical2");
        racketDirection = new Vector2(0, directionY).normalized;
    }
}
