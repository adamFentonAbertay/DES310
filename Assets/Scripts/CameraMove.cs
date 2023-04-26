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

        cam_limt();
    }

    void cam_limt()
    {
        float Xmax, Xmin, Ymax, Ymin;
        float range = 20.0f;

        Xmax = cameraPos.x + range;
        Xmin = cameraPos.x - range;

        Ymax = cameraPos.y + range;
        Ymin = cameraPos.y - range;

        Vector3 campos = Camera.main.transform.position;

        if (Camera.main.transform.position.x > Xmax)
        {
            campos.x = Xmax;
            Camera.main.transform.position = campos;
        }
        if (Camera.main.transform.position.y > Ymax)
        {
            campos.y = Ymax;
            Camera.main.transform.position = campos;
        }
        if (Camera.main.transform.position.x < Xmin)
        {
            campos.x = Xmin;
            Camera.main.transform.position = campos;
        }
        if (Camera.main.transform.position.y < Ymin)
        {
            campos.y = Ymin;
            Camera.main.transform.position = campos;
        }
    }

}
