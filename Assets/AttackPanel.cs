using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AttackPanel : MonoBehaviour
{
    public GameObject SlotPrefab;
    MonsterAttack[] Attacks;

    public void OnEnable()
    {
        Attacks = FindObjectOfType<BattleManager>().PlayerData.Attacks;

        for (int i = 0; i < 4; i++)
        {
            var slot = Instantiate(SlotPrefab, this.transform);
            try
            {
                if (Attacks[i] != null)
                {
                    slot.GetComponentInChildren<TextMeshProUGUI>().text = Attacks[i].Name;
                    slot.GetComponent<AttackSlot>().Attack = Attacks[i];
                }
            }
            catch
            {
                
            }
        }
    }
}
