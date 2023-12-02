using UnityEngine;

public class Racket : MonoBehaviour
{
    public Camera worldCamera;
    public float racketSpeed = 15;
    public float startingRacketSpeed = 5f;
    public float currentRacketSpeed;
    public float racketAcceleration = 0.3f;
    public float racketAccelerationOffset = 0.3f;
    private Rigidbody2D rb;
    protected Vector2 racketDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentRacketSpeed = startingRacketSpeed;
    }

    private void FixedUpdate()
    {
        if (racketDirection.magnitude > racketAccelerationOffset && currentRacketSpeed < racketSpeed)
            currentRacketSpeed += racketAcceleration;
        else if (racketDirection.magnitude < racketAccelerationOffset && currentRacketSpeed > startingRacketSpeed)
            currentRacketSpeed -= racketAcceleration;

        if (currentRacketSpeed > racketSpeed)
            currentRacketSpeed = racketSpeed;
        if (currentRacketSpeed < startingRacketSpeed)
            currentRacketSpeed = startingRacketSpeed;

        rb.velocity = racketDirection * currentRacketSpeed;
    }
}
