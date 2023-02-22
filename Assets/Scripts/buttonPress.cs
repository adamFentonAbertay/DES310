using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonPress : MonoBehaviour
{
    public Image ThisButtonImage;

    public GameObject AIPlayerHolder;
    public GameObject mainMenuHolder;
    public GameObject settingsMenuHolder;
    public GameObject scenarioMenuHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //deprecated

        //foreach (Touch touch in Input.touches)
        //{
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        // Construct a ray from the current touch coordinates
        //        Debug.Log("touch");
        //    }
        //}
    }

    void hideAllUI()
    {
        mainMenuHolder.SetActive(false);
        settingsMenuHolder.SetActive(false);
        AIPlayerHolder.SetActive(false);
        scenarioMenuHolder.SetActive(false);
    }

    //Uses buttons On Clock - SendMessage to envoke
    void minigameResponse()
    {
        Debug.Log("start game called");
        SceneManager.LoadSceneAsync("MinigameExample");
        
    }

    void scenarioResponse()
    {
        hideAllUI();
        scenarioMenuHolder.SetActive(true);
        Debug.Log("scenario called");
        //SceneManager.LoadSceneAsync()
    }

    void menuResponse()
    {
        Debug.Log("menu called");
        SceneManager.LoadSceneAsync("Startup");
    }
    void ARResponse()
    {
        Debug.Log("how to play called");
        SceneManager.LoadSceneAsync("BlankAR");
    }

    void DiceResponse()
    {
        Debug.Log("dice game called");
        SceneManager.LoadSceneAsync("Dice");
    }
    void MenuToSettingsResponse()
    {
        hideAllUI();
        settingsMenuHolder.SetActive(true);
        Debug.Log("settings called");
    }

    void settingsToMenuResponse()
    {
        hideAllUI();
        mainMenuHolder.SetActive(true);    
        ThisButtonImage.color = Color.cyan;
        Debug.Log("menu called");
    }


}
