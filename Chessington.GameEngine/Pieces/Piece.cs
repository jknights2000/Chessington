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

        public bool HasMove{ get; set; }
        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            HasMove = true;
        }
        public List<Square> getDiagnoal(Piece current,List<Square> moves, Square currentsquare,Board board)
        {
            int max = 8;
            int min = -1;
            for (int col = currentsquare.Col + 1, row = currentsquare.Row + 1; col < max && row < max; row++, col++)
            {
                if(board.GetPiece(new Square(row, col)) != null)
                {
                    if (board.GetPiece(new Square(row, col)).Player != current.Player)
                    {
                        moves.Add(new Square(row, col));
                    }
                    break;
                }
                moves.Add(new Square(row, col));
            }
            for (int col = currentsquare.Col - 1, row = currentsquare.Row + 1; col > min && row < max; row++, col--)
            {
                if (board.GetPiece(new Square(row, col)) != null)
                {
                    if (board.GetPiece(new Square(row, col)).Player != current.Player)
                    {
                        moves.Add(new Square(row, col));
                    }
                    break;
                }
                moves.Add(new Square(row, col));
            }
            for (int col = currentsquare.Col - 1, row = currentsquare.Row - 1; col > min && row > min; row--, col--)
            {
                if (board.GetPiece(new Square(row, col)) != null)
                {
                    if (board.GetPiece(new Square(row, col)).Player != current.Player)
                    {
                        moves.Add(new Square(row, col));
                    }
                    break;
                }
                moves.Add(new Square(row, col));
            }
            for (int col = currentsquare.Col + 1, row = currentsquare.Row - 1; col < max && row > min; row--, col++)
            {
                if (board.GetPiece(new Square(row, col)) != null)
                {
                    if(board.GetPiece(new Square(row, col)).Player != current.Player)
                    {
                        moves.Add(new Square(row, col));
                    }
                    break;
                }
                moves.Add(new Square(row, col));
            }
            return moves;
        }
        public List<Square> getLaterally(Piece current,List<Square> moves, Square currentsquare,Board board)
        {
            int xstart = 0;
            int xend = 8;
            int ystart = 0;
            int yend = 8;
            for (var i = 0; i < 8; i++)
            {
                if(i < currentsquare.Row && board.GetPiece(new Square(currentsquare.Row, i)) != null && xstart < i)
                {
                    if (board.GetPiece(new Square(currentsquare.Row, i)).Player == current.Player)
                    {
                        xstart = i;
                    }
                    else
                    {
                        if(i == 0)
                        {
                            xstart = 0;
                        }
                        else
                        {
                            xstart = i - 1;
                        }
                    }
                }
                else if (i > currentsquare.Row && board.GetPiece(new Square(currentsquare.Row, i)) != null && xend > i)
                {

                    if (board.GetPiece(new Square(currentsquare.Row, i)).Player == current.Player)
                    {
                        xend = i;
                    }
                    else
                    {
                        if (i == 7)
                        {
                            xend = 7;
                        }
                        else
                        {
                            xend = i + 1;
                        }
                    }
                }
                if (i < currentsquare.Col && board.GetPiece(new Square(i, currentsquare.Col)) != null && ystart < i)
                {
                    if (board.GetPiece(new Square(i, currentsquare.Col)).Player == current.Player)
                    {
                        ystart = i;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            ystart = 0;
                        }
                        else
                        {
                            ystart = i - 1;
                        }
                    }
                }
                else if (i > currentsquare.Col && board.GetPiece(new Square(i, currentsquare.Col)) != null && yend > i)
                {
                    if (board.GetPiece(new Square(i, currentsquare.Col)).Player == current.Player)
                    {
                        ystart = i;
                    }
                    else
                    {
                        if (i == 7)
                        {
                            yend = 7;
                        }
                        else
                        {
                            yend = i + 1;
                        }
                    }
                }

            }

            for (var i = xstart; i < xend; i++)
                moves.Add(Square.At(currentsquare.Row, i));

            for (var i = ystart; i < yend; i++)
                moves.Add(Square.At(i, currentsquare.Col));

            moves.RemoveAll(s => s == Square.At(currentsquare.Row, currentsquare.Col));
            return moves;
        }
        public List<Square> applyoffset(Piece current,List<Square> moves,Square currentsquare, int[,] offset,Board board)
        {
            int max = 8;
            int min = -1;
            for (int i = 0; i < 8; i++)
            {
                if (currentsquare.Row + offset[i, 0] < max && currentsquare.Row + offset[i, 0] > min && currentsquare.Row + offset[i, 1] < max && currentsquare.Row + offset[i, 1] > min)
                {
                   if(board.GetPiece(new Square(currentsquare.Row + offset[i, 0], currentsquare.Col + offset[i, 1])) == null)
                    {
                                moves.Add(new Square(currentsquare.Row + offset[i, 0], currentsquare.Col + offset[i, 1]));
                    }
                    else if (board.GetPiece(new Square(currentsquare.Row + offset[i, 0], currentsquare.Col + offset[i, 1])).Player != current.Player)
                    {
                        moves.Add(new Square(currentsquare.Row + offset[i, 0], currentsquare.Col + offset[i, 1]));
                    }
                }
            }
            return moves;
        }
    }
}