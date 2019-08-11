using UnityEngine;

public class Block : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CONST_VALUES.BALL_TAG))
        {
            Destroy(gameObject);
        }
    }
}
