using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;
public class Dice : MonoBehaviour
{
    // Start is called before the first frame update


    private Rigidbody diceBody;

    public static Vector3 diceVelocity;

    public  int reRoll = 1;
    private bool diceland;


    void Start()
    {
        diceBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (diceVelocity.x == 0 && diceVelocity.y == 0 && diceVelocity.z == 0)
        {
            Debug.Log("land !!");
            diceland = true;

        } else
        {
            diceland = false;
        }
        if (Input.touchCount > 0 && diceland && reRoll > 0 &&!MouseOverUI())
        {
            Roll();
        }
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = diceBody.velocity;

    }
   public void getReroll()
    {
        reRoll++;
    }

    public void Roll()
    {

            Debug.Log("ROLL");
            reRoll--;

            float dx = Random.Range(100, 500);
            float dy = Random.Range(90, 500);
            float dz = Random.Range(70, 500);

            transform.position = new Vector3(4.5f, 2, 2.5f);
            transform.rotation = Quaternion.identity;
            diceBody.AddForce(transform.up * 500);
            diceBody.AddTorque(dx, dy, dz);
        
    }

    private bool MouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
