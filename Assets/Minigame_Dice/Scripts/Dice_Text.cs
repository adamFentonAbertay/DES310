using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dice_Text : MonoBehaviour
{
    public TextMeshProUGUI diceText;
    public TextMeshProUGUI rerollText;
    public static int diceNumber;
    public static int crossNumber;

    public TextMeshProUGUI diceText2;
    public TextMeshProUGUI rerollText2;
    public static int diceNumber2;
    public static int crossNumber2;

    public Dice d1;
    public Dice2 d2;
    // Start is called before the first frame update
    void Start()
    {
        diceText.GetComponent<TextMeshProUGUI>();
        diceText2.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        diceText.text = diceNumber.ToString();
        if (d1.reRoll >0)
        {
            rerollText.text = d1.reRoll.ToString();
        } else
        {
            rerollText.text = "None";
        }

        diceText2.text = diceNumber2.ToString();
        if (d2.reRoll > 0)
        {
            rerollText2.text = d2.reRoll.ToString();
        }
        else
        {
            rerollText2.text = "None";
        }

        //diceText.text = "666";
    }
}
