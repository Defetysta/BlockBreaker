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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballMovement.TweakVelocity();
        if (ballMovement.IsBallLocked() == false)
            if(collision.gameObject.CompareTag(CONST_VALUES.BREAKABLE_TAG) == false && (collision.gameObject.CompareTag(CONST_VALUES.UNBREAKABLE_TAG)) == false)
                bounceSound.Play(audioSource);
    }
}
