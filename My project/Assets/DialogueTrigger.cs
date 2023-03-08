using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueManager;
using PokeReal;


namespace DialogueTrigger
{
    public class DialogueTrigger : MonoBehaviour
    {
        public Program dialogue;

        public void TriggerDialogue()
        {
            FindObjectOfType<DialogueManger>().StartDialogue(dialogue);
        }
    }
}

