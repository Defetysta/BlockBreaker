using System;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector2 desiredPosition;
    private float spriteWidth;
    private GameStatus gameStatus;
    private BallMovement ballMovement;
    private void Start()
    {
        desiredPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.size.x;
        gameStatus = FindObjectOfType<GameStatus>();
        ballMovement = FindObjectOfType<BallMovement>();
    }

    private void Update()
    {
        ChooseInput();
        ClampXPosition();
        transform.position = desiredPosition;
    }

    private void ChooseInput()
    {
        if (gameStatus.isAutoPlaying == false)
            GetMouseXPosition();
        else
            GetBallPosition();
    }

    private void GetBallPosition()
    {
        desiredPosition.x = ballMovement.transform.position.x;
    }

    private void GetMouseXPosition()
    {
        desiredPosition.x = Input.mousePosition.x / Screen.width * CONST_VALUES.SCREEN_WIDTH_IN_UNITS;
    }

    private void ClampXPosition()
    {
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, 0 + spriteWidth / 2, CONST_VALUES.SCREEN_WIDTH_IN_UNITS - spriteWidth / 2);
    }
}
