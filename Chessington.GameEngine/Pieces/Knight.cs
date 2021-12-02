using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentsquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
            int[,] offset =
            {
                {-2,1},
                {-1,2},
                {1,2},
                {2,1},
                {2,-1},
                {1,-2},
                {-1,-2},
                {-2,-1}

            };
            return applyoffset(this,moves,currentsquare,offset,board);
        }
    }
}