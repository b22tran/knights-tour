using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1_KnightsTour
{
    class Board
    {
        // 3 dimensional array for the board
        // the first 2 dimension are for the row and col of board being 8x8
        // the third dimension will have two sets
        //      1st  [row,col,0] for the bool if tile has been stepped on
        //             0 for false, 1 for true
        //      2nd [row,col,1] for the priority number
        //      3rd  [row,col,2] for the sequence number
        int[, ,] grid = new int[8, 8, 3];
        bool isIntelligent = false;
        Knight knight;

        // constructor 
        public Board(bool isIntelligent, Knight knight)
        {
            setDefault(); 
            setPriority();
            this.isIntelligent = isIntelligent;
            this.knight = knight;
            setSequence(knight.getStartPositionCol(), knight.getStartPositionCol(), -1);
        }


        // prints the chess board with the sequence the knight landed on each tile
        public void printBoard(int z, RichTextBox rtb)
        {

            if (z == 2)
            {
                rtb.AppendText("\nThe sequence the knight took was: ");

                //Console.WriteLine("\nThe sequence the knight took was: ");
            }
            for (int row = 0; row < 8; ++row)
            {
                rtb.AppendText("\n");

                //Console.WriteLine("\n");

                for (int col = 0; col < 8; ++col)
                {
                    rtb.AppendText(" " + this.grid[row, col, z] + "   ");

                    //Console.Write(" "+ this.grid[row, col, z]+ "   ") ; 
                }
            }
            rtb.AppendText("\n");

            //Console.WriteLine("\n");

        }


        public bool isSteppedOn(int row, int col)
        {
            if (!(this.grid[row, col, 0] == 0))
            {
                return true;
            }
            return false;
        }
        public int getPriority(int row, int col)
        {
            return this.grid[row, col, 1];
        }
        public bool getIntelligence()
        {
            return this.isIntelligent;
        }
        public int[, ,] getGrid()
        {
            return this.grid;
        }
        private void setDefault()
        {
            for (int row = 0; row < 8; ++row)
            {
                for (int col = 0; col < 8; ++col)
                {
                    this.grid[row, col, 0] = 0; // bool, if tile has been stepped on
                    this.grid[row, col, 2] = 0; // sequence number of tile
                }
            }
        }
        
        private void setPriority()
        {
            // priority is in dimension [row,col,1]

            // setting priorty of 2
            this.grid[0, 0, 1] = 2;
            this.grid[0, 7, 1] = 2;
            this.grid[7, 0, 1] = 2;
            this.grid[7, 7, 1] = 2;
            // setting priorty of 3
            this.grid[0, 1, 1] = 3;
            this.grid[0, 6, 1] = 3;
            this.grid[1, 0, 1] = 3;
            this.grid[1, 7, 1] = 3;
            this.grid[6, 0, 1] = 3;
            this.grid[6, 7, 1] = 3; 
            this.grid[7, 1, 1] = 3;
            this.grid[7, 6, 1] = 3;
            // setting priorty of 4
            this.grid[1, 1, 1] = 4;
            this.grid[1, 6, 1] = 4;
            this.grid[6, 1, 1] = 4;
            this.grid[6, 6, 1] = 4;

            for (int row = 2; row < 6; ++row)
            {
                this.grid[row, 0, 1] = 4;
                this.grid[row, 7, 1] = 4;
            }
            for (int col = 2; col < 6; ++col)
            {
                this.grid[0, col, 1] = 4;
                this.grid[7, col, 1] = 4;
            }

            // setting priorty of 6
            for (int row = 2; row < 6; ++row)
            {
                this.grid[row, 1, 1] = 6;
                this.grid[row, 6, 1] = 6;
            }
            for (int col = 2; col < 6; ++col)
            {
                this.grid[1, col, 1] = 6;
                this.grid[6, col, 1] = 6;
            }

            // setting priorty of 8
            for (int row = 2; row < 6; ++row)
            {
                for (int col = 2; col < 6; ++col)
                {
                    this.grid[row, col, 1] = 8;
                }
            }

        }

        public void setSequence(int row, int col, int sequence)
        {
            // sequence is in dimension [row,col,2]
            this.grid[row, col, 2] = sequence;
            this.grid[row, col, 0] = 1;
        }

        public int getSequence(int row, int col)
        {
            // sequence is in dimension [row,col,2]
            return this.grid[row, col, 2];
        }

    }
}
