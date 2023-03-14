using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Characters;
using UnityEngine;
//using DialogueManager;


namespace PokeReal
{
    public class Program : Person
    {
        public string nameofdialogue;

        bool _kai = false;
        bool _drake = false;
        bool _cr = false;
        bool _lj = false;

        Streamer kai = new Streamer("Kai Cenat", "ABUH", 75, 75, "streamer");
        List<Streamer> streamerList = new List<Streamer>();
        
        Soccer cr = new Soccer("Christiano Ronaldo", "SUIII", 50, 100, "Soccer Player");
        List<Soccer> soccerList = new List<Soccer>();
        
        Basketball lj = new Basketball("Lebron James", "SLAM DUNK", 25, 200, "Basketball Player");
        List<Basketball> basketballList = new List<Basketball>();
        
        Rapper drake = new Rapper("Drake", "CLB", 30, 175, "Rapper");
        List<Rapper> rapperList = new List<Rapper>();
    
        List<Person> enemyList = new List<Person>();
        

        public void Testing()
        {
            streamerList.Add(kai);
            soccerList.Add(cr);
            basketballList.Add(lj);
            rapperList.Add(drake);

            var random = new System.Random();

            enemyList.Add(kai);
            enemyList.Add(cr);
            enemyList.Add(lj);
            enemyList.Add(drake);

            //StartDialogue(dialogue1);
            Console.WriteLine("Welcome :)  \nChoose a player type... ");
            Console.WriteLine("1. Rapper \n2. Streamer \n3. Basketball \n4. Soccer");
            Console.WriteLine("Type the number of type to submit...");

            if(Input.GetKey("1"))
            {
                Console.WriteLine("Playable Characters: ");
                foreach(Person pers in streamerList)
                {  
                    Console.WriteLine(pData(pers));
                }
            }else if(Input.GetKey("2"))
            {
                Console.WriteLine("Playable Characters: ");
                foreach(Person pers in soccerList)
                {  
                    Console.WriteLine(pData(pers));
                }
            }else if(Input.GetKey("3"))
            {
                Console.WriteLine("Playable Characters: ");
                foreach(Person pers in basketballList)
                {  
                    Console.WriteLine(pData(pers));
                }
            }else if(Input.GetKey("4"))
            {
                Console.WriteLine("Playable Characters: ");
                foreach(Person pers in rapperList)
                {  
                    Console.WriteLine(pData(pers));
                }
            }
            

            Console.WriteLine("Type the number of the player you want to choose...");  
            if (Input.GetKey("1"))
            {
                _lj = true;
                Console.WriteLine(pData(lj));
                enemyList.Remove(lj);     
            }else if(Input.GetKey("2"))
            {
                _cr = true;
                Console.WriteLine(pData(cr));
                enemyList.Remove(cr);
            }else if(Input.GetKey("3"))
            {
                _kai = true;
                Console.WriteLine(pData(kai));
                enemyList.Remove(kai);
            }else if(Input.GetKey("4"))
            {
                _drake = true;
                Console.WriteLine(pData(drake));
                enemyList.Remove(drake);
            }
        

            var enemy = random.Next(enemyList.Count);
            var _enemy = enemyList[enemy];
            Console.WriteLine("A random player will be your enemy. Enemy cannot be the player you chose.");
            Console.WriteLine(pData(enemyList[enemy]));

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


        public void Testing1()
        {
            
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
                Console.WriteLine("Not a valid input.");
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
                Console.WriteLine("Not a valid input.");
                return false;
                
            }
        }

        public string pData(Person person)
        {
            return person.pname + "'s best move is " + person.bestMove + " and has " + person.health + " health.";
        }

        public bool GenInfo(Person person)
        {
            Console.WriteLine("It's " + this.pname + "'s turn...");
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

        public void HitPerson(Person person)
        {
            if (this.moveSlots > 0)
            {
                this.moveSlots--;
                Console.WriteLine(this.pname + " uses " + this.bestMove + "(" + this.moveSlots + ")");
                

            }else{
                Console.WriteLine(this.pname + " is out of moves...");
                //Trying to figure out how to return the MoveSet function
            } 
        }

        public void EnemyHit(Person enemy)
        {
            enemy.health -= attckDmg;
            if(enemy.health > 0)
            {
                Console.WriteLine(enemy.pname + " lost " + this.attckDmg + " health.");
                Console.WriteLine(enemy.pname + " now has " + enemy.health + " health.");
                
            }else{
                Console.WriteLine(enemy.pname + " has died.");
                //Console.WriteLine("Game Over.");
                return;
            }
        }

        public void Charge(Person person)
        {
            this.moveSlots++;
            Console.WriteLine(this.pname + " added one " + this.bestMove + "(" + this.moveSlots + ")");
        }

        public void AddHealth(Person person)
        {
            int ahealth = health += 20;
            
            if(ahealth < maxHealth)
            {
                Console.WriteLine(this.pname + " gains 20 health.");
                Console.WriteLine(this.pname + " now has " + this.health + " health.");
            }

            if (ahealth >= maxHealth)
            {
                health = maxHealth;
                Console.WriteLine("Your player has full health.");
            }   
        } 
    }
}   

           
    

