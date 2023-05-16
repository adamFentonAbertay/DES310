using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class SettingsController : MonoBehaviour
{
    static public float sensitivity = 2;
    

    public Slider sensSlider;
    public TextMeshProUGUI sensText;
    // Start is called before the first frame update
    void Start()
    {
        sensSlider.value = sensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sensitityUpdate ()
    {
        sensitivity = sensSlider.value;
        sensText.text = sensitivity.ToString("#.#");
        
    }



}
