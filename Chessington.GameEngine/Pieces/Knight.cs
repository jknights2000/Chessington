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
            int max = 8;
            int min = -1;
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
            for(int i = 0; i < 8;i++)
            {
                if(currentsquare.Row + offset[i,0] < max && currentsquare.Row + offset[i, 0] > min && currentsquare.Row + offset[i, 1] < max && currentsquare.Row + offset[i, 1] > min)
                {
                    moves.Add(new Square(currentsquare.Row + offset[i, 0], currentsquare.Col + offset[i, 1]));
                }
            }
            return moves;
        }
    }
}