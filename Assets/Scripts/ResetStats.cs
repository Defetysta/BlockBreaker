using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStats : MonoBehaviour
{
    [SerializeField]
    private IntVariable[] intsToReset = null;
    [SerializeField]
    private FloatVariable[] floatsToReset = null;

    public void ResetVariables()
    {
        foreach (var item in intsToReset)
        {
            item.Value = 0;
        }

        foreach (var item in floatsToReset)
        {
            item.Value = 0;
        }
    }

    private void OnApplicationQuit()
    {
        ResetVariables();
    }
}
