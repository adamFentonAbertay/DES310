using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Floor_Check : MonoBehaviour
{
    Vector3 diceVelocity;
    Vector3 dice2Velocity;
    public static int d1_number, cross_number;
    public static int d2_number, cross_number2;

    public TextMeshProUGUI d1_text;
    public TextMeshProUGUI d2_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Dice_Mode.dice_mode == 0)
        {
            d1_text.text = ("O:"+ (d1_number + d2_number).ToString());
            d2_text.text = ("X:"+(cross_number2+cross_number).ToString());
        }

            if (Dice_Mode.dice_mode == 1)
        {
            d1_text.text = d1_number.ToString();
            d2_text.text = d2_number.ToString();
        }

        if (Dice_Mode.dice_mode == 2)
        {
            d1_text.text = d1_number.ToString();
            d2_text.text = "?";
        }
    }

    private void FixedUpdate()
    {
        diceVelocity = Dice.diceVelocity;
        dice2Velocity = Dice2.dice2Velocity;
    }

    private void OnTriggerStay(Collider other)
    {
         if(diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            switch (other.gameObject.name)
            {
                case "side1":
                    Debug.Log("dice roll : 4");
                    d1_number = 4;
                    cross_number = 1;
                    break;
                case "side2":
                    Debug.Log("dice roll : 2");
                    d1_number = 2;
                    cross_number = 3;
                    break;
                case "side3":
                    Debug.Log("dice roll : 3");
                    d1_number = 3;
                    cross_number = 2;
                    break;
                case "side4":
                    Debug.Log("dice roll : 3");
                    d1_number = 3;
                    cross_number = 2;
                    break;
                case "side5":
                    Debug.Log("dice roll : 2");
                    d1_number = 2;
                    cross_number = 3;
                    break;
                case "side6":
                    Debug.Log("dice roll : 1");
                    d1_number = 1;
                    cross_number = 4;
                    break;
            }
        }

        if (dice2Velocity.x == 0f && dice2Velocity.y == 0f && dice2Velocity.z == 0f)
        {
            switch (other.gameObject.name)
            {
                case "side1_2":
                    Debug.Log("dice2 roll : 4");
                    d2_number = 4;
                    cross_number2 = 1;
                    break;
                case "side2_2":
                    Debug.Log("dice2 roll : 2");
                    d2_number = 2;
                    cross_number2 = 3;
                    break;
                case "side3_2":
                    Debug.Log("dice2 roll : 3");
                    d2_number = 3;
                    cross_number2 = 2;
                    break;
                case "side4_2":
                    Debug.Log("dice2 roll : 3");
                    d2_number = 3;
                    cross_number2 = 2;
                    break;
                case "side5_2":
                    Debug.Log("dice2 roll : 2");
                    d2_number = 2;
                    cross_number2 = 3;
                    break;
                case "side6_2":
                    Debug.Log("dice2 roll : 1");
                    d2_number = 1;
                    cross_number2 = 4;
                    break;
            }
        }
    }


}
