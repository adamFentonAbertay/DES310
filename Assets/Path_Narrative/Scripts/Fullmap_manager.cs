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
  


    private int[] map_id = new int[7];
    public static bool[] map_vivwed = new bool[7];

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

                minimap_manager.map_type = 0;

           
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

                minimap_manager.onLoadMessages = messages[0].GetComponent<TileTextHolder>().onLoadMessages;

                break;
            case 2:

                minimap_manager.map_type = 1;

                int[] tempMap2 = {4,0,2,0,1,4,4,4,
                                  4,0,0,4,4,0,0,4,
                                  4,4,4,0,2,1,0,4,
                                  4,0,0,0,2,4,4,4,
                                  4,0,2,4,4,0,2,4,
                                  4,4,4,0,0,0,0,4};



                for (int i = 0; i < minimap_manager.gridId.Length; i++)
                {
                    minimap_manager.gridId[i] = tempMap2[i];
                }

               
                 minimap_manager.onLoadMessages = messages[1].GetComponent<TileTextHolder>().onLoadMessages;
              

                break;
        }
    }
}
