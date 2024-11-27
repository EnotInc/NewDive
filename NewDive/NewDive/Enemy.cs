using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDive
{
    internal class Enemy
    {
        private int _wight = 5;
        private int _height = 6;
        private readonly char[,,] icon = {{
                {'d','e','f','a','u',},
                {'l','t',' ',' ',' ',},
                {' ',' ',' ',' ',' ',},
                {'e','n','e','m','y',},
                {'i','c','o','n',' ',},
                {' ',' ',' ',' ',' ',},
            }};

        private string hpBar;
        public virtual char[,,] ICON { get => icon; }
        public int W { get => _wight; }
        public int H { get => _height; }

        private string _name;
        private int _hp;
        private int _hpMax;
        private int _dmg;
        public Enemy(string Name = "Default", int DMG = 5)
        {
            this._name = Name;
            this._hp = 100;
            this._hpMax = this._hp;
            this._dmg = DMG;
        }
        public int HP { get => this._hp; set => this._hp = value; }
        public int HPMAX { get => this._hpMax; }
        public int DMG { get => this._dmg; set => this._dmg = value; }
        public char[,,] NAME
        {
            get
            {
                char[,,] buffer = new char[1, 1,this._name.Length];

                int i = 0;

                foreach (char c in this._name)
                {
                    buffer[0, 0, i] = c;
                    i++;
                }

                return buffer;
            }
        }

        public bool IsAlive()
        {
            if (this._hp > 0) { return true; }
            else { return false; }
        }

        public int HPBARW { get => hpBar.Length; }
        public int NAMEW { get => this._name.Length; }
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
        public class Fear : Enemy
        {
            private new readonly char[,,] icon = {{
                {' ','#','#','#',' ',},     //  ### 
                {'#','#','#','#','#',},     // #####
                {'#','.','#','.','#',},     // #.#.#
                {'#','#','#','#','#',},     // #####
                {'\\','^','^','^','/',},    // \^^^/
                {'|','^','^','^','|',},     // |^^^|
            },{
                {' ','#','#','#',' ',},
                {'#','#','#','#','/',},
                {'#','.','#','/','#',},
                {'#','#','/','#','#',},
                {'\\','/','^','^','/',},
                {'/','^','^','^','|',},
            },{
                {' ',' ',' ',' ',' ',},     // 
                {' ',' ',' ',' ',' ',},     // 
                {' ',' ',' ',' ',' ',},     // 
                {' ','_','_',' ',' ',},     //  __
                {'#','.','#','\\',' ',},    // #.##\
                {'#','#','#','>','|',},     // ###> |
            }};
            public override char[,,] ICON { get => this.icon; }
            public Fear(string Name, int DMG = 5)
            {
                this._name = Name;
                this._dmg = DMG;
            }
        }
        public class Emptyness : Enemy
        {
            private new readonly char[,,] icon = {{
                {' ',',',' ',' ','"',},
                {'{',' ','%',' ',' ',},
                {' ',';',' ','>',',',},
                {'.',' ','*',' ',' ',},
                {' ',' ',' ',' ','-',},
                {'-',' ',' ','"',' ',},
            },{
                {' ',',',' ',' ','"',},
                {'{',' ','%',' ','/',},
                {' ',';',' ','/',',',},
                {'.',' ','/',' ',' ',},
                {' ','/',' ',' ','-',},
                {'/',' ',' ','"',' ',},
            },{
                {' ',',',' ',' ',' ',},
                {' ',' ',' ',' ',' ',},
                {' ',' ',' ',' ',' ',},
                {' ',' ',' ',' ',' ',},
                {'.',' ','/','#','-',},
                {'%','&','#','%','#',},

            }};
            public override char[,,] ICON { get => this.icon; }
            public Emptyness(string Name, int DMG = 5)
            {
                this._name = Name;
                this._dmg = DMG;
            }

        }
        public class Shard : Enemy
        {
            private new readonly char[,,] icon = {{
                {' ','\\','_','/',' ',},
                {' ','<','^','>',' ',},
                {'/','[','#','}','\\',},
                {'|','{','K',']','|',},
                {' ','!',' ','}',' ',},
                {'.','$',' ',':',';',},
            },{
                {' ','\\','_','/',' ',},
                {' ','<','^','>','/',},
                {'/','[','#','/','\\',},
                {'|','{','/',']','|',},
                {' ','/',' ','}',' ',},
                {'/','$',' ',':',';',},
            },{
                {' ',' ',' ',' ',' ',},
                {' ',' ',' ',' ',' ',},
                {' ',' ',' ',' ',' ',},
                {' ',' ',' ','_',' ',},
                {' ','_','T','#','\\',},
                {'/','/','|','/','|',},
            }};
            public override char[,,] ICON { get => this.icon; }
            public Shard(string Name, int DMG = 5)
            {
                this._name = Name;
                this._dmg = DMG;
            }
        }
        public class Mirror : Enemy
        {
            private new readonly char[,,] icon = {{
                {' ',' ','_',' ',' ',},
                {' ','(','?',')',' ',},
                {'|','@','@','@','|',},
                {'!','@','@','@','!',},
                {' ','I',' ','I',' ',},
                {'.','I',' ','I','.',},
            },{                
                {' ',' ','_',' ',' ',},
                {' ','(','?',')','/',},
                {'|','@','@','/','|',},
                {'!','@','/','@','!',},
                {' ','/',' ','I',' ',},
                {'/','I',' ','I','.',},
            },{ // Frame 2 - Dead
                {' ',' ',' ',' ',' ',},
                {' ',' ',' ',' ',' ',},
                {' ',' ',' ',' ',' ',},
                {' ',' ',' ','_',' ',},
                {'.','_','/','#','\\',},
                {'/','#','@','#','X',},

            }};
            public override char[,,] ICON { get => this.icon; }
            public Mirror(string Name, int DMG = 5)
            {
                this._name = Name;
                this._dmg = DMG;
            }
        }
        public class Apaty : Enemy
        {
            private new readonly char[,,] icon = {{
                {'<','@','^','@','>' },     //  <@^@>
                {' ','_','|','.',' ' },     //   _|.  
                {'/',' ','/',' ','\\'},    //  / / \
                {' ',' ','L',' ',' ' },     //    L }
                {' ','|',' ','\\',' '},    //   | \ 
                {'/',' ',' ','|',' ' },     //  /  | 
            },{
                {'<','@','^','@','>' },
                {' ','_','|','.','/' },
                {'/',' ','/','/','\\'},
                {' ',' ','/',' ',' ' },
                {' ','/',' ','\\',' '},
                {'/',' ',' ','|',' ' },
            },{
                {' ',' ',' ',' ',' ' },
                {' ',' ',' ',' ',' ' },
                {' ',' ',' ',' ',' ' },
                {' ','^',' ',' ',' ' },
                {' ','@','_','_',' ' },
                {'<','@','#','\\','_' },

            }};
            public override char[,,] ICON { get => this.icon; }
            public Apaty(string Name, int DMG = 5)
            {
                this._name = Name;
                this._dmg = DMG;
            }
        }
    }
}
