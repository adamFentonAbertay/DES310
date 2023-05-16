using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
      
     

         }

    private void Awake()
    {

        if (AudioManager.musicEnable == true)
        {
            this.GetComponent<Toggle>().SendMessage("SetIsOnWithoutNotify", true);
        }
        else
        {
            this.GetComponent<Toggle>().SendMessage("SetIsOnWithoutNotify", false);
        }

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
