using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

//DOCS
//To interact with this system, use the array for text within the scripts component.
//Key messages HIDE, DISABLE, and RESUME are used to control the AI character.
//To show the screen and bring text back on tap, use HIDE and then RESUME
//To make the narrator stop compltely, use DISABLE and then call RESUME from whatever action you want narration to start from.
public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] int lettersPerSecond = 10;
    [SerializeField] float PunctuationPauseTime = .8f;
    public List<string> dialoguesScenarios;
    public List<AudioClip> dialogueAudios;
    [SerializeField] AudioSource sfx;
    [SerializeField] GameObject clickableCollider;
    public GameObject Narrator;
    private int textCountTracker = 0;
    private bool NarratorMovementFlipFlop = true;
    

    public void setDialogue(GameObject textPrefabHolder)
    {
        textCountTracker = 0;
        dialoguesScenarios = textPrefabHolder.GetComponent<TileTextHolder>().onLoadMessages;
        dialogueAudios = textPrefabHolder.GetComponent<TileTextHolder>().audios;
        sfx.Stop();
      
    }
    public void showDialogue()
    {

        dialogueBox.SetActive(true);
        Narrator.SetActive(true);
        playDialgoue();
    }

    public void playDialgoue()
    {
        sfx.Stop();
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
           
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));
        }
        else
        {
            Debug.Log(textCountTracker);
          
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));
            

        }
        textCountTracker++;
    }
    //make invisible without setactive? maybe causing memory leak as still being used?
    //think memory leaks are the couroutines tbf

    //having play in here causes a memory leak bruh
    public void resumeDialogue()
    {
        dialogueText.text = "Press to resume dialogue";
        Debug.Log("resume dialogue");
        dialogueBox.SetActive(true);
        Narrator.SetActive(true);
        clickableCollider.SetActive(true);
       
    }
    public void disableDialogue()
    {
        StopAllCoroutines();
        Debug.Log("disable dialogue");
        dialogueBox.SetActive(false);
        Narrator.SetActive(false);
        clickableCollider.SetActive(false);
       
    }

    public void hideDialogue()
    {
        StopAllCoroutines();
        Debug.Log("hide dialogue");
        dialogueBox.SetActive(false);

        Narrator.SetActive(false);
        clickableCollider.SetActive(true);
    }

    

    public IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";
        if (dialogueAudios.Count == 0)
        {
            Debug.Log("no audio on this popup");
        }
        else
        {
            sfx.clip = dialogueAudios[textCountTracker];
            sfx.Play();
        }
        foreach (var letter in dialogue.ToCharArray())
        {
        
            
            if (NarratorMovementFlipFlop == true)
            {
                float posX = Narrator.transform.position.x;
                float posZ = Narrator.transform.position.z;
                Narrator.gameObject.transform.position.Set(posX, 100, posZ);
                NarratorMovementFlipFlop = false;
                
            }
            else
            {
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
            if (dialogueText.text.EndsWith(","))
            {
                yield return new WaitForSeconds(PunctuationPauseTime / 2);
            }
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

    }
}
