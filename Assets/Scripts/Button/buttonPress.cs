using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonPress : MonoBehaviour
{
    //public Image ThisButtonImage;

    public GameObject TitleScreenHolder;
    public GameObject mainMenuHolder;
    public GameObject settingsMenuHolder;
    public GameObject scenarioMenuHolder;
    public static bool first_start = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (!first_start)
        {
            TitleScreenHolder.SetActive(false);
        }
    }

    void hideAllUI()
    {
        mainMenuHolder.SetActive(false);
        settingsMenuHolder.SetActive(false);
        TitleScreenHolder.SetActive(false);
        scenarioMenuHolder.SetActive(false);
    }

    //Uses buttons On Clock - SendMessage to envoke
    public void minigameResponse()
    {
        Debug.Log("start game called");
        SceneManager.LoadSceneAsync("MinigameExample");
        
    }

    public void scenarioResponse()
    {
        hideAllUI();
        scenarioMenuHolder.SetActive(true);
        Debug.Log("scenario called");
        //SceneManager.LoadSceneAsync()
    }

    public void scenario1ButResponse()
    {
        Debug.Log("Scenario 1 called");
        SceneManager.LoadSceneAsync("Full_map");
    }

    public void menuResponse()
    {
        Debug.Log("menu called");
        SceneManager.LoadSceneAsync("Startup");
    }
    public void TutorialResponse()
    {
        Debug.Log("Tutorial!");
        SceneManager.LoadSceneAsync("Tutorial");
    }

    public void DiceResponse()
    {
        Debug.Log("dice game called");
        SceneManager.LoadSceneAsync("Dice");
    }
    public void MenuToSettingsResponse()
    {
        hideAllUI();
        settingsMenuHolder.SetActive(true);
        Debug.Log("settings called");
    }

    public void settingsToMenuResponse()
    {
        if (first_start)
        {
            first_start = false;
        }
        hideAllUI();
        mainMenuHolder.SetActive(true);
        Debug.Log("menu called");
    }


}
