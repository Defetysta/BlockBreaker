using System.Collections;
using UnityEngine;

public class BlocksController : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(AllBlocksDestrotyed());
    }
    private IEnumerator AllBlocksDestrotyed()
    {
        yield return new WaitUntil(() =>transform.childCount == 0);
        SceneLoader.Instance.LoadNextLevel();
    }
}
