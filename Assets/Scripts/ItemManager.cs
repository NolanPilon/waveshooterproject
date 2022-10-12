using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public ItemSlot[] slotInformation;
    public enum ITEM_ID
    {
        RED_POTION = 0,
        BLUE_POTION,
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check Ground Item Tag
        switch (collision.tag) 
        {
            case "RedPot":
                pickupItem(collision, (int)ITEM_ID.RED_POTION);
                break;
            case "BluePot":
                pickupItem(collision, (int)ITEM_ID.BLUE_POTION);
                break;
        } 
    }

    //Pickup Ground Items
    void pickupItem(Collider2D groundItem, int itemID) 
    {
        for (int i = 0; i < slotInformation.Length; i++)
        {
            if (!slotInformation[i].slotFull)
            {
                slotInformation[i].slotFull = true;
                slotInformation[i].currentItem = itemID;
                Destroy(groundItem.gameObject);
                return;
            }
        }
    }
}
