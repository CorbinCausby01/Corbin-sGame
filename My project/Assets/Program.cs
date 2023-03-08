using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Characters;
using UnityEngine;
using DialogueManager;


namespace PokeReal
{
    public class Program : Person
    {
        public string nameofdialogue;

        private void Start()
        {
            bool _kai = false;
            bool _drake = false;
            bool _cr = false;
            bool _lj = false;

            //COnstructor
            Streamer kai = new Streamer("Kai Cenat", "ABUH", 75, 75, "streamer");
            List<Streamer> streamerList = new List<Streamer>();
            streamerList.Add(kai);

            Soccer cr = new Soccer("Christiano Ronaldo", "SUIII", 50, 100, "Soccer Player");
            List<Soccer> soccerList = new List<Soccer>();
            soccerList.Add(cr);


            Basketball lj = new Basketball("Lebron James", "SLAM DUNK", 25, 200, "Basketball Player");
            List<Basketball> basketballList = new List<Basketball>();
            basketballList.Add(lj);


            Rapper drake = new Rapper("Drake", "CLB", 30, 175, "Rapper");
            List<Rapper> rapperList = new List<Rapper>();
            rapperList.Add(drake);

            var random = new System.Random();
            List<Person> enemyList = new List<Person>();
            enemyList.Add(kai);
            enemyList.Add(cr);
            enemyList.Add(lj);
            enemyList.Add(drake);

            
            //StartDialogue(dialogue1);
            FindObjectOfType<Person>().dialogueSentence("Welcome :)  \nChoose a player type... ");
            FindObjectOfType<Person>().dialogueSentence("1. Rapper \n2. Streamer \n3. Basketball \n4. Soccer");
            FindObjectOfType<Person>().dialogueSentence("Type the number of type to submit...");

            if(Input.GetKey("1"))
            {
                FindObjectOfType<Person>().dialogueSentence("Playable Characters: ");
                foreach(Person pers in streamerList)
                {  
                    FindObjectOfType<Person>().dialogueSentence(pData(pers));
                }
            }else if(Input.GetKey("2"))
            {
                FindObjectOfType<Person>().dialogueSentence("Playable Characters: ");
                foreach(Person pers in soccerList)
                {  
                    FindObjectOfType<Person>().dialogueSentence(pData(pers));
                }
            }else if(Input.GetKey("3"))
            {
                FindObjectOfType<Person>().dialogueSentence("Playable Characters: ");
                foreach(Person pers in basketballList)
                {  
                    FindObjectOfType<Person>().dialogueSentence(pData(pers));
                }
            }else if(Input.GetKey("4"))
            {
                FindObjectOfType<Person>().dialogueSentence("Playable Characters: ");
                foreach(Person pers in rapperList)
                {  
                    FindObjectOfType<Person>().dialogueSentence(pData(pers));
                }
            }
            

            FindObjectOfType<Person>().dialogueSentence("Type the number of the player you want to choose...");  
            if (Input.GetKey("1"))
            {
                _lj = true;
                FindObjectOfType<Person>().dialogueSentence(pData(lj));
                enemyList.Remove(lj);     
            }else if(Input.GetKey("2"))
            {
                _cr = true;
                FindObjectOfType<Person>().dialogueSentence(pData(cr));
                enemyList.Remove(cr);
            }else if(Input.GetKey("3"))
            {
                _kai = true;
                FindObjectOfType<Person>().dialogueSentence(pData(kai));
                enemyList.Remove(kai);
            }else if(Input.GetKey("4"))
            {
                _drake = true;
                FindObjectOfType<Person>().dialogueSentence(pData(drake));
                enemyList.Remove(drake);
            }
        

            var enemy = random.Next(enemyList.Count);
            var _enemy = enemyList[enemy];
            FindObjectOfType<Person>().dialogueSentence("--------------");
            FindObjectOfType<Person>().dialogueSentence("A random player will be your enemy. Enemy cannot be the player you chose.");
            FindObjectOfType<Person>().dialogueSentence(pData(enemyList[enemy]));
            FindObjectOfType<Person>().dialogueSentence("--------------");

            while(lj.health > 0 && cr.health > 0 && kai.health > 0 && drake.health > 0 && _enemy.health > 0)
            {
                if(_lj == true)
                {
                    bool validMoveMade = false;
                    while(!validMoveMade)
                    {
                        validMoveMade = MoveSet(lj , _enemy); 
                    }

                    validMoveMade = false;
                    while(!validMoveMade)
                    {
                        validMoveMade = MoveSet(_enemy, lj);
                    }
                        

                }
                if(_cr == true)
                {
                    bool validMoveMade = false;
                    while(!validMoveMade)
                    {
                        validMoveMade = MoveSet(cr , _enemy);
                            
                    }

                    validMoveMade = false;
                    while(!validMoveMade)
                    {
                        validMoveMade = MoveSet(_enemy, cr);
                    }

                }
                if(_kai == true)
                {
                    bool validMoveMade = false;
                    while(!validMoveMade)
                    {
                        validMoveMade = MoveSet(kai , _enemy);
                            
                    }

                    validMoveMade = false;
                    while(!validMoveMade)
                    {
                        validMoveMade = MoveSet(_enemy, kai);
                    }
                }
                if(_drake == true)
                {
                    bool validMoveMade = false;
                    while(!validMoveMade)
                    {
                        validMoveMade = MoveSet(drake , _enemy);
                            
                    }

                    validMoveMade = false;
                    while(!validMoveMade)
                    {
                        validMoveMade = MoveSet(_enemy, drake);
                    }
                }
            }
        }

