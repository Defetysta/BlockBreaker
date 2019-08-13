using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private AudioSource audioSource;
    private BallMovement ballMovement;
    [SerializeField]
    private SimpleAudioEvent bounceSound = null;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ballMovement = GetComponent<BallMovement>();
    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ballMovement.IsBallLocked() == false && collision.gameObject.CompareTag(CONST_VALUES.BLOCK_TAG) == false)
            bounceSound.Play(audioSource);
    }
}
