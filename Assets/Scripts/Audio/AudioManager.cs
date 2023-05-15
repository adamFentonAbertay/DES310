using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool musicEnable = true;
    public static bool narratorEnable = true;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public void userToggle(bool tog)
    {
        if (tog == true)
        {
            musicEnable = true;
           
        }
        else
        {
            musicEnable = false;
            
        }
    }

    public void userNarratorToggle(bool tog)
    {
        if (tog == true)
        {
            narratorEnable = true;

        }
        else
        {
            narratorEnable = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
