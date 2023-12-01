using UnityEngine;

public class Player1 : Racket
{
    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        racketDirection = new Vector2(0, directionY).normalized;
    }
}
