using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class StorageDisplay : MonoBehaviour
{
    public GameObject monsterSlotPrefab;
    public GameObject SelectionPanel;
    public GameObject StorageGrid;
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
            NameLabel.gameObject.SetActive(true);
            ATKDEFLabel.gameObject.SetActive(true);
            HPMPLabel.gameObject.SetActive(true);
            AGIINTLabel.gameObject.SetActive(true);
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
        NameLabel.gameObject.SetActive(false);
        ATKDEFLabel.gameObject.SetActive(false);
        HPMPLabel.gameObject.SetActive(false);
        AGIINTLabel.gameObject.SetActive(false);
        _SelectedMonsterSlot = null;
        RefreshStorage();
    }

    public void SwapMonsters()
    {
        var PD = FindObjectOfType<PartyData>();
        Debug.Log($"Swapping {PD.PrimaryMonster.Name} with {SelectedMonsterSlot.Data.Name}");
        try
        {
            var temp = FindObjectOfType<PartyData>().PrimaryMonster;
            FindObjectOfType<PartyData>().PrimaryMonster = SelectedMonsterSlot.Data;
            FindObjectOfType<PartyData>().StorageMonsters.Remove(SelectedMonsterSlot.Data);
            FindObjectOfType<PartyData>().StorageMonsters.Add(temp);
            NameLabel.gameObject.SetActive(false);
            ATKDEFLabel.gameObject.SetActive(false);
            HPMPLabel.gameObject.SetActive(false);
            AGIINTLabel.gameObject.SetActive(false);
            RefreshStorage();
        }
        catch (Exception e)
        {
            Debug.Log($"Swap error: {e}");
        }
    }

    private void RefreshStorage()
    {
        Debug.Log("Refreshing Storage");
        SelectionPanel.SetActive(false);
        _SelectedMonsterSlot = null;
        var PD = FindObjectOfType<PartyData>();
        foreach (Transform child in StorageGrid.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(MonsterData monster in PD.StorageMonsters)
        {
            var mon = Instantiate(monsterSlotPrefab, StorageGrid.transform);
            mon.GetComponent<MonsterSlot>().Data = monster;
        }
    }
}
