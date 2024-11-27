using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDive
{
    internal class GrafficController
    {
        public void DrawAll(char[,] buffer, int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(buffer[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void AddToBuffer(char[,] buffer, char[,,] sprite, int x, int y, int width, int height, int frame = 0)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    buffer[i + y, j + x] = sprite[frame, i, j];
                }
            }
        }

        public int BG_W { get => 80; }
        public int BG_H { get => 26; }


        public char[,] BG
        {
            get
            {
                char _border = '#';
                char _bg = ' ';

                int _width = BG_W;
                int _height = BG_H;

                Console.SetWindowSize(_width, _height);
                Console.SetBufferSize(_width, _height);

                char[,] background = new char[_height, _width];

                for (int i = 0; i < _height; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        if (i == 0 || j == 0 || i == _height - 1 || j == _width - 1)
                        {
                            background[i, j] = _border;
                        }
                        else
                        {
                            background[i, j] = _bg;
                        }
                    }
                }
                return background;
            }
        }

        public char[,,] PlayerUI
        {
            get
            {

                char _border = '=';
                char _bg = ' ';

                int _width = BG_W-4;
                int _height = 7;

                char[,,] background = new char[1,_height, _width];

                for (int i = 0; i < _height; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        if (i == 0 || i == _height - 1)
                        {
                            background[0, i, j] = _border;
                        }
                        else
                        {
                            background[0, i, j] = _bg;
                        }
                    }
                }
                return background;
            }
        }
    }
}
