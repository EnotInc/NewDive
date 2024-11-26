using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int record = -1;
            
            while (true)
            {
                Game game = new Game();
                
                Console.Clear();

                game.intro(record);
                record = game.Start();
            }
        }
    }
}
