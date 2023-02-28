using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueManager;
using PokeReal;

namespace DialogueTrigger
{
    public class DialogueTrigger : MonoBehaviour
    {
        public program dialogue;

        public void TriggerDialogue()
        {
            FindObjectOfType<DialogueManger>().StartDialogue(dialogue);
        }
    }
}

