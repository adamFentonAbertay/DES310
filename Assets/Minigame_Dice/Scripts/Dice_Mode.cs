using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Dice_Mode : MonoBehaviour
{
    public Dice d1;
    public Dice2 d2;

    public Button mb1,mb2,mb3; // modebutton

    public static int dice_mode = 1; //0-pve , 1-move , 2-pvp
    public bool dice1_spawn = true;
    public bool dice2_spawn = false;
    public bool mode_button = false; //check if the mode button is pressed

    public bool both_landed = false;

    public static int[,] history_number = new int[5,3];
 


    // Start is called before the first frame update
    void Start()
    {
        
    }

     void FixedUpdate()
    {
        if (Dice.diceland&&Dice2.diceland)
        {
            both_landed = true;
        }
        else
        {
            both_landed = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        dice_mode_update();

    }

    public void Roll_both(int mode)
    {
        switch(mode)
        {
            case 0:
                if (both_landed)
                {
                    dice_mode = 0;
                    dice_mode_update();
                    Debug.Log("pve roll!");
                    d1.Roll();
                    d2.Roll();
                }
                break;
            case 1:
                if (both_landed)
                {
                    dice_mode = 1;
                    dice_mode_update();
                    Debug.Log("Move roll!");
                    d1.Roll();
                    d2.Roll();
                }
                break;
            case 2:
                if (Dice.diceland)
                {
                    dice_mode = 2;
                    Debug.Log("PVP roll!");
                    d1.Roll();
                }
                break;
        }
    }

    public void history_update(int mode)
    {
        switch (mode)
        {


        }

        }
    public void dice_mode_update()
    {
        switch (dice_mode)
        {
            //0-pve 1-move 2-pvp
            case 0:

                if (!d2.gameObject.activeSelf)
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
                if (d2.gameObject.activeSelf)
                {
                    d2.gameObject.SetActive(false);
                }
                break;
        }
    }
}
