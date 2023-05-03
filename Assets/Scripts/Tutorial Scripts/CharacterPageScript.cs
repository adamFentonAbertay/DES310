using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPageScript : MonoBehaviour
{
    public GameObject AllCharacterButtons;
    public GameObject BackButton;
    public GameObject HomeButton;
    public GameObject ArcherPage;
    public GameObject BeastMasterPage;
    public GameObject BishopPage;
    public GameObject CartographerPage;
    public GameObject LuckMasterPage;
    public GameObject MagePage;
    public GameObject RoguePage;
    public GameObject SpaceCatPage;
    public GameObject WarriorPage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HideAllCharacterPages()
    {
        ArcherPage.SetActive(false);
        BeastMasterPage.SetActive(false);
        BishopPage.SetActive(false);
        CartographerPage.SetActive(false);
        LuckMasterPage.SetActive(false);
        MagePage.SetActive(false);
        RoguePage.SetActive(false);
        SpaceCatPage.SetActive(false);
        WarriorPage.SetActive(false);
        
    }
    public void HideCharacterButtons()
    {
        AllCharacterButtons.SetActive(false);
        BackButton.SetActive(false);
        HomeButton.SetActive(true);

    }
    public void CharacterHome()
    {
        HideAllCharacterPages();
        AllCharacterButtons.SetActive(true);
        BackButton.SetActive(true);
        HomeButton.SetActive(false);

    }

    public void ArcherButton()
    {
        HideCharacterButtons();
        ArcherPage.SetActive(true);
    }

    public void BeastMasterButton()
    {
        HideCharacterButtons();
        BeastMasterPage.SetActive(true);
    }
    public void BishopButton()
    {
        HideCharacterButtons();
        BishopPage.SetActive(true);
    }
    public void CartographerButton()
    {
        HideCharacterButtons();
        CartographerPage.SetActive(true);
    }
    public void MageButton()
    {
        HideCharacterButtons();
        MagePage.SetActive(true);
    }
    public void LuckMasterButton()
    {
        HideCharacterButtons();
        LuckMasterPage.SetActive(true);
    }
    public void RogueButton()
    {
        HideCharacterButtons();
        RoguePage.SetActive(true);
    }
    public void SpaceCatButton()
    {
        HideCharacterButtons();
        SpaceCatPage.SetActive(true);
    }
    public void WarriorButton()
    {
        HideCharacterButtons();
        WarriorPage.SetActive(true);
    }

}
