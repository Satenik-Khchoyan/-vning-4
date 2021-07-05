using System;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    /// <summary>
    /// 1. Stacken fungerar på så sätt att den som kommer sist hanteras först. Det är som pannkakor som ligger på varandra. Den sista äter vi först.
    /// Heapen däremot är en trädstruktur.Allt är tillgängligt på en gång med enkel åtkomst.Till exempel olika maträtter på bordet.Vi bestämmer vad vill vi ha och når den enkelt.
    /// 2. Value Types håller data inom sin egen minneaallokering. Value Types är typer från System.ValueType som t.ex. int, bool, struct, double mm.
    /// En Reference Type innehåller en pekare till en annan minnesplats som innehåller den verkliga datan. Reference Types är class, interface, object, delegate, string. De är typer som ärver från System.Object.
    /// 3. I den första exempel är x och y Value Types. Så när det står y = x och y = 4, då ändras värdet y men inte x.Vi jobbar med kopierna när vi jobbar med Value Types.
    /// I andra exemplet jobbar vi med Reference type. Då x och y pekar på samma ställe när det står y = x.Så när vi ändrar det värdet där y pekar mot, så ändras det värdet av x också.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>

        static bool isExit = false;

        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// Kapaciteten ökar automatisk när Count blir större. Kapaciteten ska alltid vara störe Count.
        /// Kapaciteten ökar dubbelt av sin värde.
        /// Kapaciteten visar hur mycket element List kan innehålla innan den behöver öka sin storlek.
        /// Count medan visar hur mycket element redan finns i listan.
        /// Därför ökar kapaciteten inte i samma takt som elements läggs till
        /// Kapaciteten minskar inte när element tas bort ur listan
        /// När vi har en kollektion med fixat storlek, då är det fördelaktigt att använda array istället för listan.
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */


            List<string> theList = new List<string>();

            do
            {
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"The capacity is: {theList.Capacity}.");
                        Console.WriteLine($"The count is: {theList.Count}");
                        break;

                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"The capacity is: {theList.Capacity}.");
                        Console.WriteLine($"The count is: {theList.Count}");
                        break;

                    case 'e':
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Use only + or -.");
                        break;
                }
            } while (!isExit);


        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> queue = new Queue<string>();
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Add":
                        string name = Console.ReadLine();
                        queue.Enqueue(name);
                        foreach (var item in queue)
                        {

                            Console.WriteLine(item);
                        }
                        break;
                    case "Remove":
                        queue.Dequeue();
                        foreach (var item in queue)
                        {

                            Console.WriteLine(item);
                        }
                        break;
                    case "e":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Please enter Add to enqueue or Remove to dequeue.");
                        break;
                }
            } while (!isExit);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// Om vi ska hantera Ica kön med Stack så ska det betyda att den som ställer sig i kön först kommer bli expedierad och lämna kön sist.
        /// Det är förstås inte så smart, så stack är inte en passande struktur att använda i sådana fall.
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Stack<char> userMessage = new Stack<char>();
            do
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "Push":
                        string text = Console.ReadLine();
                        foreach (var item in text)
                        {
                            userMessage.Push(item);
                        }

                        break;
                    case "Pop":
                        while (userMessage.Count != 0)
                        {
                            char outText = userMessage.Pop();
                            Console.Write(outText + " ");
                        }


                        break;
                    case "e":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Please enter Push or Pop or e to exit.");
                        break;
                }

            } while (!isExit);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            string userInput = Console.ReadLine();
            bool isCorrect = false;
            char[] inputArray = userInput.ToCharArray();
            List<char> parenthesisList = new List<char>();
            int count;
            foreach (var item in inputArray)
            {
                if (item.Equals('{') || item.Equals('}') || item.Equals('[') || item.Equals(']') || item.Equals('(')
                    || item.Equals(')'))
                {
                    parenthesisList.Add(item);
                }
            }
            count = parenthesisList.Count;
            while (!isCorrect)
            {
                for (int i = 0; i < parenthesisList.Count-1; )
                {
                    if ((parenthesisList[i].Equals('{') && parenthesisList[i + 1].Equals('}')) ||
                        (parenthesisList[i].Equals('(') && parenthesisList[i + 1].Equals(')')) ||
                        (parenthesisList[i].Equals('[') && parenthesisList[i + 1].Equals(']')))
                    {
                        parenthesisList.Remove(parenthesisList[i]);
                        parenthesisList.Remove(parenthesisList[i]);
                        i = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
                
                    count = parenthesisList.Count;
                    isCorrect = true;
                
            }
            if(count.Equals(0))
            {
                Console.WriteLine("Parenthesis in the string are correct.");
            }
            else
            {
                Console.WriteLine("Parenthesis in the string are not correct.");
            }

        }

    }
}

