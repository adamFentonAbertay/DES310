using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPageScript : MonoBehaviour
{
    public GameObject DiceRollImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDiceRollImage()
    {
        if (DiceRollImage.activeSelf)
        {
            DiceRollImage.SetActive(false);
        }
        else
        {
            DiceRollImage.SetActive(true);
        }
    }
}
