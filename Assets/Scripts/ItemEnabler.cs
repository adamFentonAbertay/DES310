using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEnabler : MonoBehaviour
{

    public GameObject[] itemArray;
    // Start is called before the first frame update
  
    //image state of prefabs used to track if its been opened - all need enabled on launch
    void Start()
    {
        for (int i = 0; i < itemArray.Length; i++)
        {
            itemArray[i].GetComponentInChildren<RawImage>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
