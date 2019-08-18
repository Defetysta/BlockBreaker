using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private float xPush;
    private PaddleMovement paddleMovement;
    [SerializeField]
    private FloatVariable randomFactor = null;
    private Rigidbody2D rb;
    private Vector2 velocityTweak;

    private Vector2 paddlePositionOffset;
    private Vector2 currentPaddlePosition;
    private bool isBallLocked = true;
    private void Start()
    {
        paddleMovement = FindObjectOfType<PaddleMovement>();
        paddlePositionOffset = transform.position - paddleMovement.transform.position;
        xPush = Random.Range(CONST_VALUES.minXPush, CONST_VALUES.maxXPush);
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
        rb.velocity = new Vector2(xPush, CONST_VALUES.yPush);
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

    public void TweakVelocity()
    {
        velocityTweak = new Vector2(
            rb.velocity.x + Random.Range(-randomFactor.Value, randomFactor.Value),
            rb.velocity.y + Random.Range(-randomFactor.Value, randomFactor.Value));

        rb.velocity = velocityTweak.normalized * rb.velocity.magnitude;
    }
}
