using UnityEngine;

public class Player1 : Racket
{
    // Update is called once per frame
    void Update()
    {
        float directionY = 0;

        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                var diff = worldCamera.ScreenToWorldPoint(touch.position).y - gameObject.transform.position.y;
                var absDiff = Mathf.Abs(diff);
                directionY = absDiff > 0.1 ? diff / absDiff : 0;
            }
        }
        directionY = directionY == 0 ? Input.GetAxisRaw("Vertical") : directionY;
        racketDirection = new Vector2(0, directionY).normalized;
    }
}
