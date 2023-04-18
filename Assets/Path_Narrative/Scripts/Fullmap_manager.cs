using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Fullmap_manager : MonoBehaviour
{
    Vector3 touchStart;
    Vector3 dir;

    public Button[] map_Button;
    public Sprite[] map_Image;
    private int[] map_id = new int[7];
    public static bool[] map_vivwed = new bool[7];
    public static bool[] map_crashed = new bool[7];
    public static int  turn_timer = 70;

    //background
    public Image background_image;
    public Sprite[] background_sprite;
    private int background_id;

    // Start is called before the first frame update
    void Start()
    {
        map_id[0] = 2;
        map_id[3] = 2;
        map_id[6] = 2;

        map_id[1] = 1;
        map_id[2] = 1;
        map_id[4] = 1;
        map_id[5] = 1;

        backgroundchange();
        //turn_timer = 70;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //Debug.Log("touch!!");
        }
        if (Input.GetMouseButton(0))
        {
            dir = touchStart - Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Camera.main.transform.position += dir;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel")*2);


        board_check();
    }
    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, 1.0f, 40.0f);
    }

    public void SwitchMap(int mapid)
    {
        if (!map_vivwed[mapid])
        {
            map_vivwed[mapid] = true;
        }
        LoadMap(map_id[mapid]);
        //minimap_manager.turn_timer = turn_timer;
        SceneManager.LoadScene("mini_map");
    }

    public void LoadMap(int mapid )
    {
        switch (mapid)
        {
            case 1:

                minimap_manager.map_type = 0;
                minimap_manager.background_id = 0;

                int[] tempMap = {4,0,2,0,1,4,
                                 4,0,1,0,0,4,
                                 4,0,0,1,0,4,
                                 4,0,2,1,0,4,
                                 4,0,0,0,2,4,
                                 4,0,1,0,2,4,
                                 4,0,2,1,0,4,
                                 4,0,0,0,0,4};

                

                for (int i = 0; i < minimap_manager.gridId.Length; i++)
                {
                    minimap_manager.gridId[i] = tempMap[i];
                }
                break;
            case 2:

                minimap_manager.map_type = 1;
                minimap_manager.background_id = 1;

                int[] tempMap2 = {4,0,0,0,0,0,0,4,
                                  4,1,0,0,0,0,2,4,
                                  4,0,0,0,0,0,0,4,
                                  4,0,0,0,0,0,0,4,
                                  4,0,0,0,0,0,4,4,
                                  4,0,0,0,0,0,0,4};



                for (int i = 0; i < minimap_manager.gridId.Length; i++)
                {
                    minimap_manager.gridId[i] = tempMap2[i];
                }

                break;
        }
    }
    void backgroundchange()
    {

        background_image.GetComponent<Image>().sprite = background_sprite[background_id];
    }

    void board_check()
    {
        for (int i = 0; i < map_id.Length; i++)
        {
            if (map_vivwed[i])
            {
                map_Button[i].GetComponent<Image>().sprite = map_Image[1];
            }
            else
            {
                map_Button[i].GetComponent<Image>().sprite = map_Image[0];
            }
        }

        for (int i = 0; i < map_crashed.Length; i++)
        {
            if (map_crashed[i])
            {
               // map_Button[i].enabled = false;
                map_Button[i].GetComponent<Image>().sprite = map_Image[2];
            }
        }
    }

    public void turn_end()
    {
        if (!Time_button.backward)
        {
            if (turn_timer > 0)
            {
                turn_timer--;
                Debug.Log("timer :" + turn_timer);
            }

            if (turn_timer <= 60)
            {
                map_crashed[0] = true;
                Debug.Log("map 0" + map_crashed[0]);
            }

            if (turn_timer <= 50)
            {
                map_crashed[1] = true;
                Debug.Log("map 1" + map_crashed[1]);
            }

            if (turn_timer <= 40)
            {
                map_crashed[2] = true;
                Debug.Log("map 2" + map_crashed[2]);
            }
        }
        else if (Time_button.backward)
        {
            if (turn_timer < 70)
            {
                turn_timer++;
                Debug.Log("timer :" + turn_timer);
            }

            if (turn_timer >= 60)
            {
                map_crashed[0] = false;
                Debug.Log("map 0" + map_crashed[0]);
            }

            if (turn_timer >= 50)
            {
                map_crashed[1] = false;
                Debug.Log("map 0" + map_crashed[1]);
            }

            if (turn_timer >= 40)
            {
                map_crashed[2] = false;
                Debug.Log("map 2" + map_crashed[2]);
            }
        }

    }

}
