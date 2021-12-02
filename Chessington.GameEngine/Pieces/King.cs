using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentsquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
            int[,] offset =
            {
                {1,0},
                {0,1},
                {-1,0},
                {0,-1},
                {1,1},
                {-1,1},
                {-1,-1},
                {1,-1}

            };
            return applyoffset(moves,currentsquare,offset);
        }
    }
}