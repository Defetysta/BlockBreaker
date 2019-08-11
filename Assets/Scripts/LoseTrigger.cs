using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(CONST_VALUES.BALL_TAG))
        {
            SceneLoader.Instance.LoadGameOver();
        }
    }
}
