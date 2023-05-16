using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButtonInteraction : MonoBehaviour
{
    
    public GameObject TutorialMainMenuHolder;
    public GameObject SetupMenuHolder;
    public GameObject CharacterMenuHolder;
    public GameObject MovementMenuHolder;
    public GameObject CombatMenuHolder;
    public GameObject InteractionsMenuHolder;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //This Function will hide all tutorial UI. 
    void HideAllTutorialUI()
    {
        TutorialMainMenuHolder.SetActive(false);
        SetupMenuHolder.SetActive(false);
        CharacterMenuHolder.SetActive(false);
        MovementMenuHolder.SetActive(false);
        CombatMenuHolder.SetActive(false);
        InteractionsMenuHolder.SetActive(false);
    }
    //When setup button from tutorial main menu is pressed
    public void SetupButton()
    {
        HideAllTutorialUI();
        SetupMenuHolder.SetActive(true);

    }
    public void CharacterButton()
    {
        HideAllTutorialUI();
        CharacterMenuHolder.SetActive(true);
    }
    public void MovementButton()
    {
        HideAllTutorialUI();
        MovementMenuHolder.SetActive(true);
    }
    public void CombatButton()
    {
        HideAllTutorialUI();
        CombatMenuHolder.SetActive(true);
    }
    public void InteractionsButton()
    {
        HideAllTutorialUI();
        InteractionsMenuHolder.SetActive(true);
    }
    public void HomeButton()
    {
        HideAllTutorialUI();
        TutorialMainMenuHolder.SetActive(true);

    }
    
    public void MainMenuBackButton()
    {
        SceneManager.LoadSceneAsync("Startup");
    }


}
