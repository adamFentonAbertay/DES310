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
  


    private int[] map_id = new int[6];
    public static bool[] map_vivwed = new bool[6];

    // Start is called before the first frame update
    void Start()
    {
       
        map_id[0] = 1;
        map_id[1] = 2;
        map_id[2] = 3;
        map_id[3] = 4;
        map_id[4] = 5;
        map_id[5] = 6;



     
    }

    // Update is called once per frame
    void Update()
    {
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
            Debug.Log("touch!!");
        }
        if (Input.GetMouseButton(0))
        {
            dir = touchStart - Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Camera.main.transform.position += dir;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel")*2);

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

    public void LoadMap(int mapid )
    {
        switch (mapid)
        {
            case 1:

                Debug.Log("CASE1");

                minimap_manager.map_type = 1;

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


                minimap_manager.onLoadMessages = messages[0].GetComponent<TileTextHolder>().onLoadMessages;


              

                break;

            case 2:

                Debug.Log("CASE2");
                minimap_manager.map_type = 1;

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


                minimap_manager.onLoadMessages = messages[1].GetComponent<TileTextHolder>().onLoadMessages;
                break;



            case 3:

                minimap_manager.map_type = 0;




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
                                 3,0,4,0,0,0,
                                 0,0,0,0,4,0,
                                 0,4,0,0,0,0};



                for (int i = 0; i < minimap_manager.gridId.Length; i++)
                {
                    minimap_manager.gridId[i] = tempMap3[i];
                }

                minimap_manager.onLoadMessages = messages[2].GetComponent<TileTextHolder>().onLoadMessages;

                break;

            case 4:

                minimap_manager.map_type = 0;




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

                minimap_manager.onLoadMessages = messages[3].GetComponent<TileTextHolder>().onLoadMessages;

                break;

            case 5:

                minimap_manager.map_type = 1;

              

                //int[] tempMap5 = {0,0,0,0,0,0,0,0,
                //                  0,0,0,0,0,0,0,0,
                //                  0,0,0,0,0,0,0,0,
                //                  0,0,0,0,0,0,0,0,
                //                  0,0,0,0,0,0,0,0,
                //                  0,0,0,0,0,0,0,0};

                int[] tempMap5 = {4,4,4,0,0,4,4,4,
                                  4,4,4,0,0,4,4,4,
                                  0,0,0,0,0,0,1,0,
                                  1,4,9,0,8,0,4,0,
                                  0,2,4,0,0,0,2,0,
                                  0,0,0,0,0,0,0,0};



                for (int i = 0; i < minimap_manager.gridId.Length; i++)
                {
                    minimap_manager.gridId[i] = tempMap5[i];
                }


                minimap_manager.onLoadMessages = messages[4].GetComponent<TileTextHolder>().onLoadMessages;
                break;


            case 6:

                minimap_manager.map_type = 1;

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


                minimap_manager.onLoadMessages = messages[5].GetComponent<TileTextHolder>().onLoadMessages;
                break;

        }
    }
}
