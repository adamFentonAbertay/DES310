using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPageScript : MonoBehaviour
{
    public GameObject InventoryImage;
    public GameObject EncounterCardImage;
    public GameObject EnemyCardsImage;
    public GameObject BoardLayoutImage;
    public GameObject ZoneCardsImage;
    public GameObject ZoneCardsSetupImages;
    public GameObject ItemCardsImage;
    public GameObject EndSetupImages;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInventory()
    {
        if (InventoryImage.activeSelf)
        {
            InventoryImage.SetActive(false);
        }
        else
        {
            InventoryImage.SetActive(true);
        }
    }
    public void ToggleEncounterCard()
    {
        if (EncounterCardImage.activeSelf)
        {
            EncounterCardImage.SetActive(false);
        }
        else
        {
            EncounterCardImage.SetActive(true);
        }
    }

    public void ToggleEnemyCards()
    {
        if (EnemyCardsImage.activeSelf)
        {
            EnemyCardsImage.SetActive(false);
        }
        else
        {
            EnemyCardsImage.SetActive(true);
        }
    }
    public void ToggleBoardLayout()
    {
        if (BoardLayoutImage.activeSelf)
        {
            BoardLayoutImage.SetActive(false);
        }
        else
        {
            BoardLayoutImage.SetActive(true);
        }
    }
    public void ToggleZoneCards()
    {
        if (ZoneCardsImage.activeSelf)
        {
            ZoneCardsImage.SetActive(false);
        }
        else
        {
            ZoneCardsImage.SetActive(true);
        }
    }
    public void ToggleZoneCardsSetupImages()
    {
        if (ZoneCardsSetupImages.activeSelf)
        {
            ZoneCardsSetupImages.SetActive(false);
        }
        else
        {
            ZoneCardsSetupImages.SetActive(true);
        }
    }
    public void ToggleItemCardsImage()
    {
        if (ItemCardsImage.activeSelf)
        {
            ItemCardsImage.SetActive(false);
        }
        else
        {
            ItemCardsImage.SetActive(true);
        }
    }

    public void ToggleEndSetupImages()
    {
        if (EndSetupImages.activeSelf)
        {
            EndSetupImages.SetActive(false);
        }
        else
        {
            EndSetupImages.SetActive(true);
        }
    }
}
