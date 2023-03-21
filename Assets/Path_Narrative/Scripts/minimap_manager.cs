using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;


public class minimap_manager : MonoBehaviour
{
    public Image[] grid;
    public Sprite[] gridSprite;
    public static int[] gridId = new int[48];

    public Button unknow_button;
    public Button[] monster_Button;
    public Button[] chance_Button;
    public GameObject NarratorSceneDialogue;

    public static List<string> onLoadMessages;
    public Image image;
    public static int map_type =0;
    private bool map_show = false;

    // Start is called before the first frame update
    void Start()
    {
       /* int[] tempMap2 = {        4,0,2,0,1,4,4,4,
                                  4,0,0,4,4,0,0,4,
                                  4,4,4,0,2,1,0,4,
                                  4,0,0,0,2,4,4,4,
                                  4,0,2,4,4,0,2,4,
                                  4,4,4,0,0,0,0,4};



        for (int i = 0; i < minimap_manager.gridId.Length; i++)
        {
            minimap_manager.gridId[i] = tempMap2[i];
        }*/
        Map_init();

        
    }

    // Update is called once per frame
    void Update()
    {


    }

    void Map_init()
    {


        bool[] mbutton_used = new bool[monster_Button.Length];
        bool[] cbutton_used = new bool[chance_Button.Length];

        NarratorSceneDialogue.GetComponent<DialogueManager>().dialoguesScenarios = onLoadMessages;
        NarratorSceneDialogue.GetComponent<DialogueManager>().resumeDialogue();



        if (map_type == 1)
        {
            int[] rotmap =
{
           gridId[40],gridId[32],gridId[24],gridId[16],gridId[8],gridId[0],
           gridId[41],gridId[33],gridId[25],gridId[17],gridId[9],gridId[1],
           gridId[42],gridId[34],gridId[26],gridId[18],gridId[10],gridId[2],
           gridId[43],gridId[35],gridId[27],gridId[19],gridId[11],gridId[3],
           gridId[44],gridId[36],gridId[28],gridId[20],gridId[12],gridId[4],
           gridId[45],gridId[37],gridId[29],gridId[21],gridId[13],gridId[5],
           gridId[46],gridId[38],gridId[30],gridId[22],gridId[14],gridId[6],
           gridId[47],gridId[39],gridId[31],gridId[23],gridId[15],gridId[7]
        };
            for (int i = 0; i < gridId.Length; i++)
            {
                gridId[i] = rotmap[i];
            }

            image.gameObject.transform.Rotate(0, 0, 90);
            for (int i = 0; i < gridId.Length; i++)
            {
                grid[i].gameObject.transform.Rotate(0, 0, -90);
            }
            for (int i = 0; i < monster_Button.Length; i++)
            {
                monster_Button[i].gameObject.transform.Rotate(0, 0, -90);
            }
            for (int i = 0; i < chance_Button.Length; i++)
            {
                chance_Button[i].gameObject.transform.Rotate(0, 0, -90);
            }
        }


        for (int i = 0; i < gridId.Length; i++)
        {
            grid[i].sprite = gridSprite[gridId[i]];

            if (gridId[i] == 1)
            {
                for (int j = 0; j < monster_Button.Length; j++)
                {
                    if (!cbutton_used[j])
                    {
                        cbutton_used[j] = true;
                        chance_Button[j].transform.position = grid[i].transform.position;
         
                        break;
                    }
                }
            }
            if (gridId[i] == 2)
            {
                for (int j = 0; j < monster_Button.Length; j++)
                {
                    if (!mbutton_used[j])
                    {
                        mbutton_used[j] = true;
                        monster_Button[j].transform.position = grid[i].transform.position;
                        break;
                    }
                }
            }
        }
    }

    public void view_map()
    {
        if (!map_show)
        {
            map_show = true;
            unknow_button.gameObject.SetActive(false);
        }
        else if (map_show)
        {
            map_show = false;
            unknow_button.gameObject.SetActive(true);
        }
    }

    public void monster_click()
    {
        if (map_show)
        {
            map_show = false;
            unknow_button.gameObject.SetActive(true);
        }
    }
}
