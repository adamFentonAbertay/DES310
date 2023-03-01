using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
public class monster_button : MonoBehaviour
{

    float speed = 1.0f; //how fast it shakes
    float amount = 1.0f; //how much it shakes

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position.Set(Mathf.Sin(Time.time * speed) * amount, Mathf.Sin(Time.time * speed) * amount, Mathf.Sin(Time.time * speed) * amount);
    }

    void monster_click()
    {
        Debug.Log("battle !!!!!");

    }
}
