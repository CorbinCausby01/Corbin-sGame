using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueManager;


namespace DialogueTrigger
{
    public class DialogueTrigger : MonoBehaviour
    {
        public Dialogue dialogue;

        public void TriggerDialogue()
        {
            FindObjectOfType<DialogueManger>().StartDialogue(dialogue);
        }
    }
}

