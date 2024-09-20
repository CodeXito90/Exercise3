using static Exercise3.Animal;
using static Exercise3.UserError;

namespace Exercise3
{
    //privata variable(fält). är "privata", vilket betyder att vi inte kan komma åt dem direkt utifrån.
    //  vilket säkrar vår data
    class Person
    {

        private int age;
        private string fname;
        private string lname;
        private double height;
        private double weight;


        //dem hära publika "properties" låter oss läsa och sätta värden på de privata variablerna ovan. vi använder get och
        //set i properties för att arbeta med privata fält från utsidan av klassen, istället för att komma åt variablerna direkt  
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("ålder måste vara större än 0");
                }
                age = value;
            }

        }
        public string FName
        {
            get { return fname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("förnamn är obligatoriskt.");
                }

                if (value.Length < 2 || value.Length > 10)
                {
                    throw new ArgumentException("förnamnet måste vara mellan 2 och 10 tecken.");
                }
                fname = value;
            }
        }
        public string LName
        {
            get { return lname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("efternamn är obligatoriskt");
                }
                if (value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException("efternamn får inte vara mindre än 3 tecken eller större än 15 tecken.");
                }
                lname = value;
            }
        }
        public double Height { get { return height; } set { height = value; } }
        public double Weight { get { return weight; } set { weight = value; } }

    }

    class PersonHandler
    {
        public void SetAge(Person pers, int age)
        {
            //if (age <= 0)
            //{
            //    throw new ArgumentException("Ålder måste vara större än 0");
            //}
            pers.Age = age;
        }
        public Person CreatePerson(int age, string fname, string lname, double height, double weight)
        {
            return new Person
            {
                Age = age,
                FName = fname,
                LName = lname,
                Height = height,
                Weight = weight,
            };
        }

        //public int GetAge(Person pers) 
        //{
        //    return pers.Age;
        //}

        public void PrintInfo(Person pers)
        {
            Console.WriteLine($"Namn: {pers.FName} {pers.LName} Ålder: {pers.Age} ");
        }

    }

    internal class Program
    {
        static void Main(string[] args)

        {            

            //List<Dog> dogs = new List<Dog>();
            //{
            //    dogs.Add(new Dog("Lucky", 3, 38, "Rednose Pitbull"));
            //    dogs.Add(new Dog("Mick", 5, 32, "Husky"));
            //    dogs.Add(new Dog("Pringle", 2, 10, "Chiuahua"));

            //    //F: testa lägga till en häst i listan. Varför fungerar inte det?
            //    // F: Vilken typ måste listan vara för att alla klasser skall kunna lagras tillsammans?
            //    //dogs.Add(new Horse("choclate", 500, 5, 60));

            //    //För att det inte är av samma typ, även om dem ärver från Animal
            //    //klassen så är dem fortfarande av olika typer. För lagra andra djur 
            //    //måste listan vara av typ Animal
            //    foreach (var Animal in dogs)


            //    {
            //        Console.WriteLine(Animal.Stats());
            //    }
            //}

            List<Animal> animals = new List<Animal>();
            {
                animals.Add(new Wolf("shaggy", 9, 44, false));
                animals.Add(new Horse("Stalliano", 500, 5, 60));
                animals.Add(new Wolfman("Aplha", 4321, 103, true));
                animals.Add(new Dog("Lucky", 3, 38, "Rednose Pitbull"));

                animals.Add(new Hedgehog("Sonic", 1, 2, 5000));
                animals.Add(new Worm("LilWorm ", 1, 0.4, true));
                animals.Add(new Dog("Mick", 5, 32, "Husky"));
                animals.Add(new Flamingo("BrightWing", 1, 23, 15, "Blue And Red"));

                // F: Förklara vad det är som händer.
                foreach (var Animal in animals)
                {
                    // När vi kör animal.Stats() i en loop så kommer det korrekta stats() metoden anropas
                    // från våra basklasser och detta är pga av polimorfism. Exmple om animal = Dog, så körs stats()
                    // metoden i dog klassen inte animal
                    Console.WriteLine(Animal.Stats());

                    Animal.DoSound();

                    if (Animal is IPerson person)
                    {
                        person.Talk();
                    }                 
                                       
                }
                
                foreach (var animal in animals)
                {
                    //vår if sats för at kolla om det enbart hundar, sen skickar ut vår sträng i metoden
                    if (animal is Dog dog)
                    {
                        Console.WriteLine(dog.DogOnlyMethod());
                    }
                }


            }

            //List<UserError> userErrors = new List<UserError>
            //{
            //    new TextInputError(),
            //    new NumericInputError(),
            //    new NullError(),
            //    new EmptyFieldError(),
            //};

            //foreach (UserError error in userErrors) 
            //{
            //    Console.WriteLine(error.UEMessage());
            //}

            //try
            //{
            //    PersonHandler handler = new PersonHandler();

            //    Person person = handler.CreatePerson(34, "Apex", "Legends", 189, 85);
            //    Person person1 = handler.CreatePerson(24, "Alexandra", "Migos", 168, 59);

            //    Console.WriteLine($"Namn: \t{person.FName} {person.LName}");
            //    Console.WriteLine($"Ålder: \t{person.Age} år gammal");
            //    Console.WriteLine($"Längd: \t{person.Height} cm lång ");
            //    Console.WriteLine($"Vikt: \t{person.Weight} kg \n "); ;

            //    Console.WriteLine($"Namn: \t{person1.FName} {person1.LName}");
            //    Console.WriteLine($"Ålder: \t{person1.Age} år gammal");
            //    Console.WriteLine($"Längd: \t{person1.Height} cm lång ");
            //    Console.WriteLine($"Vikt: \t{person1.Weight} kg \n"); ;

            //    //Här demonstreras fall för ogiltiga undantags hantering, ex ålder kan inte vara mindre än 0
            //    Person ogiltigPerson = handler.CreatePerson(-15, "A", "olga", 189, 85);
            //}
            //catch (ArgumentException e) 
            //{
            //    Console.WriteLine($"Fel: {e.Message} ");
            //}        


            //try
            //{
            //    Person person = new Person();

            //    person.FName = "Jama";
            //    person.LName = "Abdi";
            //    person.Age = 34;
            //    person.Height = 190;
            //    person.Weight = 85;

            //    Console.WriteLine($"Namn: {person.FName} {person.LName}");
            //    Console.WriteLine($"Ålder: {person.Age} år gammal");
            //    Console.WriteLine($"Längd: {person.Height} cm lång ");
            //    Console.WriteLine($"Vikt: {person.Weight} kg ");
            //}
            //catch (ArgumentException e) 
            //{
            //    Console.WriteLine($"Fel: {e.Message}");
            //}

        }

        }

    }

