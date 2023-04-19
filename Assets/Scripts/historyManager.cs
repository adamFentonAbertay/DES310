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


    //unity action needs a custom subclass that has this as parent but allows params
    private UnityAction HideHistoryAction;

    public void creteHistoryItem(GameObject toDisplay)
    {
        //create history item according to prefab when called by first time open
        //assign param as the image to show in the history tab
       
        GameObject newObj = Instantiate(templatePrefab, templatesParent.transform);
        newObj.name = toDisplay.name;
      
       //think of this as a function call for "popup" - it looks different as it is a unityaction to be called by OnClick
       //this just assigning to show the correct preview image dont mind me
        newObj.GetComponent<RawImage>().texture = toDisplay.GetComponent<RawImage>().texture;
        newObj.GetComponent<RawImage>().name = toDisplay.GetComponent<RawImage>().name;
        newObj.GetComponent<Button>().onClick.AddListener(() => { popup(newObj.GetComponent<RawImage>().name); });

        Debug.Log("create:"+ newObj.GetComponentInChildren<RawImage>().name);

    }

    void popup(string name)
    {

       
        popupBordRef.SetActive(true);
        //to display image still not working to show the right preview on touch
        Debug.Log(GetComponentInChildren<RawImage>().name);

        for (int i = 0; i < itemManager.GetComponent<ItemEnabler>().itemArray.Length; i++)
        {

           // Debug.Log(GetComponentInChildren<RawImage>().name);
            //the problem!!! ur about to get smacked silly
            if (itemManager.GetComponent<ItemEnabler>().itemArray[i].name == name)
            {
              
                popupBordRef.GetComponentInChildren<PopupController>().popupShow(itemManager.GetComponent<ItemEnabler>().itemArray[i]);
            }
           
        }

    }

   

}
