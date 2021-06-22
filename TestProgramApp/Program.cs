using System;
using TestProgramApp.Data;
using TestProgramApp.Processing;

namespace TestProgramApp
{
    class Program
    {       
        static void Main(string[] args)
        {            
            ProcessInput processInput = new ProcessInput();
            InputInfo inputInfo = new InputInfo();
            bool inputAgain = true;
            string letter, number;
            do
            {
                Console.Clear();

                GetInput(out letter, out number);

                if (!processInput.IsValidInfo(letter, number))
                {
                    Console.WriteLine("Invalid Input Found.");
                    AskUser();
                }
                else
                {
                    inputInfo.letterChar = letter;
                    inputInfo.size = Convert.ToInt32(number);

                    GenerateInputProcessor(inputInfo, processInput);

                    processInput.DisplayCharacter(processInput.Process(inputInfo));

                    inputAgain = AskUser();
                }               

            } while (inputAgain);            
        }

        private static void GenerateInputProcessor(InputInfo inputInfo, ProcessInput processInput)
        {
            if (Enum.TryParse(inputInfo.letterChar.ToUpper(), out charToDisplay letterDisp))
            {
                switch (letterDisp)
                {
                    case charToDisplay.O:
                        processInput.Processor = new Process_O();
                        break;
                    case charToDisplay.X:
                        processInput.Processor = new Process_X();
                        break;
                    case charToDisplay.Y:
                        processInput.Processor = new Process_Y();
                        break;
                    case charToDisplay.Z:
                        processInput.Processor = new Process_Z();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void GetInput(out string letter, out string number)
        {
            Console.Write("Enter a character [O, X, Y, Z]: ");
            letter = Console.ReadLine();

            Console.WriteLine("");

            Console.Write("Enter a non-negative odd integer: ");
            number = Console.ReadLine();
            
            Console.WriteLine();
        }

        private static bool AskUser()
        {

            Console.Write("Would you like to try again (Y/N) ? : ");
            var answer = Console.ReadLine();

            return (answer.ToUpper() == "Y");
        }

    }
}
