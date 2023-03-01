using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using DialogueManager;



namespace Characters
{
    [System.Serializable]
    public class Person : MonoBehaviour 
    {

        public string pname;
        public string bestMove;
        public int moveSlots;
        public int health;
        //public int _health;
        public int maxHealth;
        public int attckDmg;
        public string type;
        public string sentences;

       
        public void dialogueSentence(string sentences)
        {
            //FindObjectOfType<DialogueManger>().AddSentenceToQueue();
        }
        public string pData()
        {
            return this.pname + "'s best move is " + this.bestMove + " and has " + this.health + " health.";
        }

        public bool GenInfo()
        {
            dialogueSentence("It's " + this.pname + "'s turn...");
            dialogueSentence("Press E to heal.");
            dialogueSentence("Press W to charge.");
            if(this.moveSlots > 0)
            {
                dialogueSentence("Press Q to use " + this.bestMove + "(" + this.moveSlots + ")");
                return true;
            }
            else
            {
                dialogueSentence("Cannot attack, " + this.bestMove + "(" + this.moveSlots + ")");
                return false;
            }
        }

        public void HitPerson(Person enemy)
        {
            if (this.moveSlots > 0)
            {
                this.moveSlots--;
                dialogueSentence(this.pname + " uses " + this.bestMove + "(" + this.moveSlots + ")");
                

            }else{
                dialogueSentence(this.pname + " is out of moves...");
                //Trying to figure out how to return the MoveSet function
            }
            
            enemy.health -= attckDmg;
            if(enemy.health > 0)
            {
                dialogueSentence(enemy.pname + " lost " + this.attckDmg + " health.");
                dialogueSentence(enemy.pname + " now has " + enemy.health + " health.");
                
            }else{
                dialogueSentence(enemy.pname + " has died.");
                //dialogueSentence("Game Over.");
                return;
            }
        }

        public void Charge()
        {
            this.moveSlots++;
            dialogueSentence(this.pname + " added one " + this.bestMove + "(" + this.moveSlots + ")");
        }

        public void AddHealth()
        {
            int ahealth = health += 20;
            
            if(ahealth < maxHealth)
            {
                dialogueSentence(this.pname + " gains 20 health.");

                dialogueSentence(this.pname + " now has " + this.health + " health.");
            }

            if (ahealth >= maxHealth)
            {
                health = maxHealth;
                dialogueSentence("Your player has full health.");
            }   
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