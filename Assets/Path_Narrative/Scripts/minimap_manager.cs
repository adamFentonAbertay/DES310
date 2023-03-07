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

    private bool map_show = false;

    // Start is called before the first frame update
    void Start()
    {

        Map_init();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (map_show)
        {
            bool[] mbutton_used = new bool[monster_Button.Length];
            bool[] cbutton_used = new bool[chance_Button.Length];

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
                    for(int j = 0; j < monster_Button.Length; j++)
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
    }

    void Map_init()
    {
        int[] tempMap = {4,0,2,0,1,4,
                         4,0,1,0,0,4,
                         4,0,0,1,0,4,
                         4,0,2,1,0,4,
                         4,0,0,0,2,4,
                         4,0,1,0,2,4,
                         4,0,2,1,0,4,
                         4,0,0,0,0,4};

        for (int i = 0; i < gridId.Length; i++)
        {
            gridId[i] = tempMap[i];
        }
        /*for (int i = 0; i < gridId.Length; i++)
        {
            int rand = Random.Range(0, 5);
            gridId[i] = rand;
        }*/

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
