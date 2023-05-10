using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDontDestroy : MonoBehaviour
{

    //ref
    //https://www.youtube.com/watch?v=82Mn8v55nr0
    private static MusicDontDestroy instance = null;
    public static MusicDontDestroy Instance
    {
        get { return instance; }
    }
    // Start is called before the first frame update
    void Start()
    {
       //if (Instance.gameObject.GetComponent<AudioSource>().isPlaying == false)
       // {
            
        Debug.Log("start");
      //  } 
    }

   
    private void Awake()
    {
        if (Instance != null && AudioManager.musicEnable == true)
        {
            Instance.gameObject.GetComponent<AudioSource>().UnPause();
        }
        Debug.Log("awake");
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Tog()
    {
       if ( AudioManager.musicEnable == true )
        {
            Instance.gameObject.GetComponent<AudioSource>().UnPause();
        }
       else
        {
            Instance.gameObject.GetComponent<AudioSource>().Pause();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
