using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class SavedDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Draw the default inspector

        GameManager gameManager = (GameManager)target;

        if (gameManager.SavedWorldData != null)
        {
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Saved World Data", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            EditorGUILayout.LabelField("Player Position", gameManager.SavedWorldData.PlayerPos.ToString());
            EditorGUILayout.LabelField("World ID", gameManager.SavedWorldData.WorldID.ToString());

            EditorGUI.indentLevel--;
        }
        else
        {
            EditorGUILayout.HelpBox("SavedWorldData is currently null.", MessageType.Info);
        }
    }
}
