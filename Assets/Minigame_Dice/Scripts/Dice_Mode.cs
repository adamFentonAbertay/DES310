using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Dice_Mode : MonoBehaviour
{
    public Dice d1;
    public Dice2 d2;

    public Button mb1,mb2,mb3; // modebutton

    public static int dice_mode = 0; //0-move , 1-pvp , 2-pve
    public bool dice1_spawn = true;
    public bool dice2_spawn = false;
    public bool mode_button = false; //check if the mode button is pressed


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mode_button)
        {
            mb1.gameObject.SetActive(true); 
            mb2.gameObject.SetActive(true);
            mb3.gameObject.SetActive(true);
        } else if(!mode_button){
            mb1.gameObject.SetActive(false);
            mb2.gameObject.SetActive(false);
            mb3.gameObject.SetActive(false);
        }

        switch (dice_mode){ 
            case 0:
                if (d2.gameObject.activeSelf)
                {
                    d2.gameObject.SetActive(true);
                }
                break;
            case 1:
                if (!d2.gameObject.activeSelf)
                {
                    d2.gameObject.SetActive(true);
                }
                break;
            case 2:
                if (!d2.gameObject.activeSelf)
                {
                    d2.gameObject.SetActive(true);
                }
                break;
        }
    }

    public void Mode_button_pressed()
    {
        
        if (mode_button)
        {
            mode_button = false;
        } else if (!mode_button)
        {
            mode_button = true;
        }
    }
    public void Mode_switch(int mode)
    {
        dice_mode = mode;   
    }
    public int Get_dice_mode()
    {
        Debug.Log("dice mode:" +dice_mode);
        return dice_mode;
    }
}
