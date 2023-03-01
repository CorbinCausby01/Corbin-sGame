using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


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
            FindObjectOfType<Dialogue>().NewSentences();
            Debug.Log(sentences.Count);
        }

        public void StartDialogue(Dialogue dialogue)
        {

            animator.SetBool("IsOpen", true);


            DialogueName.text = dialogue.name;
            //dialogue.sentences = CharacterDialogue.text;

            sentences.Clear();

            //FindObjectOfType<Dialogue>().NewSentences();

            foreach(string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }


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
    
        public void AddSentenceToQueue(string sentence)
        {
            sentences.Enqueue(CharacterDialogue.text = sentence);
        }
    }
}

