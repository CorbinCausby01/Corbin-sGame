using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using DialogueManager;



namespace Characters
{
    
    public class Person : MonoBehaviour 
    {

        public string name;
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
            FindObjectOfType<DialogueManger>().AddSentenceToQueue();
        }
        public string pData()
        {
            return this.name + "'s best move is " + this.bestMove + " and has " + this.health + " health.";
        }

        public bool GenInfo()
        {
            Console.WriteLine("It's " + this.name + "'s turn...");
            Console.WriteLine("Press E to heal.");
            Console.WriteLine("Press W to charge.");
            if(this.moveSlots > 0)
            {
                Console.WriteLine("Press Q to use " + this.bestMove + "(" + this.moveSlots + ")");
                return true;
            }
            else
            {
                Console.WriteLine("Cannot attack, " + this.bestMove + "(" + this.moveSlots + ")");
                return false;
            }
        }

        public void HitPerson(Person enemy)
        {
            if (this.moveSlots > 0)
            {
                this.moveSlots--;
                Console.WriteLine(this.name + " uses " + this.bestMove + "(" + this.moveSlots + ")");
                

            }else{
                Console.WriteLine(this.name + " is out of moves...");
                //Trying to figure out how to return the MoveSet function
            }
            
            enemy.health -= attckDmg;
            if(enemy.health > 0)
            {
                Console.WriteLine(enemy.name + " lost " + this.attckDmg + " health.");
                Console.WriteLine(enemy.name + " now has " + enemy.health + " health.");
                
            }else{
                Console.WriteLine(enemy.name + " has died.");
                //Console.WriteLine("Game Over.");
                return;
            }
        }

        public void Charge()
        {
            this.moveSlots++;
            Console.WriteLine(this.name + " added one " + this.bestMove + "(" + this.moveSlots + ")");
        }

        public void AddHealth()
        {
            int ahealth = health += 20;
            
            if(ahealth < maxHealth)
            {
                Console.WriteLine(this.name + " gains 20 health.");

                Console.WriteLine(this.name + " now has " + this.health + " health.");
            }

            if (ahealth >= maxHealth)
            {
                health = maxHealth;
                Console.WriteLine("Your player has full health.");
            }   
        } 

    }
    public class Streamer : Person
    {
        public Streamer(string _name, string _bestMove, int _attckDmg, int _health, string _type)
        {
            name = _name;
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

        public Soccer(string _name, string _bestMove, int _attckDmg, int _health, string _type)
        {
            name = _name;
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
        public Basketball(string _name, string _bestMove, int _attckDmg, int _health, string _type)
        {
            name = _name;
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
        public Rapper(string _name, string _bestMove, int _attckDmg, int _health, string _type)
        {
            name = _name;
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