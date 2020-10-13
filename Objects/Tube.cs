using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleFlappyBird.Objects
{
    struct Tube
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool[,] Hitbox { get; private set; }

        public Tube(int x_, int y_, int height, int width, int gapHeight)
        {
            X = x_;
            Y = y_;

            Hitbox = new bool[height, width];

            int gapStartY = new Random().Next(1, height - gapHeight);

            for(int y = 0; y < gapStartY && y < height; y++)
                for(int x = 0; x < width; x++)
                    Hitbox[y, x] = true;

            for (int y = gapStartY + gapHeight; y < height; y++)
                for (int x = 0; x < width; x++)
                    Hitbox[y, x] = true;
        }
    }
}
