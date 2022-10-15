using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemDisplayObject itemManager;
    public int currentItem;
    public int stackSize;
    public bool hasItem;
    private int maxStackSize = 16;
    public bool slotFull;
    Image slotSprite;

    private void Start()
    {
        slotFull = false;
        hasItem = false;
        currentItem = 1000;
        slotSprite = GetComponent<Image>();
    }

    private void Update()
    {
        //Display Items
        switch (currentItem) 
        {
            case (int)ItemManager.ITEM_ID.WOOD:
                slotSprite.sprite = itemManager.sprites[(int)ItemManager.ITEM_ID.WOOD];
                break;
            case (int)ItemManager.ITEM_ID.BOW:
                slotSprite.sprite = itemManager.sprites[(int)ItemManager.ITEM_ID.BOW];
                break;
        }

        //Stackable Items
        if (stackSize == maxStackSize) 
        {
            slotFull = true;
        }
    }

}
