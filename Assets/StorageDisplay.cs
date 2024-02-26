using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StorageDisplay : MonoBehaviour
{
    public GameObject monsterSlotPrefab;
    public GameObject SelectionPanel;
    public TextMeshProUGUI NameLabel;
    public TextMeshProUGUI ATKDEFLabel;
    public TextMeshProUGUI HPMPLabel;
    public TextMeshProUGUI AGIINTLabel;
    public MonsterSlot _SelectedMonsterSlot;
    public MonsterSlot SelectedMonsterSlot
    {
        get { return _SelectedMonsterSlot; }
        set
        {
            _SelectedMonsterSlot = value;
            SelectionPanel.SetActive(true);
            SelectionPanel.transform.position = value.transform.position;
        }
    }

    public void ReleaseMonster()
    {
        if (SelectedMonsterSlot != null)
            FindObjectOfType<PartyData>().StorageMonsters.Remove(SelectedMonsterSlot.Data);
        RefreshStorage();
    }

    private void OnEnable()
    {
        SelectionPanel.SetActive(false);
        _SelectedMonsterSlot = null;
        Invoke("RefreshStorage", 0.1f);
    }

    public void SwapMonsters()
    {
        try
        {
            var temp = FindObjectOfType<PartyData>().PrimaryMonster;
            FindObjectOfType<PartyData>().PrimaryMonster = SelectedMonsterSlot.Data;
            FindObjectOfType<PartyData>().StorageMonsters.Remove(SelectedMonsterSlot.Data);
            FindObjectOfType<PartyData>().StorageMonsters.Add(temp);
            RefreshStorage();
        }
        catch
        {
            Debug.Log("Swap error");    
        }
    }
    private void RefreshStorage()
    {
        SelectionPanel.SetActive(false);
        _SelectedMonsterSlot = null;
        var PD = FindObjectOfType<PartyData>();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        foreach(MonsterData monster in PD.StorageMonsters)
        {
            var mon = Instantiate(monsterSlotPrefab, this.transform);
            mon.GetComponent<MonsterSlot>().Data = monster;
        }
    }
}
