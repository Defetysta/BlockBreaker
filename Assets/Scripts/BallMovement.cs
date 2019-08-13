using System;
using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;


    [SerializeField]
    private PaddleMovement paddleMovement = null;

    private Vector2 paddlePositionOffset;
    private Vector2 currentPaddlePosition;
    private bool isBallLocked = true;

    private void Start()
    {
        paddlePositionOffset = transform.position - paddleMovement.transform.position;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(LaunchBall());
    }

    private void Update()
    {
        if(isBallLocked == true)
            LockBallToPaddle();
    }


    private void LockBallToPaddle()
    {
        currentPaddlePosition = paddleMovement.transform.position;
        transform.position = currentPaddlePosition + paddlePositionOffset;
        rb.velocity = new Vector2(2f, 15f);
    }

    private IEnumerator LaunchBall()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        isBallLocked = false;
    }

    public bool IsBallLocked()
    {
        return isBallLocked;
    }
}
