using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{

    [SerializeField] private RawImage popupImage;
    [SerializeField] private TMPro.TextMeshProUGUI popupText;
    [SerializeField] private TMPro.TextMeshProUGUI popupDesc;
    [SerializeField] private GameObject HistoryContainer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void popupShow(GameObject toDisplay)
    {
        Debug.Log("popup show");
        Debug.Log(toDisplay.name);
        popupText.text = toDisplay.name;
        popupImage.texture = toDisplay.GetComponent<RawImage>().texture;
        popupDesc.text = toDisplay.GetComponentInChildren<Text>().text;
        // Debug.Log(toDisplay.GetComponentInChildren<Text>().text);
        popupHistory(toDisplay);
   

        //using this as a bool for if its first time being discovered as this dos not affct the rawimage
        
    }

    private void popupHistory(GameObject toDisplay)
    {
        Debug.Log("history add");
        if (toDisplay.GetComponentInChildren<RawImage>().enabled == true)
        {
            Debug.Log("first find of this object.");
            HistoryContainer.GetComponent<historyManager>().creteHistoryItem(toDisplay);
            toDisplay.GetComponentInChildren<RawImage>().enabled = false;
        }
    }
    
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
