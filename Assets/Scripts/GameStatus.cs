using UnityEngine;
public class GameStatus : MonoBehaviour
{
    [SerializeField]
    private FloatVariable gameSpeedMultiplier = null;

    public bool isAutoPlaying = false;

    private void Start()
    {
        ResetTimeScale();
    }

    private void Awake()
    {
        ResetTimeScale();
    }
    private void ResetTimeScale()
    {
        if (gameSpeedMultiplier.ResetOnStart)
            gameSpeedMultiplier.Value = 1;
    }

    public void SetTimeScale()
    {
        Debug.Log(gameSpeedMultiplier.Value);
        Time.timeScale = gameSpeedMultiplier.Value;
    }
}
