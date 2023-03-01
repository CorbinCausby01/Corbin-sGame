using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Characters;
using UnityEngine;
using DialogueManager;


namespace PokeReal
{
    [System.Serializable]
    public class Program : Person
    {
        void Main(string[] args)
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
            dialogueSentence("Welcome :)  \nChoose a player type... ");
            dialogueSentence("1. Rapper \n2. Streamer \n3. Basketball \n4. Soccer");
            dialogueSentence("Type the number of type to submit...");

            if(Input.GetKey("1"))
            {
                dialogueSentence("Playable Characters: ");
                foreach(Person pers in streamerList)
                {  
                    dialogueSentence(pers.pData());
                }
            }else if(Input.GetKey("2"))
            {
                dialogueSentence("Playable Characters: ");
                foreach(Person pers in soccerList)
                {  
                    dialogueSentence(pers.pData());
                }
            }else if(Input.GetKey("3"))
            {
                dialogueSentence("Playable Characters: ");
                foreach(Person pers in basketballList)
                {  
                    dialogueSentence(pers.pData());
                }
            }else if(Input.GetKey("4"))
            {
                dialogueSentence("Playable Characters: ");
                foreach(Person pers in rapperList)
                {  
                    dialogueSentence(pers.pData());
                }
            }
            

            dialogueSentence("Type the number of the player you want to choose...");  
            if (Input.GetKey("1"))
            {
                _lj = true;
                dialogueSentence(lj.pData());
                enemyList.Remove(lj);     
            }else if(Input.GetKey("2"))
            {
                _cr = true;
                dialogueSentence(cr.pData());
                enemyList.Remove(cr);
            }else if(Input.GetKey("3"))
            {
                _kai = true;
                dialogueSentence(kai.pData());
                enemyList.Remove(kai);
            }else if(Input.GetKey("4"))
            {
                _drake = true;
                dialogueSentence(drake.pData());
                enemyList.Remove(drake);
            }
        

            var enemy = random.Next(enemyList.Count);
            var _enemy = enemyList[enemy];
            dialogueSentence("--------------");
            dialogueSentence("A random player will be your enemy. Enemy cannot be the player you chose.");
            dialogueSentence(enemyList[enemy].pData());
            dialogueSentence("--------------");

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

        bool MoveSet(Person p, Person enemy1)
        {
            if(p.health <= 0 || enemy1.health <= 0)
            {
                return false;
            }
                
            bool validInput = false;
            if(!validInput)
            {
                validInput = p.GenInfo();
            }
                
                
            if(Input.GetKey("q") && validInput)
            {
                    
                p.HitPerson(enemy1);
                return true;
            }
            else if(Input.GetKey("q") && !validInput)
            {
                dialogueSentence("Not a valid input.");
                return false;
            }
            else if(Input.GetKey("w"))
            {
                p.Charge();
                return true;
            }
            else if(Input.GetKey("e"))
            {
                p.AddHealth();
                return true;
            }
            else
            {
                dialogueSentence("Not a valid input.");
                return false;
                
            }
        }
    }
}   

           
    

