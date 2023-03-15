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
            //scripts running in panel n not the object BRUH
            //Debug.Log("-------------------------------");

            //Debug.Log(GetComponentInChildren<RawImage>().name);
           
            //Debug.Log(itemManager.GetComponent<ItemEnabler>().itemArray[i].name);
            
            //   if (itemManager.GetComponent<ItemEnabler>().itemArray[i].GetComponent<RawImage>().texture == gameObject.GetComponent<RawImage>().texture)
            
            if (itemManager.GetComponent<ItemEnabler>().itemArray[i].name == GetComponentInChildren<RawImage>().name)
            {
                popupBordRef.GetComponentInChildren<PopupController>().popupShow(itemManager.GetComponent<ItemEnabler>().itemArray[i]);
            }
            //search for NAME SEARCH FOR NAME GOD DAMN
        }

       
    }

   

}
