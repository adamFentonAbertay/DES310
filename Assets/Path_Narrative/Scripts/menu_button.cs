using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu_button : MonoBehaviour
{
    public static bool menu_open;
    public Image background_image,bl1,bl2,bl3;
    public Button settingbut, backbut, extrabut;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menu_open)
        {
            settingbut.gameObject.SetActive(true);
            backbut.gameObject.SetActive(true);
            background_image.gameObject.SetActive(false);
            bl1.gameObject.SetActive(true);
            bl2.gameObject.SetActive(true);
            bl3.gameObject.SetActive(true);
            if (extrabut != null)
            {
                extrabut.gameObject.SetActive(true);
            }
        }
        else if (!menu_open)
        {
            settingbut.gameObject.SetActive(false);
            backbut.gameObject.SetActive(false);
            background_image.gameObject.SetActive(true);
            bl1.gameObject.SetActive(false);
            bl2.gameObject.SetActive(false);
            bl3.gameObject.SetActive(false);
            if (extrabut != null)
            {
                extrabut.gameObject.SetActive(false);
            }
        }
    }

    public void open()
    {
        if (!menu_open)
        {
            menu_open = true;
        } else if (menu_open)
        {
            menu_open = false;
        }
    }
    public void back()
    {
        Debug.Log("back");
        SceneManager.LoadSceneAsync("Startup");
        if (MusicDontDestroy.Instance != null)
        {
            MusicDontDestroy.Instance.gameObject.GetComponent<AudioSource>().Pause();
        }
    }
    public void setting()
    {
        Debug.Log("setting");
    }
}
