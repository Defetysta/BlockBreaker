using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private SimpleAudioEvent blockDestroyed = null;
    private AudioSource audioSource;
    private BoxCollider2D coll;
    private Renderer rend;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coll = GetComponent<BoxCollider2D>();
        rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CONST_VALUES.BALL_TAG))
        {
            blockDestroyed.Play(audioSource);
            coll.enabled = false;
            rend.enabled = false;
            StartCoroutine(AwaitEndOfSound());
        }
    }

    private IEnumerator AwaitEndOfSound()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        Destroy(gameObject);
    }
}
