using System.Text;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private IntVariable currentPoints = null;
    [SerializeField]
    private TextMeshProUGUI scoreText = null;
    private void Start()
    {
        if (currentPoints.ResetOnStart)
            currentPoints.Value = 0;
        UpdateScore();
    }

    private void OnEnable()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<ScoreText>().GetComponent<TextMeshProUGUI>();
            
        }
        scoreText.text = currentPoints.Value.ToString();
    }
}
