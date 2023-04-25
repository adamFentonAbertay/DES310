using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

   public Camera camera;
   static  Vector3 cameraPos = new Vector3( 49.5f, 11.55f, 0);
   static bool scrolled = false;
    // Start is called before the first frame update
  


    // Update is called once per frame
    void Update()
    {
        if (scrolled == false)
        {
            cameraPos.y -= 5 * Time.deltaTime;

            camera.transform.position = cameraPos;
        }
               

        if (cameraPos.y < -11.5 && scrolled == false)
        {
            scrolled = true;
        }

       
    }
}
