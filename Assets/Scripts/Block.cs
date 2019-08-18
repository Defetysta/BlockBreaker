using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private SimpleAudioEvent blockHit = null;
    [SerializeField]
    private GameObject breakBlockParticle = null;
    [SerializeField]
    private Sprite[] damageSprites = null;
    private AudioSource audioSource;
    private BoxCollider2D coll;
    private SpriteRenderer rend;
    [SerializeField]
    private GameEventRaiser grantPoints = null;
    [SerializeField]
    private GameEventRaiser decreaseBlockNumber = null;
    [SerializeField]
    private GameEventRaiser increaseblockNumber = null;

    private int timesHit;
    private int maxHits;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coll = GetComponent<BoxCollider2D>();
        rend = GetComponent<SpriteRenderer>();
        if (CompareTag(CONST_VALUES.BREAKABLE_TAG))
            increaseblockNumber.RaiseEvent();
        maxHits = damageSprites.Length + 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        blockHit.Play(audioSource);
        if (CompareTag(CONST_VALUES.BREAKABLE_TAG))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (damageSprites[spriteIndex] != null)
            rend.sprite = damageSprites[spriteIndex];
        else
            Debug.LogError("spriteIndex out of range! " + gameObject.name);
    }

    private void DestroyBlock()
    {
        DisablePhysicsComponents();
        RaiseEvents();
        TriggerParticle();
        StartCoroutine(AwaitEndOfSound());
    }

    private void DisablePhysicsComponents()
    {
        coll.enabled = false;
        rend.enabled = false;
    }

    private void RaiseEvents()
    {
        grantPoints.RaiseEvent();
        decreaseBlockNumber.RaiseEvent();
    }

    private void TriggerParticle()
    {
        var go = Instantiate(breakBlockParticle, transform.position, transform.rotation, transform.parent);
        Destroy(go, 1f);
    }

    private IEnumerator AwaitEndOfSound()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        Destroy(gameObject);
    }
}
