using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDive
{
    internal class NotificationWindow
    {
        private string _sender;
        private string _message;

        private string _skip = "Press any button";

        static private int w = 70;
        static private int h = 10;

        private char[,,] window = new char[1, h, w];

        public char[,,] Show(string Message, string Sender = "System")
        {
            this._message = "-" + Message;
            this._sender = "*" + Sender + "*";


            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (i == 0 || j == 0 || i == h - 1 || j == w - 1)
                    {
                        window[0, i, j] = '@';
                    }
                    else
                    {
                        window[0, i, j] = ' ';
                    }
                }
            }

            int l = 0;
            foreach (char c in this._sender)
            {
                window[0, 2, l + 4] = c;
                l++;
            }

            l = 0;
            foreach (char c in this._message)
            {
                window[0, 4, l + 4] = c;
                l++;
            }

            l = 0;
            foreach (char c in this._skip)
            {
                window[0, 8, l + 4] = c;
                l++;
            }

            return window;
        }
        public int W { get => w; }
        public int H { get => h; }
    }
}
