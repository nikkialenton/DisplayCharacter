using System;
using System.Collections.Generic;
using System.Text;
using TestProgramApp.Data;

namespace TestProgramApp.Processing
{
    public class Process_Y : IInputProcessor
    {
        public string[,] ProcessInput(InputInfo inputInfo)
        {
            int size = inputInfo.size;

            string[,] array = new string[size, size];

            int left = (int)Math.Ceiling(Convert.ToDouble(size) / 2);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((i == j && i < left) || (j == (size - 1) - i))
                        array[i, j] = "*";
                    else
                        array[i, j] = " ";
                }
            }

            return array;
        }
    }
}

