using UnityEngine;

public class Racket : MonoBehaviour
{
    
    public float racketSpeed = 15;
    private Rigidbody2D rb;
    protected Vector2 racketDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
