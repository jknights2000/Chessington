using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentsquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
            moves = getDiagnoal(moves, currentsquare,board);
            moves = getLaterally(this,moves, currentsquare,board);
            return moves;
        }//works
    }
}