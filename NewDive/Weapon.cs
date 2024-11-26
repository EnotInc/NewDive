using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDive
{
    internal class Weapon
    {
        private int _dmg;
        private int _durability; 
        private string _name;
        
        private char[,,] icon = {{  
        {'/','\\','=',']',},       //   /\=]
        {'|','/','=',']',},       //    |/=]
        {'|','_','=',']'}}};     //     |_=]

        public Weapon(string Name = "Fist", int DMG = 0, int DUR = 0)
        {
            this._dmg = DMG;
            this._durability = DUR;
            this._name = Name;
        }
        public virtual char[,,] ICON { get => this.icon; }
        public virtual string NAME { get => this._name; }
        public virtual int DMG { get => this._dmg; } 
        public virtual int Durability { get => this._durability; set => this._durability -= value; }
        public bool IsBorken()
        {
            if ( this._durability > 0) { return false; }
            else { return true; }
        }

        public class Sword : Weapon
        {
            private new char[,,] icon = {{
        {' ','/','\\',' ',},       //    /\
        {'_','|','|','_',},       //    _||_
        {' ',']','[',' '}}};     //      ][

            public Sword(string Name = "Sword", int DMG = 12, int DUR = 10)
            {
                this._durability = DUR;
                this._dmg = DMG;
                this._name = Name;
            }
            public override char[,,] ICON { get => this.icon; }
            public override string NAME { get => this._name; }
            public override int DMG { get => this._dmg; }
            public override int Durability { get => this._durability; set => this._durability -= value; }
        }
        public class Axe : Weapon
        {
            private new char[,,] icon = {{
        {'<',']','/','|',},       //    ||T\       <]/|
        {' ','|','\\','|',},       //   ||_/        |\|
        {' ','|',' ',' '}}};     //     ][          |

            public Axe(string Name = "Axe", int DMG = 10, int DUR = 15)
            {
                this._durability = DUR;
                this._dmg = DMG;
                this._name = Name;
            }
            public override char[,,] ICON { get => this.icon; }
            public override string NAME { get => this._name; }
            public override int DMG { get => this._dmg; }
            public override int Durability { get => this._durability; set => this._durability -= value; }

        }
        public class Hammer : Weapon
        {
            private new char[,,] icon = {{
        {'/','=','=',']',},        //   [||]    /==]
        {' ','T',' ',' ',},       //    [||]     T 
        {' ','|',' ',' '}}};     //      []      | 

            public Hammer(string Name = "Hammer", int DMG = 5, int DUR = 20)
            {
                this._durability = DUR;
                this._dmg = DMG;
                this._name = Name;
            }
            public override char[,,] ICON { get => this.icon; }
            public override string NAME { get => this._name; }
            public override int DMG { get => this._dmg; }
            public override int Durability { get => this._durability; set => this._durability -= value; }
        }
    }
}
