using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;
public class Dice2 : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody diceBody;

    public static Vector3 dice2Velocity;


    public  int reRoll = 1;
    private bool diceland;
    void Start()
    {
        diceBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (dice2Velocity.x == 0 && dice2Velocity.y == 0 && dice2Velocity.z == 0)
        {
            Debug.Log("land !!");
            diceland = true;

        } else
        {
            diceland = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dice2Velocity = diceBody.velocity;


    }
    public void getReroll()
    {
        reRoll++;
    }

    public void Roll()
    {
        if (diceland)
        {
            Debug.Log("ROLL");
            reRoll--;

            float dx = Random.Range(100, 500);
            float dy = Random.Range(90, 500);
            float dz = Random.Range(70, 500);

            transform.position = new Vector3(0.5f, 2, 2.5f);
            transform.rotation = Quaternion.identity;
            diceBody.AddForce(transform.up * 500);
            diceBody.AddTorque(dx, dy, dz);
        }
    }
    private bool MouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
