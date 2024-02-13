using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public enum ItemType { Normal, Usable, Key }

[CreateAssetMenu(fileName = "Items", menuName = "New Item", order = 0)]
public class ItemClass : ScriptableObject
{
    public int ID;
    public string Name;
    public Sprite Icon;
    public ItemType Type;
    public int ItemCost;
    public ItemEffect Effect;
    public string Description;

    public void UseItem(MonsterData target)
    {
        if (Type == ItemType.Usable && Effect != null)
        {
            Effect.Execute(target); // Assumes ItemCost is the amount to use
        }
        else
        {
            Debug.Log(Name + " is not usable or has no effect.");
        }
    }
}

public abstract class ItemEffect : ScriptableObject
{
    public int RestoreAmount;
    public abstract void Execute(MonsterData target);
}
