using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MonsterSpecies))]
public class MonsterSpeciesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Draw the default inspector

        MonsterSpecies monsterSpecies = (MonsterSpecies)target;

        // Calculate totals
        int baseTotal = TotalStats(monsterSpecies.BaseStats);
        int maxTotal = TotalStats(monsterSpecies.MaxStats);

        // Display totals
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Total Base Stats: " + baseTotal);
        EditorGUILayout.LabelField("Total Max Stats: " + maxTotal);
    }

    private int TotalStats(MonsterStats stats)
    {
        return stats.HP + stats.MP + stats.ATK + stats.DEF + stats.AGI + stats.INT;
    }
}
