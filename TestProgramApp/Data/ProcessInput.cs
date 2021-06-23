using System;
using System.Collections.Generic;
using System.Text;

namespace TestProgramApp.Data
{
    public enum charToDisplay
    {
        O,
        X,
        Y,
        Z,
        Unsupported
    }

    public interface IInputProcessor
    {
        string[,] ProcessInput(InputInfo inputInfo);
    }


    public class ProcessInput
    {
        public IInputProcessor Processor { get; set; }
        public string[,] Process(InputInfo inputInfo)
        {
            return Processor.ProcessInput(inputInfo);
        }
        public bool IsValidInfo(string letter, string number)
        {
            //check if X,Y,O,Z
            if (!Enum.TryParse(letter.ToUpper(), out charToDisplay letterDisp))
                return false;

            //check if odd and positive
            if (!Int32.TryParse(number, out int odd))
                return false;

            if (odd % 2 == 0)
                return false;

            if (odd < 0)
                return false;

            return true;
        }

        public void DisplayCharacter(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                }

                Console.WriteLine();
            }
        }

    }
}
