using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            //1 for black 6 for white
            int whitestart = 6;
            int blackstart = 1;
            var currentsquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
      
            if(this.Player == Player.White)
            {
                if (currentsquare.Row == whitestart)
                {
                    moves.Add(new Square(currentsquare.Row - 1, currentsquare.Col));
                    moves.Add(new Square(currentsquare.Row - 2, currentsquare.Col));
                }
                else
                {
                    moves.Add(new Square(currentsquare.Row - 1, currentsquare.Col));
                }
                
            }
            else
            {
                if (currentsquare.Row == blackstart)
                {
                    moves.Add(new Square(currentsquare.Row + 1, currentsquare.Col));
                    moves.Add(new Square(currentsquare.Row + 2, currentsquare.Col));
                }
                else
                {
                    moves.Add(new Square(currentsquare.Row + 1, currentsquare.Col));
                }
            }
            return moves;
        }
    }
}