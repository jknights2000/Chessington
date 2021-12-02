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
            
            var currentsquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
      
            if(this.Player == Player.White)
            {
                if (!flaghasmove)
                {
                    if (board.GetPiece(new Square(currentsquare.Row - 1, currentsquare.Col)) == null && board.GetPiece(new Square(currentsquare.Row - 2, currentsquare.Col)) == null && currentsquare.Row - 2 > -1)
                    {
                        moves.Add(new Square(currentsquare.Row - 1, currentsquare.Col));
                        moves.Add(new Square(currentsquare.Row - 2, currentsquare.Col));
                    }
                    else if (board.GetPiece(new Square(currentsquare.Row - 1, currentsquare.Col)) == null && currentsquare.Row - 1 > -1)
                    {
                        moves.Add(new Square(currentsquare.Row - 1, currentsquare.Col));
                    }
                }
                else
                {
                    if (board.GetPiece(new Square(currentsquare.Row - 1, currentsquare.Col)) == null && currentsquare.Row - 1 > -1)
                    {
                        moves.Add(new Square(currentsquare.Row - 1, currentsquare.Col));
                    }
                }
                
            }
            else
            {
                if (!flaghasmove)
                {
                    if (board.GetPiece(new Square(currentsquare.Row + 1, currentsquare.Col)) == null && board.GetPiece(new Square(currentsquare.Row + 2, currentsquare.Col)) == null && currentsquare.Row + 2 < 8)
                    {
                        moves.Add(new Square(currentsquare.Row + 1, currentsquare.Col));
                        moves.Add(new Square(currentsquare.Row + 2, currentsquare.Col));
                    }
                    else if (board.GetPiece(new Square(currentsquare.Row + 1, currentsquare.Col)) == null && currentsquare.Row + 1 < 8)
                    {
                        moves.Add(new Square(currentsquare.Row - 1, currentsquare.Col));
                    }
                }
                else
                {
                    if (board.GetPiece(new Square(currentsquare.Row + 1, currentsquare.Col)) == null && currentsquare.Row + 1 < 8)
                    {
                        moves.Add(new Square(currentsquare.Row + 1, currentsquare.Col));
                    }
                }
            }
            return moves;
        }
    }
}