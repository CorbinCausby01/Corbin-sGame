using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueManager;

public class Dialogue : DialogueManger 
{

  public void NewSentences()
  {
    AddSentenceToQueue("Hello World.");
    AddSentenceToQueue("How about now?");
    
  }
    
}
