using Museum.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Services
{
    public class CheckIntService : ICheckIntService
    {
        public int NumberCheck(string message)
        {
            string choise;
            int number = 0;
            while (true)
            {
                Console.WriteLine(message);
                choise = Console.ReadLine();
                if (Int32.TryParse(choise, out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("//|Wrong input!|\\\\");
                }
            }
        }
    }
}
