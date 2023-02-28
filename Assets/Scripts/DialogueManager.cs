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
    [SerializeField] float PunctuationPauseTime = .8f;
    [SerializeField] string[] dialoguesScenarios;
    [SerializeField] AudioSource sfx;
    [SerializeField] GameObject clickableCollider;
    public RawImage Narrator;
    private int textCountTracker = 0;
    private bool NarratorMovementFlipFlop = true;
    
    public void showDialogue()
    {

        dialogueBox.SetActive(true);
        Narrator.enabled = true;
        playDialgoue();
    }

    public void playDialgoue()
    {
        StopAllCoroutines();
        Narrator.transform.position.Set(300, 100, 200);

        Debug.Log("play dialgoue");

         if (dialoguesScenarios[textCountTracker] == "HIDE")
        {
            hideDialogue();
        }
        else if (dialoguesScenarios[textCountTracker] == "DISABLE")
        {
            disableDialogue();
        }
        else if (dialoguesScenarios[textCountTracker] == "RESUME")
        {
            resumeDialogue();
        }
        else
        {
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));
            
        }
        textCountTracker++;
    }

    public void resumeDialogue()
    {
        Debug.Log("resume dialogue");
        dialogueBox.SetActive(true);
        Narrator.enabled = true;
        clickableCollider.SetActive(true);
        playDialgoue();
    }
    public void disableDialogue()
    {
        Debug.Log("disable dialogue");
        dialogueBox.SetActive(false);
        Narrator.enabled = false;
        clickableCollider.SetActive(false);
       
    }

    public void hideDialogue()
    {
        Debug.Log("hide dialogue");
        dialogueBox.SetActive(false);
        Narrator.enabled = false;
        clickableCollider.SetActive(true);
    }

    

    public IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";
        foreach (var letter in dialogue.ToCharArray())
        {
            sfx.Play();
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
            //pause longer on full stops
            if (dialogueText.text.EndsWith(".") || dialogueText.text.EndsWith("?") || dialogueText.text.EndsWith("!"))
            {
                yield return new WaitForSeconds(PunctuationPauseTime);
            }
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

    }
}
