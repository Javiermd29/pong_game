using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float ballSpeed = 10f;

    private Rigidbody2D ballRb;

    private GameManager gameManager;

    private float leftLimit = -15f;
    private float rightLimit = 15f;

    private bool isWaiting = false;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
     
        ballRb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();

        StartCoroutine(PrepareBall());

    }

    IEnumerator PrepareBall()
    {
        ballRb.velocity = Vector2.zero;
        transform.position = Vector3.zero;

        isWaiting = true;
        yield return new WaitForSeconds(2);
        isWaiting = false;

        if (!isGameOver)
        {
            LaunchBall();
        }

    }
    private void LaunchBall()
    {

        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(x, y).normalized;

        ballRb.velocity = direction * ballSpeed;

    }

    private void Update()
    {

        if (!isWaiting && !isGameOver)
        {

            if (transform.position.x < leftLimit)
            {
                gameManager.GoalScored(true);
                StartCoroutine(PrepareBall());
            }
            else if (transform.position.x > rightLimit)
            {
                // Gol del jugador izquierdo
                gameManager.GoalScored(false);
                StartCoroutine(PrepareBall());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!isGameOver)
        {
            ballRb.velocity = ballRb.velocity.normalized * ballSpeed;

        }

    }

    void ResetBall()
    {
        transform.position = Vector3.zero;
        ballRb.velocity = Vector2.zero;
        LaunchBall();
    }

    public void StopBall()
    {

        ballRb.velocity = Vector2.zero;
        transform.position = Vector3.zero;
        isGameOver = true;

    }

}
