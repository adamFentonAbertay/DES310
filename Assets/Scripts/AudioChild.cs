using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void Awake()
    {
        Tog();
    }
    void Update()
    {
       
    }

    public void Tog()
    {
        if (AudioManager.musicEnable == true)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().UnPause();
        }
        else
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Pause();
        }
    }
}
