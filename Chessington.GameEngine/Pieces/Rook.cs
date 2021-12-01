using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentsquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
            for (var i = 0; i < 8; i++)
                moves.Add(Square.At(currentsquare.Row, i));

            for (var i = 0; i < 8; i++)
                moves.Add(Square.At(i, currentsquare.Col));
            
            return moves;
        }
    }
}