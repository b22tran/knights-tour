using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Assignment1_KnightsTour
{
    class Knight
    {
        int startPositionRow;
        int startPositionCol;

        public Knight(int row, int col)
        {
            this.startPositionRow = row;
            this.startPositionCol = col;
        }

        public int move(Board board)
        {
            int counter = 1;
            bool isIntelligent = board.getIntelligence();

            ArrayList availiableMoves = new ArrayList();
            availiableMoves = checkAvailiableMoves(this.startPositionRow, this.startPositionCol, board);
            int tileSelection = 0;
            do
            {
                if (isIntelligent == false)
                {
                    tileSelection = new Random().Next(0, availiableMoves.Count - 1);
                } else
                {
                    tileSelection = priorityTile(availiableMoves, board);
                }
                Tile move = (Tile)availiableMoves[tileSelection];
                board.setSequence(move.getRow(), move.getCol(), counter++);
                availiableMoves = checkAvailiableMoves(move.getRow(), move.getCol(), board);
               // board.printBoard(2);
            } while (availiableMoves.Count > 0);
            return counter;
        }

        int priorityTile(ArrayList list, Board board)
        {
            int currentPriority = 10;
            ArrayList selection = new ArrayList();
            for (int i = 0; i < list.Count; ++i)
            {
                Tile t = (Tile)list[i];
                int priority = board.getPriority( t.getRow(), t.getCol());
                if (priority < currentPriority)
                {
                    currentPriority = priority;
                    selection.Clear();
                    selection.Add(i);
                }else
                if (priority == currentPriority)
                {
                    selection.Add(i);
                }

            }
            int selected = (int) selection[(new Random().Next(0, selection.Count ))];

            return selected;
        }
        ArrayList checkAvailiableMoves(int row, int col, Board board)
        {
            ArrayList availiableMoves = new ArrayList();
            Tile t0 = upLeft(row,col);
            Tile t1 = upRight(row,col);
            Tile t2 = rightUp(row,col);
            Tile t3 = rightDown(row,col);
            Tile t4 = downRight(row,col);
            Tile t5 = downLeft(row,col);
            Tile t6 = leftDown(row,col);
            Tile t7 = leftUp(row,col);

            if (t0 != null && !board.isSteppedOn(t0.getRow(), t0.getCol()))
            {
                availiableMoves.Add(t0);
            } if (t1 != null && !board.isSteppedOn(t1.getRow(), t1.getCol()))
            {
                availiableMoves.Add(t1);
            } if (t2 != null && !board.isSteppedOn(t2.getRow(), t2.getCol()))
            {
                availiableMoves.Add(t2);
            } if (t3 != null && !board.isSteppedOn(t3.getRow(), t3.getCol()))
            {
                availiableMoves.Add(t3);
            } if (t4 != null && !board.isSteppedOn(t4.getRow(), t4.getCol()))
            {
                availiableMoves.Add(t4);
            } if (t5 != null && !board.isSteppedOn(t5.getRow(), t5.getCol()))
            {
                availiableMoves.Add(t5);
            } if (t6 != null && !board.isSteppedOn(t6.getRow(), t6.getCol()))
            {
                availiableMoves.Add(t6);
            } if (t7 != null && !board.isSteppedOn(t7.getRow(), t7.getCol()))
            {
                availiableMoves.Add(t7);
            }
            return availiableMoves;
        }

        // follow 8 method are the moves the knight can make
        Tile upLeft(int row, int col)
        {
            if (((row - 2) >= 0) && ((col - 1) >= 0))
            {
                return new Tile((row - 2), (col - 1));
            }
            return null;
        }
        Tile upRight(int row, int col)
        {
            if (((row - 2) >= 0) && ((col + 1) <= 7))
            {
                return new Tile((row - 2), (col + 1));
            }
            return null;
        }
        Tile rightUp(int row, int col)
        {
            if (((row - 1) >= 0) && ((col + 2) <= 7))
            {
                return new Tile((row - 1), (col + 2));
            }
            return null;
        }
        Tile rightDown(int row, int col)
        {
            if (((row + 1) <= 7) && ((col + 2) <= 7))
            {
                return new Tile((row + 1), (col + 2));
            }
            return null;
        }
        Tile downRight(int row, int col)
        {
            if (((row + 2) <= 7) && ((col + 1) <= 7))
            {
                return new Tile((row + 2), (col + 1));
            }
            return null;
        }
        Tile downLeft(int row, int col)
        {
            if (((row + 2) <= 7) && ((col - 1) >= 0))
            {
                return new Tile((row + 2), (col - 1));
            }
            return null;
        }
        Tile leftDown(int row, int col)
        {
            if (((row + 1) <= 7) && ((col - 2) >= 0))
            {
                return new Tile((row + 1), (col - 2));
            }
            return null;
        }
        Tile leftUp(int row, int col)
        {
            if (((row - 1) >= 0) && ((col - 2) >= 0))
            {
                return new Tile((row - 1), (col - 2));
            }
            return null;
        }

        public int getStartPositionRow()
        {
            return this.startPositionRow;
        }
        public int getStartPositionCol()
        {
            return this.startPositionCol;
        }
    }
}
