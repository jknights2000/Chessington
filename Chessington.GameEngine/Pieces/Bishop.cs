using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentsquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
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
    }
}