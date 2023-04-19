using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Dice_camera : MonoBehaviour
{
    Vector3 touchStart;
    Vector3 dir;

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
            if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
            {
                Debug.Log("touch!!");
            }

        }
        if (Input.GetMouseButton(0))
        {
            dir = touchStart - Camera.main.ScreenToViewportPoint(Input.mousePosition);

            Vector3 tempd;
            tempd.x = dir.x;    
            tempd.y = dir.z;
            tempd.z = dir.y;
            Camera.main.transform.position += tempd*0.5f;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel") * 10);
    }
    void zoom(float increment)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment, 60.0f, 90.0f);
    }
}
