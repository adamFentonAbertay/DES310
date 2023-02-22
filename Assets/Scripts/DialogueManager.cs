using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.XR.OpenXR.Input;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] int lettersPerSecond = 10;
    [SerializeField] string[] dialoguesScenarios;
    public RawImage Narrator;
    private int textCountTracker = 0;
    private bool NarratorMovementFlipFlop = true;
    
    public void showDialogue()
    {
        StopAllCoroutines();
        Narrator.transform.position.Set(300, 100, 200);
       
        Debug.Log("show dialgoue");
        dialogueBox.SetActive(true);
        StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));
        textCountTracker++;
    }

    public IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";
        foreach (var letter in dialogue.ToCharArray())
        {
            if (NarratorMovementFlipFlop == true)
            {
                Debug.Log("flip");
                float posX = Narrator.transform.position.x;
                float posZ = Narrator.transform.position.z;
                Narrator.transform.position.Set(posX, 100, posZ);
                NarratorMovementFlipFlop = false;
                
            }
            else
            {
                Debug.Log("flop");
                float posX = Narrator.transform.position.x;
                float posZ = Narrator.transform.position.z;
                Narrator.transform.position.Set(posX, -100, posZ);
                NarratorMovementFlipFlop = true;
                
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

    }
}
