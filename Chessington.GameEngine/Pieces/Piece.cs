using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public bool flaghasmove { get; set; }
        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            flaghasmove = true;
        }
        public List<Square> getDiagnoal(List<Square> moves, Square currentsquare)
        {
            int max = 8;
            int min = -1;
            for (int col = currentsquare.Col + 1, row = currentsquare.Row + 1; col < max && row < max; row++, col++)
            {
                moves.Add(new Square(row, col));
            }
            for (int col = currentsquare.Col - 1, row = currentsquare.Row + 1; col > min && row < max; row++, col--)
            {
                moves.Add(new Square(row, col));
            }
            for (int col = currentsquare.Col - 1, row = currentsquare.Row - 1; col > min && row > min; row--, col--)
            {
                moves.Add(new Square(row, col));
            }
            for (int col = currentsquare.Col + 1, row = currentsquare.Row - 1; col < max && row > min; row--, col++)
            {
                moves.Add(new Square(row, col));
            }
            return moves;
        }
        public List<Square> getLaterally(List<Square> moves, Square currentsquare)
        {
            for (var i = 0; i < 8; i++)
            {
                moves.Add(Square.At(currentsquare.Row, i));
                moves.Add(Square.At(i, currentsquare.Col));

            }
            moves.RemoveAll(s => s == Square.At(currentsquare.Row, currentsquare.Col));
            return moves;
        }
        public List<Square> applyoffset(List<Square> moves,Square currentsquare, int[,] offset)
        {
            int max = 8;
            int min = -1;
            for (int i = 0; i < 8; i++)
            {
                if (currentsquare.Row + offset[i, 0] < max && currentsquare.Row + offset[i, 0] > min && currentsquare.Row + offset[i, 1] < max && currentsquare.Row + offset[i, 1] > min)
                {
                    moves.Add(new Square(currentsquare.Row + offset[i, 0], currentsquare.Col + offset[i, 1]));
                }
            }
            return moves;
        }
    }
}