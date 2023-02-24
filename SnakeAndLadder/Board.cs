using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder
{
    internal class Board
    {
        private int Rows;

        private int Columns;

        private Dictionary<int, int> Jumps = new();

        public bool IsWinningTile(int tileNumber)
        {
            return tileNumber == Rows * Columns;
        }

        public bool TileOutOfBounds(int tileNumber)
        {
            return tileNumber > Rows * Columns;
        }

        public bool TileContainsSnake(int tileNumer, out int tail)
        {
            if (Jumps.TryGetValue(tileNumer, out tail))
            {
                if (tail > tileNumer)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public bool TileContainsLadder(int tileNumer, out int top)
        {
            if (Jumps.TryGetValue(tileNumer, out top))
            {
                if (top > tileNumer)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public class BoardBuilder
        {
            private Board board;

            public BoardBuilder()
            {
                board = new Board
                {
                    Jumps = new Dictionary<int, int>()
                };
            }

            public BoardBuilder AddSnake(int head, int tail)
            {
                board.Jumps[head] = tail;
                return this;
            }

            public BoardBuilder AddLadder(int bottom, int top)
            {
                board.Jumps.Add(bottom, top);
                return this;
            }

            public BoardBuilder SetRows(int rows)
            {
                board.Rows = rows;
                return this;
            }

            public BoardBuilder SetColumns(int columns)
            {
                board.Columns = columns;
                return this;
            }

            public Board Build()
            {
                return board;
            }
        }
    }
}
