using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    private ItemClass _item;
    public ItemClass Item
    {
        get { return _item; }
        set
        {
            _item = value;
            Initialize();
        }
    }
    public Image Icon;
    public TextMeshProUGUI Quantity;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI DescriptionRef;

    public void Initialize()
    {
        this.gameObject.name = Item.Name;
        Icon.sprite = Item.Icon;
        Quantity.text = FindObjectOfType<PlayerData>().PlayerInventory.FindAll(x => x.ID == Item.ID).Count.ToString();
        Name.text = Item.Name;
    }

    public void DisplayDescription()
    {
        DescriptionRef.text = Item.Description;
    }

    public void ResetDescription()
    {
        DescriptionRef.text = "Hover over an item to get a description of it.";
    }    

    public void SetInventorySelection()
    {
        FindObjectOfType<InventoryDisplay>().SelectedItemSlot = this;
    }
}
