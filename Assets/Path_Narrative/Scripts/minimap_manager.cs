using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class minimap_manager : MonoBehaviour
{
    public Image[] grid;
    public Sprite[] gridSprite;
    public static int[] gridId = new int[48];

    public Button unknow_button;

    public GameObject Canvas;
    public GameObject monster_button;
    //public Button mb1,mb2,mb3,mb4,mb5,mb6,mb7,mb8,mb9,mb10;
    private bool map_show = false;

    // Start is called before the first frame update
    void Start()
    {

        Map_init();

      GameObject mb = Instantiate(monster_button, grid[2].transform.position, Quaternion.identity) as GameObject;
                 mb.transform.SetParent(Canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (map_show)
        {
            for (int i = 0; i < gridId.Length; i++)
            {
                grid[i].sprite = gridSprite[gridId[i]];
            }
        }

        //grid[2].transform.position = grid[3].transform.position;
    }

    void Map_init()
    {
        int[] tempMap = {4,0,2,0,0,4,
                         4,0,0,0,0,4,
                         4,0,0,1,0,4,
                         4,0,0,0,0,4,
                         4,0,0,0,0,4,
                         4,0,0,0,0,4,
                         4,0,0,0,0,4,
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
