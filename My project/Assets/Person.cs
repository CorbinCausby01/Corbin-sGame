using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using DialogueManager;



namespace Characters
{
    
    public class Person : MonoBehaviour 
    {
        
        public string pname;
        public string bestMove;
        public int moveSlots;
        public int health;
        public int maxHealth;
        public int attckDmg;
        public string type;
        public string sentences;

       
        public void dialogueSentence(string sentences)
        {
            FindObjectOfType<DialogueManger>().AddSentenceToQueue(sentences);
        }
        

    }
    public class Streamer : Person
    {
        public Streamer(string _pname, string _bestMove, int _attckDmg, int _health, string _type)
        {
            pname = _pname;
            bestMove = _bestMove;
            health = _health;
            maxHealth = _health;
            moveSlots = 1;
            attckDmg = _attckDmg;
            type = _type;
        }
        public void Stream ()
        {

        }
    }

    public class Soccer : Person
    {

        public Soccer(string _pname, string _bestMove, int _attckDmg, int _health, string _type)
        {
            pname = _pname;
            bestMove = _bestMove;
            health = _health;
            maxHealth = _health;
            moveSlots = 1;
            attckDmg = _attckDmg;
            type = _type;
        }

        public void Goal ()
        {

        }
    }

    public class Basketball : Person
    {
        public Basketball(string _pname, string _bestMove, int _attckDmg, int _health, string _type)
        {
            pname = _pname;
            bestMove = _bestMove;
            health = _health;
            maxHealth = _health;
            moveSlots = 1;
            attckDmg = _attckDmg;
            type = _type;
        }

        public void Basket ()
        {

        }
    }

    public class Rapper : Person
    {
        public Rapper(string _pname, string _bestMove, int _attckDmg, int _health, string _type)
        {
            pname = _pname;
            bestMove = _bestMove;
            health = _health;
            maxHealth = _health;
            moveSlots = 1;
            attckDmg = _attckDmg;
            type = _type;
        }

        public void Rap ()
        {

        }
    }

    public class Enemy : Person
    {

    }
}