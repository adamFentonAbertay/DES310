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
        //sets the popups images and text spaces to the values held by the game object (prefabbed)
        Debug.Log("popup show");
      //  Debug.Log(toDisplay.name);
        popupText.text = toDisplay.name;
        popupImage.texture = toDisplay.GetComponent<RawImage>().texture;
        popupDesc.text = toDisplay.GetComponentInChildren<Text>().text;
        // Debug.Log(toDisplay.GetComponentInChildren<Text>().text);
        popupHistory(toDisplay);
   
        
    }

    private void popupHistory(GameObject toDisplay)
    {
        //adds opened item to history if its the first time the object has been opened
        //does this by having PREFAB of item image enabled if its first time opened

        Debug.Log("history add");
        if (toDisplay.GetComponentInChildren<RawImage>().enabled == true)
        {
            //create da thing les gooooo
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
