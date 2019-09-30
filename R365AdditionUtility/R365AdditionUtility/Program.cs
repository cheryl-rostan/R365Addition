using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R365AdditionUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            AddEvaluator addEvaluator = new AddEvaluator();
            do
            {
                Console.WriteLine("Please enter the value of 1-8 for the requirement you are testing.");
                while (!Console.KeyAvailable)
                {
                    //Waiting
                }

                try
                {
                    var k = Console.ReadKey(true);
                    switch (k.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Console.WriteLine("Please enter the items to add for Requirement 1.");
                            var inputValuesEx1 = Console.ReadLine();
                            addEvaluator.RequirementOne(inputValuesEx1);
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Console.WriteLine("Please enter the items to add for Requirement 2.");
                            var inputValuesEx2 = Console.ReadLine();
                            addEvaluator.RequirementTwo(inputValuesEx2);
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Console.WriteLine("Please enter the items to add for Requirement 3.");
                            var inputValuesEx3 = Console.ReadLine();
                            addEvaluator.RequirementThree(inputValuesEx3);
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Console.WriteLine("Please enter the items to add for Requirement 4.");
                            var inputValuesEx4 = Console.ReadLine();
                            addEvaluator.RequirementFour(inputValuesEx4);
                            break;
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            Console.WriteLine("Please enter the items to add for Requirement 5.");
                            var inputValuesEx5 = Console.ReadLine();
                            addEvaluator.RequirementFive(inputValuesEx5);
                            break;
                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:
                            Console.WriteLine("Please enter the items to add for Requirement 6.");
                            var inputValuesEx6 = Console.ReadLine();
                            addEvaluator.RequirementSix(inputValuesEx6);
                            break;
                        case ConsoleKey.D7:
                        case ConsoleKey.NumPad7:
                            Console.WriteLine("Please enter the items to add for Requirement 7.");
                            var inputValuesEx7 = Console.ReadLine();
                            addEvaluator.RequirementSeven(inputValuesEx7);
                            break;
                        case ConsoleKey.D8:
                        case ConsoleKey.NumPad8:
                            Console.WriteLine("Please enter the items to add for Requirement 8.");
                            var inputValuesEx8 = Console.ReadLine();
                            addEvaluator.RequirementEight(inputValuesEx8);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    //Do nothing
                }
            } while (true);
        }

    }
}
