using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryDisplay : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public GameObject SelectionPanel;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Gold;
    public ItemSlot _SelectedItemSlot;
    public ItemSlot SelectedItemSlot
    {
        get { return _SelectedItemSlot; }
        set
        {
            _SelectedItemSlot = value;
            SelectionPanel.SetActive(true);
            SelectionPanel.transform.position = value.transform.position;
        }
    }

    public void TrashSelectedItem()
    {
        if(SelectedItemSlot != null)
            FindObjectOfType<PlayerData>().PlayerInventory.Remove(SelectedItemSlot.Item);
        RefreshInventory();
    }

    private void OnEnable()
    {
        SelectionPanel.SetActive(false);
        _SelectedItemSlot = null;
        var PD = FindObjectOfType<PlayerData>();
        Gold.text = $"GOLD: {PD.Gold}";
        RefreshInventory();
    }

    private void RefreshInventory()
    {
        var PD = FindObjectOfType<PlayerData>();
        var PI = PD.PlayerInventory;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Count each unique item by ID
        Dictionary<int, int> itemCounts = new Dictionary<int, int>();
        foreach (ItemClass item in PI)
        {
            if (itemCounts.ContainsKey(item.ID))
            {
                itemCounts[item.ID]++;
            }
            else
            {
                itemCounts.Add(item.ID, 1);
            }
        }

        if (SelectedItemSlot == null)
        {
            SelectionPanel.SetActive(false);
        }

        // Instantiate ItemSlots
        foreach (var item in itemCounts)
        {
            ItemClass thisItem = PI.Find(x => x.ID == item.Key);
            // Instantiate your ItemSlot prefab here and set its properties
            // For example:
            var slot = Instantiate(itemSlotPrefab, transform);
            slot.GetComponent<ItemSlot>().Item = thisItem; // Assuming your ItemSlot class has an Item property
            slot.GetComponent<ItemSlot>().DescriptionRef = Description;
        }
    }
}
