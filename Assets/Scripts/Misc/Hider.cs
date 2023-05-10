using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject toHide;
    void Start()
    {
        
    }

    public void Hide()
    {
        toHide.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
