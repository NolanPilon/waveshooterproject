using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public ItemSlot[] slotInformation;
    public enum ITEM_ID
    {
        WOOD = 0,
        BOW
    }


    public void pickupWood() 
    {
        for (int i = 0; i < slotInformation.Length; i++) 
        {
            if (!slotInformation[i].slotFull)
            {
                slotInformation[i].currentItem = 0;
                slotInformation[i].hasItem = true;
                slotInformation[i].stackSize++;
                return;
            }
        } 
    }
    public void pickupBow()
    {
        for (int i = 0; i < slotInformation.Length; i++)
        {
            if (!slotInformation[i].slotFull && !slotInformation[i].hasItem)
            {
                slotInformation[i].currentItem = 1;
                slotInformation[i].slotFull = true;
                slotInformation[i].hasItem = true;
                return;
            }
        }
    }
}
