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
                if(currentsquare.Row != 0)
                {
                    if (!HasMove)
                    {
                        if (board.GetPiece(new Square(currentsquare.Row - 1, currentsquare.Col)) == null && board.GetPiece(new Square(currentsquare.Row - 2, currentsquare.Col)) == null && currentsquare.Row - 2 > 0)
                        {
                            moves.Add(new Square(currentsquare.Row - 1, currentsquare.Col));
                            moves.Add(new Square(currentsquare.Row - 2, currentsquare.Col));
                        }
                        else if (board.GetPiece(new Square(currentsquare.Row - 1, currentsquare.Col)) == null && currentsquare.Row - 1 > 0)
                        {
                            moves.Add(new Square(currentsquare.Row - 1, currentsquare.Col));
                        }
                    }
                    else
                    {
                        if (board.GetPiece(new Square(currentsquare.Row - 1, currentsquare.Col)) == null && currentsquare.Row - 1 > 0)
                        {
                            moves.Add(new Square(currentsquare.Row - 1, currentsquare.Col));
                        }
                    }
                    if (currentsquare.Col > 0 && board.GetPiece(new Square(currentsquare.Row - 1, currentsquare.Col - 1)) != null && board.GetPiece(new Square(currentsquare.Row - 1, currentsquare.Col - 1)).Player != this.Player)
                    {
                        moves.Add(new Square(currentsquare.Row - 1, currentsquare.Col - 1));
                    }
                    if (currentsquare.Col < 7 && board.GetPiece(new Square(currentsquare.Row - 1, currentsquare.Col + 1)) != null && board.GetPiece(new Square(currentsquare.Row - 1, currentsquare.Col + 1)).Player != this.Player)
                    {
                        moves.Add(new Square(currentsquare.Row - 1, currentsquare.Col + 1));
                    }
                }
                
            }
            else if (this.Player == Player.Black)
            {
                if (currentsquare.Row != 7)
                {
                    if (!HasMove)
                    {
                        if (board.GetPiece(new Square(currentsquare.Row + 1, currentsquare.Col)) == null && board.GetPiece(new Square(currentsquare.Row + 2, currentsquare.Col)) == null && currentsquare.Row + 2 < 8)
                        {
                            moves.Add(new Square(currentsquare.Row + 1, currentsquare.Col));
                            moves.Add(new Square(currentsquare.Row + 2, currentsquare.Col));
                        }
                        else if (board.GetPiece(new Square(currentsquare.Row + 1, currentsquare.Col)) == null && currentsquare.Row + 1 < 8)
                        {
                            moves.Add(new Square(currentsquare.Row + 1, currentsquare.Col));
                        }
                    }
                    else
                    {
                        if (board.GetPiece(new Square(currentsquare.Row + 1, currentsquare.Col)) == null && currentsquare.Row + 1 < 8)
                        {
                            moves.Add(new Square(currentsquare.Row + 1, currentsquare.Col));
                        }
                    }
                    if(currentsquare.Col != 7 && board.GetPiece(new Square(currentsquare.Row + 1, currentsquare.Col+1)) != null && board.GetPiece(new Square(currentsquare.Row + 1, currentsquare.Col + 1)).Player != this.Player)
                    {
                        moves.Add(new Square(currentsquare.Row + 1, currentsquare.Col + 1));
                    }
                    if (currentsquare.Col != 0 && board.GetPiece(new Square(currentsquare.Row + 1, currentsquare.Col - 1)) != null && board.GetPiece(new Square(currentsquare.Row + 1, currentsquare.Col + 1)).Player != this.Player)
                    {
                        moves.Add(new Square(currentsquare.Row + 1, currentsquare.Col - 1));
                    }
                }
            }
            return moves;
        }
    }
}