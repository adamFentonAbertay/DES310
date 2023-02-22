using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] int lettersPerSecond = 10;
    [SerializeField] string[] dialoguesScenarios;
    private int textCountTracker = 0;
    
    public void showDialogue()
    {
        StopAllCoroutines();
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
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

    }
}
