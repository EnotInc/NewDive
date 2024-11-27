using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDive
{
    internal class Player
    {
        Random rnd = new Random();
        Weapon weapon = new Weapon();
        Aid aid = new Aid();

        private int _wight = 5;
        private int _height = 6;
        private char[,,] WeaponIcon = new char[1, 3, 4];
        private readonly char[,,] icon = 
        {{ // Frame 1 - Alive 
            {' ',' ','_',' ',' ',},
            {' ','(','?',')',' ',},
            {'|','@','@','@','|',},
            {'!','@','@','@','!',},
            {' ','I',' ','I',' ',},
            {'.','I',' ','I','.',},
        },{ // Frame 2 - Dead
            {' ',' ',' ',' ',' ',},
            {' ',' ',' ',' ',' ',},
            {' ',' ',' ',' ',' ',},
            {' ',' ',' ','_',' ',},
            {'.','_','/','#','\\',},
            {'/','#','@','#','X',},
        },{ // Frame 3 - Get Damaged
            {' ',' ','_',' ',' ',},
            {' ','(','?',')','/',},
            {'|','@','@','/','|',},
            {'!','@','/','@','!',},
            {' ','/',' ','I',' ',},
            {'/','I',' ','I','.',},
        },{ // Frame 4 - Attack 
            {' ',' ','_',' ','.',},
            {' ','(','?',')','|',},
            {'|','@','@','@','|',},
            {'!','@','@','@',' ',},
            {' ','I',' ','I',' ',},
            {'.','I',' ','I','.',},
        },{ // Frame 4 - Heal
            {' ','+','_',' ','+',},
            {' ','(','?',')',' ',},
            {'|','@','@','@','|',},
            {'!','@','@','@','!',},
            {'+','I',' ','I',' ',},
            {'.','I','+','I','+',},
}};
        private string hpBar;
        public char[,,] ICON { get => icon; }
        public int W { get => _wight; }
        public int H { get => _height; }

        private string _name;
        private int _hp;
        private int _hpMax;
        private int _dmg;
        private int _lvl;
        public Player(string Name)
        {
            this._name = Name; 
            this._hp = 100;
            this._hpMax = this._hp;
            this._dmg = 20;
            this._lvl = 1;

        }
        public int HP { get => this._hp; set => this._hp = value; }
        public int HPMAX { get => this._hpMax; }
        public int LVL { get => this._lvl; set => this._lvl = value; }
        public int DMG { get => this._dmg; set => this._dmg = value; }
        public string NAME { get => this._name; }
        
        public bool IsAlive()
        {
            if (this._hp > 0) { return true; }
            else { return false; }
        }

        // PLayer UI
        public char[,,] Stats
        {
            get
            {
                string Name = $"Model: {this._name}";
                string Dmg = $"Damage: {this._dmg}";
                string Lvl = $"Level: {this._lvl}";


                char[,,] buffer = new char[1, 3, 20];

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        buffer[0, i, j] = ' ';
                    }
                }

                int l = 0;

                foreach (char c in Name)
                {
                    buffer[0, 0, l] = c;
                    l++;
                }
                l = 0;
                foreach (char c in Dmg)
                {
                    buffer[0, 1, l] = c;
                    l++;
                }
                l = 0;

                foreach (char c in Lvl)
                {
                    buffer[0, 2, l] = c;
                    l++;
                }

                return buffer;
            }
        }
        public int HPBARW { get => hpBar.Length; }
        private void hpBarUpdate()
        {
            hpBar = $"{this._hp}/{this._hpMax}";
        }
        public char[,,] HPBAR
        {
            get
            {
                hpBarUpdate();

                char[,,] buffer = new char[1, 1, hpBar.Length];

                int i = 0;
                
                foreach (char c in hpBar)
                {
                    buffer[0, 0, i] = c;
                    i++;
                }

                return buffer;
            }
        }
        public char[,,] Options
        {
            get
            {
                char[,,] buffer = new char[1, 3, 10];

                string OptionOne = "1. Fight";
                string OptionTwo = "2. Use Aid";
                string AmountOfAid = $"Left:{aid.Amount}";

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        buffer[0, i, j] = ' ';
                    }
                }

                int l = 0;
                foreach(char c in OptionOne)
                {
                    buffer[0, 0, l] = c;
                    l++;
                }
                l = 0;
                foreach (char c in OptionTwo)
                {
                    buffer[0, 1, l] = c;
                    l++;
                }
                l = 0;
                foreach (char c in AmountOfAid)
                {
                    buffer[0, 2
                        , l] = c;
                    l++;
                }
                return buffer;
            }
        }

        // Weapon
        public bool IsWeaponBroken { get => weapon.IsBorken(); }
        public int WeaponDMG { get => weapon.DMG; }
        public void DamageWeapon(int damage)
        { 
            weapon.Durability = damage;
            if (weapon.IsBorken())
            {
                weapon = new Weapon();
            }
        }
        public char[,,] GetWeaponIcon
        {
            get
            {
                WeaponIcon = weapon.ICON;
                return WeaponIcon;
            }
        }
        public char[,,] WeaponIfno
        {
            get
            {
                char[,,] buffer = new char[1, 3, 20];
                string WeaponName = $"Weapon: {weapon.NAME}";
                string Damage = $"Damage: {weapon.DMG}";
                string Durability = $"Drability: {weapon.Durability}";

                int l = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        buffer[0, i, j] = ' ';
                    }
                }

                foreach (char c in WeaponName)
                {
                    buffer[0, 0, l] = c;
                    l++;
                }
                l = 0;
                foreach (char c in Damage)
                {
                    buffer[0, 1, l] = c;
                    l++;
                }
                l = 0;
                foreach (char c in Durability)
                {
                    buffer[0, 2, l] = c;
                    l++;
                }

                return buffer;
            }
        }
        public void NewWeapon()
        {
            switch (rnd.Next(1, 3))
            {
                case 1: weapon = new Weapon.Axe(); break;
                case 2: weapon = new Weapon.Hammer(); break;
                case 3: weapon = new Weapon.Sword(); break;
            }
        }        

        // Aid
        public char[,,] AidIcon { get => aid.ICON; }
        public int AidAmount { get => aid.Amount; set => aid.Amount += value; } 
        public void UseAid()
        {
            if (this._hpMax - this._hp < aid.HealPoints)
            {
                this._hp = this._hpMax;
            }
            else
            {
                this._hp += aid.HealPoints;
            }

            aid.Amount -= 1;
        }
    }
}
