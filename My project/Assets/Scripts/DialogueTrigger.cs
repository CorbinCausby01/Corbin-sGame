using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueManager;



namespace DialogueTrigger
{
    public class DialogueTrigger : MonoBehaviour
    {
        [Header("Ink JSON")]
        [SerializeField] private TextAsset inkJSON;

        public void TriggerDialogue()
        {
            FindObjectOfType<DialogueManger>().StartDialogue(inkJSON);
        }
    }
}

