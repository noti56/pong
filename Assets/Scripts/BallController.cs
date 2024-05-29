using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] Vector2 initalSpeedPower = new Vector2(5, 0);
    [SerializeField] Vector2 afterPaddlehit = new Vector2(0, 2);
    [SerializeField]
    private
    float speedIncreasePerHit = 1.000000000001f;
    private GameManager gameManager;

    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.velocity = initalSpeedPower;
    }
    // Update is called once per frame
    void Update()
    {
        // print(rb.velocity);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {

            Vector2 contactPoint = collision.ClosestPoint(transform.position);
            Vector2 paddleCenter = collision.gameObject.transform.position;
            float verticalDirection = (contactPoint.y > paddleCenter.y) ? 1f : -1f;
            print(verticalDirection);

            rb.velocity = new Vector2(-rb.velocity.x, verticalDirection * afterPaddlehit.y) * speedIncreasePerHit;
            return;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Reverse y velocity when hitting a wall
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            return;
        }
        gameManager.OnPoint();

    }

}
