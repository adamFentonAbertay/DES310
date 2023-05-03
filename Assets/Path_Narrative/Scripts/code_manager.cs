using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class code_manager : MonoBehaviour
{
    public static int[] code = new int[4];
    public Image[] code_image;
    public Sprite[] code_Sprite;
    public Button Go_button;
    public static int map_codeid;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        code_update();
    }

    public void code_enter(int but_numb)
    {
        for (int i = 0; i < code.Length; i++)
        {
            if (code[i] == 0)
            {
                code[i] = but_numb;
                break;
            }
        }
    }

    public void code_cancel()
    {
        for (int i = code.Length - 1; i >= 0; i--)
        {
            if (code[i] != 0)
            {
                code[i] = 0;
                break;
            }
        }
    }

    public void code_update()
    {
        for (int i = 0; i < code_image.Length; i++)
        {
            switch (code[i])
            {
                case 0:
                    code_image[i].sprite = code_Sprite[4];
                    break;
                case 1:
                    code_image[i].sprite = code_Sprite[0];
                    break;
                case 2:
                    code_image[i].sprite = code_Sprite[1];
                    break;
                case 3:
                    code_image[i].sprite = code_Sprite[2];
                    break;
                case 4:
                    code_image[i].sprite = code_Sprite[3];
                    break;
            }
        }

        if (code[3] != 0)
        {
            Go_button.gameObject.SetActive(true);
        }
        else
        {
            Go_button.gameObject.SetActive(false);
        }
    }


}