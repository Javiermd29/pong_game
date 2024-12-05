using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float ballSpeed = 10f;

    private Rigidbody2D ballRb;

    // Start is called before the first frame update
    void Start()
    {
     
        ballRb = GetComponent<Rigidbody2D>();
        LaunchBall();

    }

    private void LaunchBall()
    {

        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(x, y).normalized;

        ballRb.velocity = direction * ballSpeed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        ballRb.velocity = ballRb.velocity.normalized * ballSpeed;

    }

}
