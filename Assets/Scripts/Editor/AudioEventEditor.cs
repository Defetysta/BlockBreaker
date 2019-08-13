using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(AudioEvent), true)]
public class AudioEventEditor : Editor
{
    [SerializeField] private AudioSource previewGameObject;

    public void OnEnable()
    {
        previewGameObject = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
    }

    public void OnDisable()
    {
        DestroyImmediate(previewGameObject.gameObject);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
        if (GUILayout.Button("Preview"))
        {
            ((AudioEvent)target).Play(previewGameObject);
        }
        if(GUILayout.Button("Reset"))
        {
            ((AudioEvent)target).Reset();
        }
        EditorGUI.EndDisabledGroup();
    }
}
