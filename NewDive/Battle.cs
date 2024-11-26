using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NewDive
{
    internal class Battle
    {
        public enum PlayerFrame
        {
            Default,
            Dead,
            GetDammeged,
            Attak,
            Heal
        }
        public enum EnemyFrame
        {
            Default,
            GetDammeged,
            Dead
        }

        Random rnd = new Random();

        GrafficController GFC = new GrafficController();
        NotificationWindow NF = new NotificationWindow();
        Player player;

        public Battle(Player Player) 
        {
            this.player = Player;
        }

        public int Record { get => player.LVL; }
        public void Begin()
        {
            var enemy = new Enemy();

            switch (rnd.Next(1, 6))
            {
                case 1: enemy = new Enemy.Fear("Fear", rnd.Next(1, 4) * 5); break;
                case 2: enemy = new Enemy.Mirror("Mirror", rnd.Next(1, 4) * 5); break;
                case 3: enemy = new Enemy.Shard("Shard", rnd.Next(1, 4) * 5); break;
                case 4: enemy = new Enemy.Emptyness("Void", rnd.Next(1, 4) * 5); break;
                case 5: enemy = new Enemy.Apaty("Apathy", rnd.Next(1, 4) * 5); break;
            }

            char[,] _bg = GFC.BG;
            char[,,] _playerUI = GFC.PlayerUI;

            while (enemy.IsAlive() && player.IsAlive())
            {
                Console.Clear();

                _bg = GFC.BG;
                _playerUI = GFC.PlayerUI;

                // UI
                GFC.AddToBuffer(_bg, _playerUI, 2, 18, 76, 7);
                GFC.AddToBuffer(_bg, player.Stats, 5, 20, 20, 3);
                GFC.AddToBuffer(_bg, player.WeaponIfno, 25, 20, 20, 3);
                GFC.AddToBuffer(_bg, player.GetWeaponIcon, 40, 20, 4, 3);
                GFC.AddToBuffer(_bg, player.AidIcon, 50, 20, 5, 3);
                GFC.AddToBuffer(_bg, player.Options, 60, 20, 10, 3);

                // Player
                GFC.AddToBuffer(_bg, player.ICON, 21, 9, player.W, player.H, (int)PlayerFrame.Default);
                GFC.AddToBuffer(_bg, player.HPBAR, 20, 16, player.HPBARW, 1);

                // Enemy
                GFC.AddToBuffer(_bg, enemy.ICON, 50, 4, enemy.W, enemy.H);
                GFC.AddToBuffer(_bg, enemy.NAME, 49, 11, enemy.NAMEW, 1);
                GFC.AddToBuffer(_bg, enemy.HPBAR, 49, 12, enemy.HPBARW, 1);
            
                // Drawing
                GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);

                switch (Console.ReadLine())
                {
                    case "1":
                        player.HP -= enemy.DMG;
                        enemy.HP -= (player.DMG + player.WeaponDMG);
                        player.DamageWeapon(1);

                        Console.Clear();
                        GFC.AddToBuffer(_bg, enemy.ICON, 50, 4, enemy.W, enemy.H, (int)EnemyFrame.GetDammeged);
                        GFC.AddToBuffer(_bg, player.ICON, 21, 9, player.W, player.H, (int)PlayerFrame.Attak);
                        GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);
                        Thread.Sleep(500);

                        Console.Clear();
                        GFC.AddToBuffer(_bg, enemy.ICON, 50, 4, enemy.W, enemy.H, (int)EnemyFrame.Default);
                        GFC.AddToBuffer(_bg, player.ICON, 21, 9, player.W, player.H, (int)PlayerFrame.Default);
                        GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);
                        Thread.Sleep(500);

                        Console.Clear();
                        GFC.AddToBuffer(_bg, player.ICON, 21, 9, player.W, player.H, (int)PlayerFrame.GetDammeged);
                        GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);
                        Thread.Sleep(500);
                        break;
                    case "2":
                        if (player.AidAmount > 0)
                        {
                            player.UseAid();

                            Console.Clear();
                            GFC.AddToBuffer(_bg, player.ICON, 21, 9, player.W, player.H, (int)PlayerFrame.Heal);
                            
                            GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);

                            Thread.Sleep(1000);

                        }
                        else
                        {
                            Console.Clear();

                            GFC.AddToBuffer(_bg, NF.Show("Mo more Aids left", player.NAME), 5, 2, NF.W, NF.H);
                            GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);

                            Console.ReadLine();
                        }
                        break;
                    default:
                        Console.Clear();

                        GFC.AddToBuffer(_bg, NF.Show("Unable to perform", player.NAME), 5, 2, NF.W, NF.H);
                        GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);

                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            }

            Console.Clear();
            GFC.AddToBuffer(_bg, enemy.ICON, 50, 4, enemy.W, enemy.H, (int)EnemyFrame.Dead);
            GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);
            Thread.Sleep(1000);

            if (!player.IsWeaponBroken)
            {
                player.AidAmount = 1;
                Console.Clear();

                GFC.AddToBuffer(_bg, NF.Show("I fount an Aid", player.NAME), 5, 2, NF.W, NF.H);
                GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);

                Console.ReadLine();
            }
            else
            {
                player.NewWeapon();
                Console.Clear();

                GFC.AddToBuffer(_bg, NF.Show("I pick up the new weapon", player.NAME), 5, 2, NF.W, NF.H);
                GFC.DrawAll(_bg, GFC.BG_W, GFC.BG_H);

                Console.ReadLine();

            }

            player.LVL += 1;
        }
    }
}
