using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class BowMechanic : MonoBehaviour
{
    public float speed = 10;
    private Vector2 dragBeginPosition;
    private Vector2 dragEndPosition;

    //deprecated, redacted, old, dead, cryin for its mumma, THIS CODE AINT BEIN USED


    // Start is called before the first frame update
    void Start()
    {
        speed *= 10000;
    }

    // Update is called once per frame


    void Update()
    {
        if (Input.touchCount > 0)
        {
            // print("exist a touch");
            gameObject.transform.position = Input.GetTouch(0).position;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                dragBeginPosition = (Input.GetTouch(0).position);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                dragEndPosition = (Input.GetTouch(0).position);
                Vector2 impulse = dragBeginPosition - dragEndPosition;
                impulse.Normalize();

                
                print(Input.GetTouch(0).position);
               // gameObject.GetComponent<Rigidbody2D>().velocity.Set(1000, 1000);
                gameObject.GetComponent<Rigidbody2D>().AddForce(impulse * speed);
            }
        }

    }
}
