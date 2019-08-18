using System.Collections;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
    [SerializeField]
    private IntVariable numberOfBlocks = null;
    private void Start()
    {
        StartCoroutine(AwaitAllBlocksDestroyed());
    }
    private IEnumerator AwaitAllBlocksDestroyed()
    {
        yield return null;
        yield return new WaitUntil(() => numberOfBlocks.Value == 0);
        yield return null;
        SceneLoader.Instance.LoadNextLevel();
    }
}
