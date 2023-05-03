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

    public Image[] his_image = new Image[5];
    public Sprite[] his_sprite = new Sprite[4];
    public TextMeshProUGUI[] his_text = new TextMeshProUGUI[5];
    public bool his_opened = false;
    public GameObject history;

    public static int dice_mode = 1; //0-pve , 1-move , 2-pvp
    public bool dice1_spawn = true;
    public bool dice2_spawn = false;
    public bool mode_button = false; //check if the mode button is pressed

    public bool both_landed = false;
    public static bool first_roll = true;

    public static int[,] history_number = new int[5,3];
 


    // Start is called before the first frame update
    void Start()
    {
        if (first_roll)
        {
            for (int i = 0; i < history_number.GetLength(0); i++)
            {
                history_number[i, 0] = 3;
            }
        }
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
        history_update();
    }

    public void Roll_both(int mode)
    {
        switch(mode)
        {
            case 0:
                if (both_landed)
                {
                    history_add();
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
                    history_add();
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
                    history_add();
                    dice_mode = 2;
                    Debug.Log("PVP roll!");
                    d1.Roll();
                }
                break;
        }
    }

    public void history_add()
    {
        if (!first_roll)
        {
            //move down
            for (int i = history_number.GetLength(0) - 1; i > 0; i--)
            {
                history_number[i, 0] = history_number[i - 1, 0];
                history_number[i, 1] = history_number[i - 1, 1];
                history_number[i, 2] = history_number[i - 1, 2];
            }
            //add first roll
            history_number[0, 0] = dice_mode;
            if (dice_mode == 0)
            {
                history_number[0, 1] = Floor_Check.d1_number + Floor_Check.d2_number;
                history_number[0, 2] = Floor_Check.cross_number + Floor_Check.cross_number2;
            }
            else
            {
                history_number[0, 1] = Floor_Check.d1_number;
                history_number[0, 2] = Floor_Check.d2_number;
            }
        }
        else
        {

            first_roll = false;
        }

     }

    public void history_update()
    {

        for (int i = 0; i < his_text.Length; i++)
        {
            his_image[i].sprite = his_sprite[history_number[i, 0]];

            if (history_number[i, 0] == 0)
            {
                his_text[i].text = " O:"+history_number[i, 1].ToString() + ":" + " X:"+history_number[i, 2].ToString();
            }
            if (history_number[i, 0] == 1)
            {
                his_text[i].text = history_number[i, 1].ToString() + "&" + history_number[i, 2].ToString();
            }
            if (history_number[i, 0] == 2)
            {
                his_text[i].text = history_number[i, 1].ToString();
            }
            if (history_number[i, 0] == 3)
            {
                his_text[i].text = "?";
            }
        }
    }

    public void history_switch()
    {
        if (!his_opened)
        {
            history.gameObject.SetActive(true);
            his_opened = true;
        }
        else
        {
            history.gameObject.SetActive(false);
            his_opened = false;
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
