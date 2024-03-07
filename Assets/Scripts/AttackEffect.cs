using UnityEngine;

public enum EffectType { None, Buff, Debuff, Heal, Status }
public enum EffectStat { None, ATK, DEF, AGI, INT }
public enum EffectStatus {None, Slow, Stun, Poison }

[CreateAssetMenu(fileName = "New Attack Effect", menuName = "New Attack Effect", order = 1)]
public class AttackEffect : ScriptableObject
{
    public EffectType Type;
    public EffectStat Stat;
    public EffectStatus Status;
    public int MinTurnDuration;
    public int MaxTurnDuration;
    public int MultiplyStatValue;
}