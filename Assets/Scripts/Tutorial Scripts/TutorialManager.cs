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
public class TutorialManager : MonoBehaviour
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
    public GameObject SetupPage;
    public GameObject MovementPage;
    public GameObject CombatPage;
    public GameObject InteractionsPage;


    public void setDialogue(GameObject textPrefabHolder)
    {
        //sets the local variables to that held in the text prefab param
        textCountTracker = 0;
        dialoguesScenarios = textPrefabHolder.GetComponent<TileTextHolder>().onLoadMessages;
        dialogueAudios = textPrefabHolder.GetComponent<TileTextHolder>().audios;
        sfx.Stop();

    }

    public int returnDialoguePlace()
    {
        return textCountTracker;
    }
    public void showDialogue()
    {
        //enables on screen
        dialogueBox.SetActive(true);
        Narrator.SetActive(true);
        playDialgoue();
    }

    public void playDialgoue()
    {
        //stop what ur doing
        sfx.Stop();
        StopAllCoroutines();



        Debug.Log("play dialgoue");
        //checking for dev keylogs
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

        //This segment is for the tutorial setup page. I am using key words which call functions within other scripts to hide and show images.
        else if (dialoguesScenarios[textCountTracker] == "INVENTORY") //This is used for the tutorial dialogue to make the inventory Image appear
        {
            hideDialogue();

            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleInventory();
        }
        else if (dialoguesScenarios[textCountTracker] == "INVENTORYHIDE") //This is used for the tutorial dialogue to make the inventory Image dissapear
        {
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleInventory();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));
        }
        else if (dialoguesScenarios[textCountTracker] == "ENCOUNTERCARD") //This is used for the tutorial dialogue to make the encounter card Image appear.
        {
            hideDialogue();
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleEncounterCard();
        }
        else if (dialoguesScenarios[textCountTracker] == "ENCOUNTERCARDHIDE") //This is used for the tutorial dialogue to make the encounter card Image dissapear
        {
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleEncounterCard();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));
        }
        else if (dialoguesScenarios[textCountTracker] == "ENEMYCARDS") //This is used for the tutorial dialogue to make the enemy cards Image appear.
        {
            hideDialogue();
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleEnemyCards();
        }

        else if (dialoguesScenarios[textCountTracker] == "ENEMYCARDSHIDE") //This is used for the tutorial dialogue to make the enemy cards Image disappear.
        {
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleEnemyCards();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));
        }
        else if (dialoguesScenarios[textCountTracker] == "BOARDLAYOUT") //This is used for the tutorial dialogue to make the board layout Image appear.
        {
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleBoardLayout();
        }
        else if (dialoguesScenarios[textCountTracker] == "BOARDLAYOUTHIDE") //This is used for the tutorial dialogue to make the board layout Image disappear.
        {
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleBoardLayout();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));
        }
        else if (dialoguesScenarios[textCountTracker] == "ZONECARDS") //This is used for the tutorial dialogue to make the zone cards Image visable.
        {
            hideDialogue();
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleZoneCards();

        }
        else if (dialoguesScenarios[textCountTracker] == "ZONECARDSHIDE") //This is used for the tutorial dialogue to make the zone cards Image disappear.
        {
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleZoneCards();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));

        }
        else if (dialoguesScenarios[textCountTracker] == "ZONECARDSSETUP") //This is used for the tutorial dialogue to make the zone cards setup Images visable.
        {
            hideDialogue();
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleZoneCardsSetupImages();
            SetupPage.GetComponent<SetupPageScript>().ToggleBoardLayout();

        }
        else if (dialoguesScenarios[textCountTracker] == "ZONECARDSSETUPHIDE") //This is used for the tutorial dialogue to make the zone cards setup Images disappear.
        {
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleZoneCardsSetupImages();
            SetupPage.GetComponent<SetupPageScript>().ToggleBoardLayout();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));

        }
        else if (dialoguesScenarios[textCountTracker] == "ITEMCARDS") //This is used for the tutorial dialogue to make the item cards image visable.
        {
            hideDialogue();
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleItemCardsImage();

        }
        else if (dialoguesScenarios[textCountTracker] == "ITEMCARDSHIDE") //This is used for the tutorial dialogue to make the item cards image dissapear.
        {
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleItemCardsImage();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));

        }
        else if (dialoguesScenarios[textCountTracker] == "ENDSETUP") //This is used for the tutorial dialogue to make all the end setup images visable.
        {
            hideDialogue();
            if (SetupPage == null)
            {
                Debug.Log("no tutorial setup page reference");
            }

            SetupPage.GetComponent<SetupPageScript>().ToggleEndSetupImages();
            disableDialogue();

        }
        //This segment is for the tutorial Movement page.

        else if (dialoguesScenarios[textCountTracker] == "DICEROLL") //This is used for the tutorial dialogue to make the board layout Image disappear.
        {
            hideDialogue();
            if (MovementPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            MovementPage.GetComponent<MovementPageScript>().ToggleDiceRollImage();

        }
        else if (dialoguesScenarios[textCountTracker] == "HIDEDICEROLL") //This is used for the tutorial dialogue to make the board layout Image disappear.
        {
            if (MovementPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            MovementPage.GetComponent<MovementPageScript>().ToggleDiceRollImage();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));

        }
        //This segment is for the tutorial Combat page.
        else if (dialoguesScenarios[textCountTracker] == "ENEMYSPAWN") //This is used for the tutorial dialogue to make the Enemy spawn image appear.
        {
            hideDialogue();
            if (CombatPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            CombatPage.GetComponent<CombatPageScript>().ToggleEnemySpawn();

        }
        else if (dialoguesScenarios[textCountTracker] == "ENEMYSPAWNHIDE") //This is used for the tutorial dialogue to make the Enemy spawn image disappear.
        {
            if (CombatPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            CombatPage.GetComponent<CombatPageScript>().ToggleEnemySpawn();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));

        }
        else if (dialoguesScenarios[textCountTracker] == "MONSTERENCOUNTER") //This is used for the tutorial dialogue to make the monster encounter images appear.
        {
            hideDialogue();
            if (CombatPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            CombatPage.GetComponent<CombatPageScript>().ToggleMonsterEncounter();

        }
        else if (dialoguesScenarios[textCountTracker] == "MONSTERENCOUNTERHIDE") //This is used for the tutorial dialogue to make the monster encounter images disappear.
        {
            if (CombatPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            CombatPage.GetComponent<CombatPageScript>().ToggleMonsterEncounter();


        }
        else if (dialoguesScenarios[textCountTracker] == "COMBATDICE") //This is used for the tutorial dialogue to make the combat dice images appear.
        {
            hideDialogue();
            if (CombatPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            CombatPage.GetComponent<CombatPageScript>().ToggleCombatDice();
        }
        else if (dialoguesScenarios[textCountTracker] == "COMBATDICEHIDE") //This is used for the tutorial dialogue to make the combat dice images disappear.
        {
            if (CombatPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            CombatPage.GetComponent<CombatPageScript>().ToggleCombatDice();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));

        }
        //This segment is for the tutorial Iteractions page.
        else if (dialoguesScenarios[textCountTracker] == "SHOP") //This is used for the tutorial dialogue to make the shop symbol image appear.
        {
            hideDialogue();
            if (InteractionsPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            InteractionsPage.GetComponent<InteractionPageScript>().ToggleShopSymbol();
        }
        else if (dialoguesScenarios[textCountTracker] == "SHOPHIDE") //This is used for the tutorial dialogue to make the shop symbol image disappear.
        {
            if (InteractionsPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            InteractionsPage.GetComponent<InteractionPageScript>().ToggleShopSymbol();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));

        }
        else if (dialoguesScenarios[textCountTracker] == "TRADE") //This is used for the tutorial dialogue to make the trade example images appear.
        {
            hideDialogue();
            if (InteractionsPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            InteractionsPage.GetComponent<InteractionPageScript>().ToggleTradeExample();
        }
        else if (dialoguesScenarios[textCountTracker] == "TRADEHIDE") //This is used for the tutorial dialogue to make the trade example images disappear.
        {
            if (InteractionsPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            InteractionsPage.GetComponent<InteractionPageScript>().ToggleTradeExample();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));
        }
        else if (dialoguesScenarios[textCountTracker] == "CRABBOSS") //This is used for the tutorial dialogue to make the crab boss image appear.
        {
            InteractionsPage.GetComponent<InteractionPageScript>().ToggleTradeDiagram();
            hideDialogue();
            if (InteractionsPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            InteractionsPage.GetComponent<InteractionPageScript>().ToggleCrabBoss();
        }
        else if (dialoguesScenarios[textCountTracker] == "CRABBOSSHIDE") //This is used for the tutorial dialogue to make the crab boss image disappear.
        {
            if (InteractionsPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            InteractionsPage.GetComponent<InteractionPageScript>().ToggleCrabBoss();
            resumeDialogue();
            textCountTracker++;
            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));
        }

        else if (dialoguesScenarios[textCountTracker] == "TRADEDIAGRAM") //This is used for the tutorial dialogue to make the trade diagram image appear.
        {
            hideDialogue();
            if (InteractionsPage == null)
            {
                Debug.Log("no tutorial movement page reference");
            }

            InteractionsPage.GetComponent<InteractionPageScript>().ToggleTradeDiagram();
        }

        else
        {
            Debug.Log(textCountTracker);

            StartCoroutine(TypeDialogue(dialoguesScenarios[textCountTracker]));

        }
        textCountTracker++;
    }

    //think memory leaks can be caused by couroutines be wary traveller



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
        //play audio if theres audio to play
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

        //display lettr by letter ur message
        foreach (var letter in dialogue.ToCharArray())
        {


            //if (NarratorMovementFlipFlop == true)
            //{
            //    float posX = Narrator.transform.position.x;
            //    float posZ = Narrator.transform.position.z;
            //    Narrator.gameObject.transform.position.Set(posX, 100, posZ);
            //    NarratorMovementFlipFlop = false;

            //}
            //else
            //{
            //    float posX = Narrator.transform.position.x;
            //    float posZ = Narrator.transform.position.z;
            //    Narrator.transform.position.Set(posX, -100, posZ);
            //    NarratorMovementFlipFlop = true;

            //}

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
