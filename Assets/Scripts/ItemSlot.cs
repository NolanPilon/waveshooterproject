using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemDisplayObject itemManager;
    public int currentItem;
    public bool slotFull;
    Image slotSprite;

    private void Start()
    {
        slotFull = false;
        currentItem = 1000;
        slotSprite = GetComponent<Image>();
    }

    private void Update()
    {
        //Display Items
        switch (currentItem) 
        {
            case 0:
                slotSprite.sprite = itemManager.sprites[(int)ItemManager.ITEM_ID.RED_POTION];
                break;
            case 1:
                slotSprite.sprite = itemManager.sprites[(int)ItemManager.ITEM_ID.BLUE_POTION];
                break;
        }
    }
}
