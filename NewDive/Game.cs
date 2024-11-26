using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NewDive
{
    internal class Game
    {
        GrafficController GFC = new GrafficController();
        NotificationWindow NF = new NotificationWindow();
        Player player;

        public void intro(int record = -1)
        {
            Console.WriteLine("*Unknown*\n -Enter the name if your model");
            player = new Player(Console.ReadLine());
            if (record == -1)
            {
                Console.WriteLine("*Unknown*\n Good luck in your first Dive");
            }
            else
            {
                Console.WriteLine($"*Unknown*\n Last time you manage to get to lvl {record}\n Good luck in your new Dive");
            }
            Console.Read();
            Console.CursorVisible = false;

            Console.Clear();
        }
        public int Start()
        {
            Battle battle = new Battle(player);

            while (player.IsAlive())
            {
                battle.Begin();
            }

            Console.Clear();
            char[,] _bg = GFC.BG;

            GFC.AddToBuffer(_bg, player.ICON, 21, 9, player.W, player.H, 2);
            GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);
            Thread.Sleep(1500);

            Console.Clear();
            GFC.AddToBuffer(_bg, player.ICON, 21, 9, player.W, player.H, 1);
            GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);
            Thread.Sleep(1500);

            Console.Clear();

            GFC.AddToBuffer(_bg, NF.Show("You died"), 5, 2, NF.W, NF.H);
            GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);

            Console.ReadLine();

            return battle.Record;
        }
    }
}
