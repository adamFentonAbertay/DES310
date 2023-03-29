using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class historyManager : MonoBehaviour
{
    public GameObject templatePrefab;
    public GameObject templatesParent;
    public GameObject popupBordRef;
   
    public GameObject itemManager;

    // Start is called before the first frame update

    private UnityAction HideHistoryAction;

    public void creteHistoryItem(GameObject toDisplay)
    {
        //create history item according to prefab when called by first time open
        //assign param as the image to show in the history tab
       
        GameObject newObj = Instantiate(templatePrefab, templatesParent.transform);
        newObj.name = toDisplay.name;
      
       //think of this as a function call for "popup" - it looks different as it is a unityaction to be called by OnClick
        HideHistoryAction += popup;
        //this just assigning to show the correct preview image dont mind me
        newObj.GetComponent<RawImage>().texture = toDisplay.GetComponent<RawImage>().texture;   
        newObj.GetComponent<Button>().onClick.AddListener(HideHistoryAction);
  

    }

    void popup()
    {
        popupBordRef.SetActive(true);
        //to display image still not working to show the right preview on touch
        for (int i = 0; i < itemManager.GetComponent<ItemEnabler>().itemArray.Length; i++)
        {
         
            
            if (itemManager.GetComponent<ItemEnabler>().itemArray[i].name == GetComponentInChildren<RawImage>().name)
            {
                popupBordRef.GetComponentInChildren<PopupController>().popupShow(itemManager.GetComponent<ItemEnabler>().itemArray[i]);
            }
           
        }

       
    }

   

}
