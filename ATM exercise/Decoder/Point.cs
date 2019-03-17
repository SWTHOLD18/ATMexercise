using System;

namespace Decoder
{
    //Simple interface for Points
    interface IPoint
    {
        int x { get; set; }
        int y { get; set; }
        int z { get; set; }
    }

    //Simple class for Points
    public class Point : IPoint
    {
        private int _x;
        private int _y;
        private int _z;

        public Point(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }
}

