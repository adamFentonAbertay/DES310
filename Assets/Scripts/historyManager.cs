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
    private UnityAction HideHistoryAction;
    public GameObject itemManager;

    // Start is called before the first frame update
    private GameObject history;

    public void creteHistoryItem(GameObject toDisplay)
    {
        
        GameObject newObj = Instantiate(templatePrefab, templatesParent.transform);
        newObj.name = toDisplay.name;
      
        HideHistoryAction += popup;
       
        
        newObj.GetComponent<RawImage>().texture = toDisplay.GetComponent<RawImage>().texture;
       
        newObj.GetComponent<Button>().onClick.AddListener(HideHistoryAction);

            //onclick disable this gameobject
            //activate popup border gameobject
            //popupcontroller.popupshow gameobject
    }

    void popup()
    {
        popupBordRef.SetActive(true);
        for (int i = 0; i < itemManager.GetComponent<ItemEnabler>().itemArray.Length; i++)
        {
            itemManager.GetComponent<ItemEnabler>().itemArray[i].name = newObj.name;
            popupBordRef.GetComponentInChildren<PopupController>().popupShow(itemManager.GetComponent<ItemEnabler>().itemArray[i]);
            //search for NAME SEARCH FOR NAME GOD DAMN
        }

       
    }

   

}
