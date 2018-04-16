using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_KnightsTour
{
    class Tile
    {
        
        int row;
        int col;

        public Tile(int x, int y)
        {
            this.row = x;
            this.col = y;
        }

        public int getRow()
        {
            return this.row;
        }

        public int getCol()
        {
            return this.col;
        }
    }

}
