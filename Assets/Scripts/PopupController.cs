using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{

    [SerializeField] private RawImage popupImage;
    [SerializeField] private TMPro.TextMeshProUGUI popupText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void popupShow(GameObject toDisplay)
    {
        Debug.Log(toDisplay.name);
        popupText.text = toDisplay.name;
        popupImage.texture = toDisplay.GetComponent<RawImage>().texture;        
    }
    
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
