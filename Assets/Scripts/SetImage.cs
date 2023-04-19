using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImage : MonoBehaviour
{
    public RawImage target;
    public Texture2D crabHealth1;
    public Texture2D crabHealth2;
    public Texture2D crabHealth3;
    // Start is called before the first frame update

    public void changeCrabImage(int id)
    {
        switch(id)
        {
            case 1:
                target.texture = crabHealth1;
                GetComponent<RawImage>().texture = crabHealth1;
                break;

            case 2:
                target.texture = crabHealth2;
                GetComponent<RawImage>().texture = crabHealth2;
                break;

            case 3:
                target.texture = crabHealth3;
                GetComponent<RawImage>().texture = crabHealth3;
                break;
        }
      
    } 


}
