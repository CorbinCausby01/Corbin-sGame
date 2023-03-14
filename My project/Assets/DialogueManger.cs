using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;



namespace DialogueManager
{
    public class DialogueManger : MonoBehaviour
    {
        
        [Header("Ink JSON")]
        [SerializeField] private TextAsset inkJSON;

        [Header("Dialogue UI")]
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] public TextMeshProUGUI dialogueText;

        private Story currentStory;

        public TextMeshProUGUI DialogueName;
        public Animator animator;

        private static DialogueManger instance;

        // Start is called before the first frame update
        private void Start()
        {
            instance = this;
        }

        //private void Update()
        //{
            //if (InputManager.GetInstance().GetSubmitPressed())
            //{
                //DisplayNextSentence();
            //}
        //}

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

            Debug.Log(inkJSON.text);

            currentStory = new Story(inkJSON.text);

            animator.SetBool("IsOpen", true);

            DisplayNextSentence();

        }

        public void DisplayNextSentence()
        {
            if(currentStory.canContinue)
            {
                dialogueText.text = currentStory.Continue();
            }
            else
            {
                EndDialogue();
                return;
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
    }
}

