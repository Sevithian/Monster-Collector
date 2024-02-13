using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Gold;
    private void OnEnable()
    {
        var PD = FindObjectOfType<PlayerData>();
        var PI = PD.PlayerInventory;
        //Gold.text = $"GOLD: {PD.Gold}";
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
