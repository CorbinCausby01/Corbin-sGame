using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;



namespace DialogueManager
{
    public class DialogueManger : MonoBehaviour
    {
        
        [Header("Ink JSON")]
        [SerializeField] private TextAsset inkJSON;

        [Header("Dialogue UI")]
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] public TextMeshProUGUI dialogueText;
        [SerializeField] public TextMeshProUGUI DialogueName;
        [Header("Choices UI")]
        [SerializeField] private GameObject[] choices;

        private TextMeshProUGUI[] choicesText;

        private Story currentStory;

        private const string SPEAKER_TAG = "speaker";
        public Animator animator;

        private static DialogueManger instance;

        // Start is called before the first frame update
        private void Start()
        {
            instance = this;

            choicesText = new TextMeshProUGUI[choices.Length];
            int index = 0;
            foreach (GameObject choice in choices)
            {
                choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
                index++;
            }
        }

        public static DialogueManger GetInstance()
        {
            if (instance != null)
            {
                Debug.LogWarning("Found more than one dialoguemanager in the scene.");
            }
            return instance;
        }

        public void StartDialogue(TextAsset inkJSON)
        {
            currentStory = new Story(inkJSON.text);

            animator.SetBool("IsOpen", true);

            DisplayNextSentence();

        }

        public void DisplayNextSentence()
        {
            if(currentStory.canContinue)
            {
                // set text for the current dialogue line
                dialogueText.text = currentStory.Continue();
                // display choices, if any, for this dialogue line
                DisplayChoices();

                HandleTags(currentStory.currentTags);

            }
            else
            {
                EndDialogue();
                return;
            }
              
        }

        private void HandleTags(List<string> currentTags)
        {
            foreach (string tag in currentTags)
            {
               string[] splitTag = tag.Split(':');
               if (splitTag.Length !=2)
               {
                    Debug.LogError("Tag could not be appropriately parsed: " + tag);
               } 
               string tagKey = splitTag[0].Trim();
               string tagValue = splitTag[1].Trim();

                switch(tagKey)
                {
                    case SPEAKER_TAG:
                        DialogueName.text = tagValue;
                        break;
                    default:
                        Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                        break;
                }
            }
        }

        IEnumerator TypeSentence (string sentence)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }

        }

        public void EndDialogue()
        {
            animator.SetBool("IsOpen", false);
        }

        public void DisplayChoices()
        {
            List<Choice> currentChoices = currentStory.currentChoices;
            

            //Check to make sure our UI can support the number of choices in.
            if (currentChoices.Count > choices.Length)
            {
                Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
            }

            int index = 0;
            // enable and initialize the choices up to the amount of the choices for this line of dialogue
            foreach (Choice choice in currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = choice.text;
                index++;
            }
            // go through the remaining choices the Ui supports and make sure theyre hidden
            for (int i = index; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }

            StartCoroutine(SelectFirstChoice());  
        }

        public IEnumerator SelectFirstChoice()
        {
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        }

        public void MakeChoice(int choiceIndex)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
        }
    }
}

