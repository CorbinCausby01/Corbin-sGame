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

        public void StartDialogue(program dialogue)
        {

            animator.SetBool("IsOpen", true);


            DialogueName.text = dialogue.name;

            sentences.Clear();

            foreach(string sentence in dialogue.sentences.Split(new[]{ '\n'}))
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
        string sentence;
        public void AddSentenceToQueue()
        {
            
            sentences.Enqueue(sentence);
        }
    }
}

