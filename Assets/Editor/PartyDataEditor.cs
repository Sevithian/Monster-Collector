using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PartyData))]
public class PartyDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Draw the default inspector

        PartyData partyData = (PartyData)target;

        if (partyData.PrimaryMonster != null)
        {
            EditorGUILayout.LabelField("Primary Monster Data", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            // Display properties of PrimaryMonster
            EditorGUILayout.LabelField("Name", partyData.PrimaryMonster.Name);
            EditorGUILayout.LabelField("Level", partyData.PrimaryMonster.Level.ToString());
            EditorGUILayout.LabelField("Species", partyData.PrimaryMonster.Species.ToString());
            EditorGUILayout.LabelField("CurrentHP", partyData.PrimaryMonster.CurrentHP.ToString());
            EditorGUILayout.LabelField("CurrentMP", partyData.PrimaryMonster.CurrentMP.ToString());
            EditorGUILayout.LabelField("Max HP:", partyData.PrimaryMonster.CurrentStats.HP.ToString());
            EditorGUILayout.LabelField("Max MP:", partyData.PrimaryMonster.CurrentStats.MP.ToString());
            EditorGUILayout.LabelField("ATK:", partyData.PrimaryMonster.CurrentStats.ATK.ToString());
            EditorGUILayout.LabelField("DEF:", partyData.PrimaryMonster.CurrentStats.DEF.ToString());
            EditorGUILayout.LabelField("AGI:", partyData.PrimaryMonster.CurrentStats.AGI.ToString());
            EditorGUILayout.LabelField("INT:", partyData.PrimaryMonster.CurrentStats.INT.ToString());
            // Add more fields as needed

            EditorGUI.indentLevel--;
        }
    }
}