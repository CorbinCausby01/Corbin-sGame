using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueManager;

[System.Serializable]
public class Dialogue : DialogueManger 
{
  
  

  public void NewSentences(string s)
  {
    //AddSentenceToQueue(DialogueName.text = "Kai Cenat");
    //return Convert.ToString(AddSentenceToQueue(CharacterDialogue.text = "Hello World!"));
    //return Convert.ToString(AddSentenceToQueue(CharacterDialogue.text = "Does this work?"));
    AddSentenceToQueue(CharacterDialogue.text = "Does this work?"); 
    AddSentenceToQueue(CharacterDialogue.text = "How about now?");
    
  }
    
}
