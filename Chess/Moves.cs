using System;
using System.Collections.Generic;
using System.Text;


namespace Chess
{
    class Moves
    {
        PossbileMoves possbilemoves = new PossbileMoves();
        public string Controller(ChessBoard[,] board, int posLet, int posNum, int letOfPiece, int numOfPiece, bool whoseTurn, string movesInt)
        {
            //Console.WriteLine(Math.Abs((int)board[posLet, posNum]));
            switch (Math.Abs((int)board[letOfPiece, numOfPiece]))
            {
                case 1: //PAWN
                    //Console.WriteLine("1");
                    return (string.Concat(possbilemoves.PawnMove(board, letOfPiece, numOfPiece, whoseTurn), possbilemoves.PawnAttack(board, letOfPiece, numOfPiece, whoseTurn), possbilemoves.EnPassant(board, letOfPiece, numOfPiece, whoseTurn, movesInt)));
                case 2: //PAWN unmoved
                   // Console.WriteLine("2");
                    return (string.Concat(possbilemoves.PawnMove(board, letOfPiece, numOfPiece, whoseTurn), possbilemoves.PawnAttack(board, letOfPiece, numOfPiece, whoseTurn), possbilemoves.EnPassant(board, letOfPiece, numOfPiece, whoseTurn, movesInt)));
                case 20: //PAWN afeter one move
                   // Console.WriteLine("20");
                    return (string.Concat(possbilemoves.PawnMove(board, letOfPiece, numOfPiece, whoseTurn), possbilemoves.PawnAttack(board, letOfPiece, numOfPiece, whoseTurn), possbilemoves.EnPassant(board, letOfPiece, numOfPiece, whoseTurn, movesInt)));
                case 3: //KNIGHT
                    return possbilemoves.Knight(board, letOfPiece, numOfPiece, whoseTurn);
                case 4: //BISHOP
                    return possbilemoves.Bishop(board, letOfPiece, numOfPiece, whoseTurn);
                case 5: //TOWER
                    return possbilemoves.Tower(board, letOfPiece, numOfPiece, whoseTurn);
                case 50: //TOWER Un MOVED
                    return possbilemoves.Tower(board, letOfPiece, numOfPiece, whoseTurn);
                case 9: //QUEEN
                    return possbilemoves.Queen(board, letOfPiece, numOfPiece, whoseTurn);
                case 10: //KING
                    return possbilemoves.King(board, letOfPiece, numOfPiece, whoseTurn);
                case 100: //KING UNMOVED
                    return possbilemoves.King(board, letOfPiece, numOfPiece, whoseTurn);

            }
            

            return "";
        }
        public void ExecuteMove(ChessBoard[,] board, int posLet, int posNum, int letOfPiece, int numOfPiece, bool whoseTurn)
        {
            switch(Math.Abs((int)board[letOfPiece, numOfPiece]))
            {
                case 1:
                    PawnMove(board, posLet, posNum, letOfPiece, numOfPiece);
                    break;
                case 2:
                    PawnUnMovedAndTowerUnMoved(board, posLet, posNum, letOfPiece, numOfPiece);
                    break;
                case 20:
                    PawnAfterOneMove(board, posLet, posNum, letOfPiece, numOfPiece);
                    break;
                case 3:
                    RestOfThePieces( board, posLet,  posNum,  letOfPiece,  numOfPiece);
                    break;
                case 4:
                    RestOfThePieces(board, posLet, posNum, letOfPiece, numOfPiece);
                    break;
                case 5:
                    RestOfThePieces(board, posLet, posNum, letOfPiece, numOfPiece);
                    break;
                case 9:
                    RestOfThePieces(board, posLet, posNum, letOfPiece, numOfPiece);
                    break;
                case 100:
                    KingUnMoved(board, posLet, posNum, letOfPiece, numOfPiece, whoseTurn);
                    break;

            }
            board[letOfPiece, numOfPiece] = 0;
        }
        private void PawnMove(ChessBoard[,] board, int posLet, int posNum, int letOfPiece, int numOfPiece)
        {
            if( posLet == 1 || posLet == 8)
            {
                Coms.RenderComs(7);
                UserInput userinput = new UserInput();
                string input = userinput.GetPromotionInput();
                switch(input[0])
                {
                    case 'K':
                        board[posLet, posNum] = (ChessBoard)((int)ChessBoard.whiteKnight * (int)board[letOfPiece, numOfPiece]);
                        break;
                    case 'B':
                        board[posLet, posNum] = (ChessBoard)((int)ChessBoard.whiteBishop * (int)board[letOfPiece, numOfPiece]);
                        break;
                    case 'T':
                        board[posLet, posNum] = (ChessBoard)((int)ChessBoard.whiteTower * (int)board[letOfPiece, numOfPiece]);
                        break;
                    case 'Q':
                        board[posLet, posNum] = (ChessBoard)((int)ChessBoard.whiteQueen * (int)board[letOfPiece, numOfPiece]);
                        break;


                }

            }
            else
                board[posLet, posNum] = board[letOfPiece, numOfPiece];
        }
        private void RestOfThePieces(ChessBoard[,] board, int posLet, int posNum, int letOfPiece, int numOfPiece)
        {
                board[posLet, posNum] = board[letOfPiece, numOfPiece];
        }
        private void PawnUnMovedAndTowerUnMoved(ChessBoard[,] board, int posLet, int posNum, int letOfPiece, int numOfPiece)
        {
            board[posLet, posNum] = (ChessBoard)(10 * (int)board[letOfPiece, numOfPiece]);
        }
        private void PawnAfterOneMove(ChessBoard[,] board, int posLet, int posNum, int letOfPiece, int numOfPiece)
        {
            board[posLet, posNum] = (ChessBoard)( (int)board[letOfPiece, numOfPiece] / 20);
        }
        private void KingUnMoved(ChessBoard[,] board, int posLet, int posNum, int letOfPiece, int numOfPiece, bool whoseTurn)
        {
            if(whoseTurn)
            {
                if (posLet == 6)
                {
                    board[posLet, posNum] = ChessBoard.whiteKing;
                    board[5, 0] = ChessBoard.whiteTower;
                    board[7, 0] = 0;
                }
                else if (posLet == 1)
                {
                    board[posLet, posNum] = ChessBoard.whiteKing;
                    board[1, 0] = ChessBoard.whiteTower;
                    board[0, 0] = 0;
                }
                else
                {
                    board[posLet, posNum] = ChessBoard.whiteKing;

                }
            }
            else
            {
                if (posLet == 6)
                {
                    board[posLet, posNum] = ChessBoard.blackKing;
                    board[5, 7] = ChessBoard.blackTower;
                    board[7, 7] = 0;
                }
                else if (posLet == 1)
                {
                    board[posLet, posNum] = ChessBoard.blackKing;
                    board[1, 7] = ChessBoard.blackTower;
                    board[0, 7] = 0;
                }
                else
                {
                    board[posLet, posNum] = ChessBoard.blackKing;

                }
            }
            
        }
        public string ListAttackedTiles(ChessBoard[,] board, int letOfPiece, int numOfPiece, bool whoseTurn)
        {

            switch (Math.Abs((int)board[letOfPiece, numOfPiece]))
            {

                case 1: //PAWN
                    //Console.WriteLine("1");
                    return (string.Concat(possbilemoves.PawnAttack(board, letOfPiece, numOfPiece, whoseTurn)));
                case 2: //PAWN unmoved
                        // Console.WriteLine("2");
                    return (string.Concat( possbilemoves.PawnAttack(board, letOfPiece, numOfPiece, whoseTurn)));
                case 20: //PAWN afeter one move
                         // Console.WriteLine("20");
                    return (string.Concat(possbilemoves.PawnAttack(board, letOfPiece, numOfPiece, whoseTurn)));
                case 3: //KNIGHT
                    return string.Concat(possbilemoves.Knight(board, letOfPiece, numOfPiece, whoseTurn));
                case 4: //BISHOP
                    return string.Concat(possbilemoves.Bishop(board, letOfPiece, numOfPiece, whoseTurn));
                case 5: //TOWER
                    return string.Concat(possbilemoves.Tower(board, letOfPiece, numOfPiece, whoseTurn));
                case 50: //TOWER Un MOVED
                    return string.Concat(possbilemoves.Tower(board, letOfPiece, numOfPiece, whoseTurn));
                case 9: //QUEEN
                    return string.Concat(possbilemoves.Queen( board, letOfPiece, numOfPiece, whoseTurn));
                case 10: //KING
                    return string.Concat(possbilemoves.King( board, letOfPiece, numOfPiece, whoseTurn));
                case 100: //KING UNMOVED
                    return string.Concat(possbilemoves.King(board, letOfPiece, numOfPiece, whoseTurn));
                default:
                    return "";
            }
            
            
        }

    }
}
