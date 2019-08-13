using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField]
    [Range(0, 2)]
    private float gameSpeedMultiplier = 1f;

    private void Update()
    {
        Time.timeScale = gameSpeedMultiplier;
    }
}
