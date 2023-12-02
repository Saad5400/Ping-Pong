using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public GameObject hitSFX, leftBorder, rightBorder;

    public BallMovement ballMovement;
    public ScoreManager scoreManager;

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if (collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }
        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY * 2f));
    }

    void FixedUpdate()
    {
        if (transform.position.x < leftBorder.transform.position.x)
        {
            OnLeftBorderHit();
        }
        else if (transform.position.x > rightBorder.transform.position.x)
        {
            OnRightBorderHit();
        }
    }

    private void OnRightBorderHit()
    {
        scoreManager.Player1Goal();
        ballMovement.player1Start = false;
        StartCoroutine(ballMovement.Launch());
    }

    private void OnLeftBorderHit()
    {
        scoreManager.Player2Goal();
        ballMovement.player1Start = true;
        StartCoroutine(ballMovement.Launch());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (scoreManager.isGameOver)
        {
            return;
        }
        
        if (collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            Bounce(collision);
        }
        else if (collision.gameObject.name == "Right Border")
        {
            OnRightBorderHit();
        }
        else if (collision.gameObject.name == "Left Border")
        {
            OnLeftBorderHit();
        }
        Instantiate(hitSFX, transform.position, transform.rotation);
    }
}
