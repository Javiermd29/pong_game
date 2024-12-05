using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{

    public float paddleSpeed = 10f;
    public string inputAxis;

    // Update is called once per frame
    void Update()
    {
        
        float movement = Input.GetAxis(inputAxis) * paddleSpeed * Time.deltaTime;

        transform.Translate(0, movement, 0);

        float clampedY = Mathf.Clamp(transform.position.y, -3.36f, 3.36f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

    }
}
