using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDive
{
    internal class Aid
    {
        private int healpoints = 25;
        private int amount;

        private char[,,] icon = 
            {{ 
                {' ','_','_','_',' ' }, //       ___
                {'[','_','H','_',']' }, //      [_H_]
                {' ',' ',' ',' ',' ' }  //      HP:25
            }};
        public Aid(int Amount = 1)
        {
            this.amount = Amount;

            string Heal = $"HP:{healpoints}";
            int i = 0;
            foreach (char c in Heal)
            {
                icon[0, 2, i] = c;
                i++;
            }
        }
        public char[,,] ICON { get => this.icon; }
        public int Amount { get => this.amount; set => this.amount = value; }
        public int HealPoints { get => this.healpoints; }
    }
}
