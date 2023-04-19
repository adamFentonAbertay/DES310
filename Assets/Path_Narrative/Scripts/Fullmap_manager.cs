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
    public GameObject[] messages;
    public GameObject[] monster_types;

    public static bool[] map_vivwed = new bool[7];
    public static bool[] map_crashed = new bool[7];
    public static int turn_timer = 70;

    private int[] map_id = new int[6];



    public Image background_image;
    public Sprite[] background_sprite;
    private int background_id;
    // Start is called before the first frame update
    void Start()
    {
       
        map_id[0] = 1;
        map_id[1] = 2;
        map_id[2] = 3;
        map_id[3] = 4;
        map_id[4] = 5;
        map_id[5] = 6;


        backgroundchange();

    }

    // Update is called once per frame
    void Update()
    {
        //delete?
        for (int i = 0; i < map_id.Length; i++)
        {
            if (map_vivwed[i])
            {
                map_Button[i].GetComponent<Image>().sprite = map_Image[0];
            }
            else
            {
                map_Button[i].GetComponent<Image>().sprite = map_Image[1];
            }
        }

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
        zoom(Input.GetAxis("Mouse ScrollWheel") * 2);


        board_check();

    }
    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, 1.0f, 40.0f);
    }

    public void SwitchMap(int mapid)
    {
        Debug.Log("LOADING MAP ID " + mapid);
        if (!map_vivwed[mapid])
        {
            map_vivwed[mapid] = true;
        }
        LoadMap(map_id[mapid]);
        SceneManager.LoadScene("mini_map");
    }






    void backgroundchange()
    {

        background_image.GetComponent<Image>().sprite = background_sprite[background_id];
    }

    void board_check()
    {
        //for (int i = 0; i < map_id.Length; i++)
        //{
        //    if (map_vivwed[i])
        //    {
        //        map_Button[i].GetComponent<Image>().sprite = map_Image[1];
        //    }
        //    else
        //    {
        //        map_Button[i].GetComponent<Image>().sprite = map_Image[0];
        //    }
        //}

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

        public void LoadMap(int mapid )
    {
        switch (mapid)
        {
            case 1:

                Debug.Log("CASE1");

                minimap_manager.map_type = 0;
                minimap_manager.background_id = 0;
                //0 - blank space
                //1 - question mark
                //2 - monster
                //3 - slow
                //4 - wall
                //5 - fence
                //6 - key
                //7 - key door
                //8 - cartographer floor
                //9 - shop
                //10 - crab boss

                int[] tempMap = {0,8,0,0,0,0,8,0,
                                  0,1,0,1,1,0,1,0,
                                  2,0,0,8,8,0,0,2,
                                  4,0,0,0,0,0,0,4,
                                  4,0,0,0,0,0,0,4,
                                  4,0,0,0,0,0,0,4};

                
                for (int i = 0; i < minimap_manager.gridId.Length; i++)
                {
                    minimap_manager.gridId[i] = tempMap[i];
                }

                int[] tempMonsterMap = { 0, 1, 2, 3, 4 };


                for (int i = 0; i < minimap_manager.monsterId.Length; i++)
                {
                    minimap_manager.monsterId[i] = tempMonsterMap[i];
                }

                int[] tempItemMap = { 0, 1, 2, 3, 4 };


                for (int i = 0; i < minimap_manager.itemId.Length; i++)
                {
                    minimap_manager.itemId[i] = tempItemMap[i];
                }


                minimap_manager.onLoadMessages = messages[0].GetComponent<TileTextHolder>().onLoadMessages;
                minimap_manager.onLoadAudios = messages[0].GetComponent<TileTextHolder>().audios;



                break;

            case 2:

                Debug.Log("CASE2");
                minimap_manager.map_type = 1;
                minimap_manager.background_id = 1;
                //0 - blank space
                //1 - question mark
                //2 - monster
                //3 - slow
                //4 - wall
                //5 - fence
                //6 - key
                //7 - key door
                //8 - cartographer floor
                //9 - shop

                int[] tempMap2 = {3,3,0,0,0,0,3,3,
                                  0,0,2,4,4,2,0,0,
                                  1,0,4,4,4,4,0,1,
                                  0,0,4,2,9,4,0,0,
                                  0,0,0,0,0,0,0,0,
                                  0,0,0,0,0,0,0,0};



                for (int i = 0; i < minimap_manager.gridId.Length; i++)
                {
                    minimap_manager.gridId[i] = tempMap2[i];
                }

                int[] tempMonsterMap2 = { 5, 6, 7, 8, 9 };


                for (int i = 0; i < minimap_manager.monsterId.Length; i++)
                {
                    minimap_manager.monsterId[i] = tempMonsterMap2[i];
                }

                int[] tempItemMap2 = {5 , 6, 7, 8, 9 };


                for (int i = 0; i < minimap_manager.itemId.Length; i++)
                {
                    minimap_manager.itemId[i] = tempItemMap2[i];
                }

                minimap_manager.onLoadMessages = messages[1].GetComponent<TileTextHolder>().onLoadMessages;
                minimap_manager.onLoadAudios = messages[1].GetComponent<TileTextHolder>().audios;
                break;



            case 3:

                minimap_manager.map_type = 0;
                minimap_manager.background_id = 0;



                //int[] tempMap3 = {0,0,0,0,0,0,
                //                 0,0,0,0,0,0,
                //                 0,0,0,0,0,0,
                //                 0,0,0,0,0,0,
                //                 0,0,0,0,0,0,
                //                 0,0,0,0,0,0,
                //                 0,0,0,0,0,0,
                //                 0,0,0,0,0,0};


                int[] tempMap3 = {0,0,0,3,0,0,
                                 0,1,4,3,4,0,
                                 3,4,0,2,0,1,
                                 3,0,0,4,5,8,
                                 4,0,2,1,0,0,
                                 3,0,4,0,2,0,
                                 0,0,0,0,4,0,
                                 0,4,0,0,0,0};



                for (int i = 0; i < minimap_manager.gridId.Length; i++)
                {
                    minimap_manager.gridId[i] = tempMap3[i];
                }

                int[] tempMonsterMap3 = { 10, 11, 12, 13, 14 };


                for (int i = 0; i < minimap_manager.monsterId.Length; i++)
                {
                    minimap_manager.monsterId[i] = tempMonsterMap3[i];
                }

                int[] tempItemMap3 = { 10, 11, 12, 13, 14 };


                for (int i = 0; i < minimap_manager.itemId.Length; i++)
                {
                    minimap_manager.itemId[i] = tempItemMap3[i];
                }

                minimap_manager.onLoadMessages = messages[2].GetComponent<TileTextHolder>().onLoadMessages;
                minimap_manager.onLoadAudios = messages[2].GetComponent<TileTextHolder>().audios;

                break;

            case 4:

                minimap_manager.map_type = 0;
                minimap_manager.background_id = 0;



                int[] tempMap4 = {4,4,0,0,0,0,
                                 4,7,0,0,2,0,
                                 0,0,4,4,0,0,
                                 0,1,4,4,0,0,
                                 3,0,0,0,0,2,
                                 3,0,0,4,4,1,
                                 0,2,0,4,4,4,
                                 0,0,0,0,4,4};





                for (int i = 0; i < minimap_manager.gridId.Length; i++)
                {
                    minimap_manager.gridId[i] = tempMap4[i];
                }


                int[] tempMonsterMap4 = { 15, 16, 17, 18, 19 };


                for (int i = 0; i < minimap_manager.monsterId.Length; i++)
                {
                    minimap_manager.monsterId[i] = tempMonsterMap4[i];
                }


                int[] tempItemMap4 = { 15, 16, 17, 18, 19 };


                for (int i = 0; i < minimap_manager.itemId.Length; i++)
                {
                    minimap_manager.itemId[i] = tempItemMap4[i];
                }

                minimap_manager.onLoadMessages = messages[3].GetComponent<TileTextHolder>().onLoadMessages;
                minimap_manager.onLoadAudios = messages[3].GetComponent<TileTextHolder>().audios;

                break;

            case 5:

                minimap_manager.map_type = 1;
                minimap_manager.background_id = 1;


                //int[] tempMap5 = {0,0,0,0,0,0,0,0,
                //                  0,0,0,0,0,0,0,0,
                //                  0,0,0,0,0,0,0,0,
                //                  0,0,0,0,0,0,0,0,
                //                  0,0,0,0,0,0,0,0,
                //                  0,0,0,0,0,0,0,0};

                int[] tempMap5 = {4,4,4,10,10,4,4,4,
                                  4,4,4,10,10,4,4,4,
                                  0,0,0,0,0,0,1,0,
                                  1,4,9,0,8,0,4,0,
                                  0,2,4,0,0,0,2,0,
                                  0,0,0,0,0,0,0,0};



                for (int i = 0; i < minimap_manager.gridId.Length; i++)
                {
                    minimap_manager.gridId[i] = tempMap5[i];
                }

                int[] tempMonsterMap5 = { 20, 21, 22, 23, 24 };


                for (int i = 0; i < minimap_manager.monsterId.Length; i++)
                {
                    minimap_manager.monsterId[i] = tempMonsterMap5[i];
                }

                int[] tempItemMap5 = { 20, 21, 22, 23, 24 };


                for (int i = 0; i < minimap_manager.itemId.Length; i++)
                {
                    minimap_manager.itemId[i] = tempItemMap5[i];
                }

                minimap_manager.onLoadMessages = messages[4].GetComponent<TileTextHolder>().onLoadMessages;
                minimap_manager.onLoadAudios = messages[4].GetComponent<TileTextHolder>().audios;
                break;


            case 6:

                minimap_manager.map_type = 1;
                minimap_manager.background_id = 1;
                //0 - blank space
                //1 - question mark
                //2 - monster
                //3 - slow
                //4 - wall
                //5 - fence
                //6 - key
                //7 - key door
                //8 - cartographer floor
                //9 - shop

                int[] tempMap6 = {4,4,0,0,0,0,4,4,
                                  4,2,0,0,0,0,2,4,
                                  1,0,0,3,3,0,0,1,
                                  0,0,0,0,0,0,0,0,
                                  0,0,2,0,0,2,0,0,
                                  0,0,0,0,0,0,0,0};





                for (int i = 0; i < minimap_manager.gridId.Length; i++)
                {
                    minimap_manager.gridId[i] = tempMap6[i];
                }


                int[] tempMonsterMap6 = { 25, 26, 27, 28, 29 };


                for (int i = 0; i < minimap_manager.monsterId.Length; i++)
                {
                    minimap_manager.monsterId[i] = tempMonsterMap6[i];
                }

                int[] tempItemMap6 = { 25, 26, 27, 28, 29 };


                for (int i = 0; i < minimap_manager.itemId.Length; i++)
                {
                    minimap_manager.itemId[i] = tempItemMap6[i];
                }

                minimap_manager.onLoadMessages = messages[5].GetComponent<TileTextHolder>().onLoadMessages;
                minimap_manager.onLoadAudios = messages[5].GetComponent<TileTextHolder>().audios;
                break;

        }
    }
}
