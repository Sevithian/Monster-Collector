using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSlot : MonoBehaviour
{
    public MonsterData Data;

    public void SetInventorySelection()
    {
        FindObjectOfType<StorageDisplay>().SelectedMonsterSlot = this;
        FindObjectOfType<StorageDisplay>().NameLabel.text = Data.Name;
        FindObjectOfType<StorageDisplay>().HPMPLabel.text = $"HP - {Data.CurrentStats.HP}\nMP - {Data.CurrentStats.MP}";
        FindObjectOfType<StorageDisplay>().ATKDEFLabel.text = $"ATK - {Data.CurrentStats.ATK}\nDEF - {Data.CurrentStats.DEF}";
        FindObjectOfType<StorageDisplay>().AGIINTLabel.text = $"AGI - {Data.CurrentStats.AGI}\nINT - {Data.CurrentStats.INT}";
    }
}
