using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Fullmap_manager : MonoBehaviour
{
    Vector3 touchStart;
    Vector3 dir;
    public Button[] map_Button;
    private bool[] map_vivwed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, 1.0f, 35.0f);
    }
}
