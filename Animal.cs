using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    abstract class Animal
    {
        //Key notes:
        //If we want to access these properties in the derived classes (such as Horse, Dog, etc.)
        //through the base.Stats() method, we need to make them protected or public. private wont give us access later on!
        protected string Name { get; set; }
        protected int Age { get; set; }
        protected double Weight { get; set; }

        public Animal(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }

        public abstract void DoSound();

        public virtual string Stats()
        {
            return $"Name: {Name}, Age: {Age}, Weight: {Weight}";
        }

        // Horse class som ärver från Animal 
        public class Horse : Animal
        {
            public double HorsePower { get; set; }

            // Vår konstruktor
            public Horse(string name, int age, double weight, double horsePower)
                : base(name, age, weight)//Keynotes:
                                         //make sure there is no Inconsistent Property Order in Constructor
                                         //the order of the parameters should always match the base class of Animal
            {
                HorsePower = horsePower;
            }

            public override void DoSound()
            {
                Console.WriteLine("The horse neighs.");
            }

            public override string Stats()
            {
                return base.Stats() + $", HorsePower: {HorsePower}\n";
            }
        }

        // Dog
        public class Dog : Animal
        {
            public string Breed { get; set; }// unik egenskap för hundar            
            public Dog(string name, int age, double weight, string breed)
                : base(name, age, weight)
            {
                Breed = breed;
            }

            public override void DoSound()
            {
                Console.WriteLine("The dog barks.");
            }

            public override string Stats()
            {
                return base.Stats() + $", Breed: {Breed}\n";
            }

            //metod för att returnera bara sträng, 
            //Kommer du åt den metoden från Animals listan?
            //F: Varför inte
            public string DogOnlyMethod() 
            {
                return "Detta är bara för hundar.";
            }

            // vi kommer inte åt den i animals listan för att vår metod är inte 
            // tillgänglig i vår basklass för animals
        }

        // Hedgehog
        public class Hedgehog : Animal
        {
            public int NrOfSpikes { get; set; }

            public Hedgehog(string name, int age, double weight, int nrOfSpikes)
                : base(name, age, weight)//Important keynote: <-- Don't add NrOfspikes Into base class 
                                         //Be consistent with the parameter order when calling the base constructor
            {
                NrOfSpikes = nrOfSpikes;
            }

            public override void DoSound()
            {
                Console.WriteLine("The hedgehog squeaks!");
            }

            public override string Stats()
            {
                return base.Stats() + $", Spikes: {NrOfSpikes}\n";
            }
        }

        // Worm
        public class Worm : Animal
        {
            public bool IsPoisonous { get; set; }

            public Worm(string name, int age, double weight, bool isPoisonous)
                : base(name, age, weight)
            {
                IsPoisonous = isPoisonous;
            }

            public override void DoSound()
            {
                Console.WriteLine("The worm's poison sizzles the ground.");
            }

            public override string Stats()
            {
                return base.Stats() + $", IsPoisonous: {IsPoisonous}\n";
            }
        }

        // Bird
        public class Bird : Animal
        {
            public double WingSpan { get; set; }

            public Bird(string name, int age, double weight, double wingSpan)
                : base(name, age, weight)
            {
                WingSpan = wingSpan;
            }

            public override void DoSound()
            {
                Console.WriteLine("The bird sings.");
            }

            public override string Stats()
            {
                return base.Stats() + $", WingSpan: {WingSpan}\n";
            }
        }

        // Wolf
        public class Wolf : Animal
        {
            public bool IsWereWolf { get; set; }  // Clear representation for both Wolf and Wolfman

            public Wolf(string name, int age, double weight, bool isWereWolf)
                : base(name, age, weight)
            {
                IsWereWolf = isWereWolf;
            }

            //If statement to check if the wolf is werewolf, if false it only howls, if true then 
            public override void DoSound()
            {
                if (IsWereWolf == false) 
                {
                    Console.WriteLine("The wolf howls.");
                }
                
               
            }
            public override string Stats()
            {
                return base.Stats() + $", IsWereWolf: {IsWereWolf}\n";
            }
        }


        // Pelican
        public class Pelican : Bird
        {
            public double BillSize { get; set; }

            public Pelican(string name, int age, double weight, double billSize, double wingSpan)
                : base(name, age, weight, wingSpan)
            {
                BillSize = billSize;
            }

            public override string Stats()
            {
                return base.Stats() + $"BillSize: {BillSize}\n";
            }
        }

        // Flamingo
        public class Flamingo : Bird
        {
            public string ColorOnFeathers { get; set; }

            public Flamingo(string name, int age, double weight, double wingSpan, string colorOnFeathers)
                : base(name, age, weight, wingSpan)
            {
                ColorOnFeathers = colorOnFeathers;
            }

            public override string Stats()
            {
                return base.Stats() + $"Feather Color: {ColorOnFeathers}\n";
            }
        }
                
        public interface IPerson
        {
            void Talk();
        }

        // Wolfman
        public class Wolfman : Wolf, IPerson
        {
            //bool property IsWereWolf is inherited from wolf class
            public Wolfman(string name, int age, double weight, bool isWereWolf)
                : base(name, age, weight, isWereWolf)
            {
               
            }

            public void Talk()
            {
                Console.WriteLine("The wolfman is shouting: Run!");
            }
        }
    //F1... För att lägga till nya attribut för fåglar så gör man det i Bird klassen
    //F2... Om alla djur behöver ny atribut så lägger man till det i Animal klassen.

    }


}

