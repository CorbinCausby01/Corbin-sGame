using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PokeReal;


namespace DialogueManager
{
    public class DialogueManger : MonoBehaviour
    {

        public TextMeshProUGUI DialogueName;
        public TextMeshProUGUI CharacterDialogue;
        public Animator animator;

        private Queue<string> sentences;

        // Start is called before the first frame update
        void Start()
        {
            sentences = new Queue<string>();
            
        }

        public void StartDialogue(Program dialogue)
        {
            
            //Debug.Log(sentences.Count);

            animator.SetBool("IsOpen", true);

            DialogueName.text = dialogue.nameofdialogue;

            //sentences.Clear();
            
            FindObjectOfType<Program>().Testing();

            DisplayNextSentence();

        }

        public void DisplayNextSentence()
        {
            if(sentences.Count == 0)
            {
                EndDialogue();
                return;
            }


            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));  
        }

        IEnumerator TypeSentence (string sentence)
        {
            CharacterDialogue.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                CharacterDialogue.text += letter;
                yield return null;
            }

        }

        public void EndDialogue()
        {
            animator.SetBool("IsOpen", false);
        }
    
        public void AddSentenceToQueue(string sentence1)
        {
            CharacterDialogue.text = sentence1;
            sentences.Enqueue(sentence1);
        }
    }
}