        bool MoveSet(Person p, Person enemy)
        {
            if(p.health <= 0 || enemy.health <= 0)
            {
                return false;
            }
                
            bool validInput = false;
            if(!validInput)
            {
                validInput = GenInfo(p);
            }
                
                
            if(Input.GetKey("q") && validInput)
            {
                    
                HitPerson(p);
                EnemyHit(enemy);
                return true;
            }
            else if(Input.GetKey("q") && !validInput)
            {
                FindObjectOfType<Person>().dialogueSentence("Not a valid input.");
                return false;
            }
            else if(Input.GetKey("w"))
            {
                Charge(p);
                return true;
            }
            else if(Input.GetKey("e"))
            {
                AddHealth(p);
                return true;
            }
            else
            {
                FindObjectOfType<Person>().dialogueSentence("Not a valid input.");
                return false;
                
            }
        }

        public string pData(Person person)
        {
            return person.pname + "'s best move is " + person.bestMove + " and has " + person.health + " health.";
        }

        public bool GenInfo(Person person)
        {
            FindObjectOfType<Person>().dialogueSentence("It's " + this.pname + "'s turn...");
            FindObjectOfType<Person>().dialogueSentence("Press E to heal.");
            FindObjectOfType<Person>().dialogueSentence("Press W to charge.");
            if(this.moveSlots > 0)
            {
                FindObjectOfType<Person>().dialogueSentence("Press Q to use " + this.bestMove + "(" + this.moveSlots + ")");
                return true;
            }
            else
            {
                FindObjectOfType<Person>().dialogueSentence("Cannot attack, " + this.bestMove + "(" + this.moveSlots + ")");
                return false;
            }
        }

        public void HitPerson(Person person)
        {
            if (this.moveSlots > 0)
            {
                this.moveSlots--;
                FindObjectOfType<Person>().dialogueSentence(this.pname + " uses " + this.bestMove + "(" + this.moveSlots + ")");
                

            }else{
                FindObjectOfType<Person>().dialogueSentence(this.pname + " is out of moves...");
                //Trying to figure out how to return the MoveSet function
            } 
        }

        public void EnemyHit(Person enemy)
        {
            enemy.health -= attckDmg;
            if(enemy.health > 0)
            {
                FindObjectOfType<Person>().dialogueSentence(enemy.pname + " lost " + this.attckDmg + " health.");
                FindObjectOfType<Person>().dialogueSentence(enemy.pname + " now has " + enemy.health + " health.");
                
            }else{
                FindObjectOfType<Person>().dialogueSentence(enemy.pname + " has died.");
                //FindObjectOfType<Person>().dialogueSentence("Game Over.");
                return;
            }
        }

        public void Charge(Person person)
        {
            this.moveSlots++;
            FindObjectOfType<Person>().dialogueSentence(this.pname + " added one " + this.bestMove + "(" + this.moveSlots + ")");
        }

        public void AddHealth(Person person)
        {
            int ahealth = health += 20;
            
            if(ahealth < maxHealth)
            {
                FindObjectOfType<Person>().dialogueSentence(this.pname + " gains 20 health.");

                FindObjectOfType<Person>().dialogueSentence(this.pname + " now has " + this.health + " health.");
            }

            if (ahealth >= maxHealth)
            {
                health = maxHealth;
                FindObjectOfType<Person>().dialogueSentence("Your player has full health.");
            }   
        } 
    }
}   

           
    

