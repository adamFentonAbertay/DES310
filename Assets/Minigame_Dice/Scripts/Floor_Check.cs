using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

public class Floor_Check : MonoBehaviour
{
    Vector3 diceVelocity;
    Vector3 dice2Velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
                    Debug.Log("dice roll : 2");
                    Dice_Text.diceNumber = 2;
                    Dice_Text.crossNumber = 3;
                    break;
                case "side2":
                    Debug.Log("dice roll : 3");
                    Dice_Text.diceNumber = 3;
                    Dice_Text.crossNumber = 2;
                    break;
                case "side3":
                    Debug.Log("dice roll : 4");
                    Dice_Text.diceNumber = 4;
                    Dice_Text.crossNumber = 1;
                    break;
                case "side4":
                    Debug.Log("dice roll : 3");
                    Dice_Text.diceNumber = 3;
                    Dice_Text.crossNumber = 2;
                    break;
                case "side5":
                    Debug.Log("dice roll : 2");
                    Dice_Text.diceNumber = 2;
                    Dice_Text.crossNumber = 3;
                    break;
                case "side6":
                    Debug.Log("dice roll : 1");
                    Dice_Text.diceNumber = 1;
                    Dice_Text.crossNumber = 4;
                    break;
            }
        }

        if (dice2Velocity.x == 0f && dice2Velocity.y == 0f && dice2Velocity.z == 0f)
        {
            switch (other.gameObject.name)
            {
                case "side1_2":
                    Debug.Log("dice roll : 2");
                    Dice_Text.diceNumber2 = 2;
                    Dice_Text.crossNumber2 = 3;
                    break;
                case "side2_2":
                    Debug.Log("dice roll : 3");
                    Dice_Text.diceNumber2 = 3;
                    Dice_Text.crossNumber2 = 2;
                    break;
                case "side3_2":
                    Debug.Log("dice roll : 4");
                    Dice_Text.diceNumber2 = 4;
                    Dice_Text.crossNumber2 = 1;
                    break;
                case "side4_2":
                    Debug.Log("dice roll : 3");
                    Dice_Text.diceNumber2 = 3;
                    Dice_Text.crossNumber2 = 2;
                    break;
                case "side5_2":
                    Debug.Log("dice roll : 2");
                    Dice_Text.diceNumber2 = 2;
                    Dice_Text.crossNumber2 = 3;
                    break;
                case "side6_2":
                    Debug.Log("dice roll : 1");
                    Dice_Text.diceNumber2 = 1;
                    Dice_Text.crossNumber2 = 4;
                    break;
            }
        }
    }


}
