using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class RenderBoard
    {
        public RenderBoard(ChessBoard[,] board)
        {
            board[0, 0] = ChessBoard.whiteTowerUnMoved;
            board[1, 0] = ChessBoard.whiteKnight;
            board[2, 0] = ChessBoard.whiteBishop;
            board[3, 0] = ChessBoard.whiteQueen;
            board[4, 0] = ChessBoard.whiteKingUnMoved;
            board[5, 0] = ChessBoard.whiteBishop;
            board[6, 0] = ChessBoard.whiteKnight;
            board[7, 0] = ChessBoard.whiteTowerUnMoved;
            int j = 1;
            for (int i = 0; i < 8; i++)
                board[i, j] = ChessBoard.whitePawnUnMoved;

            for (int i = 0; i < 8; i++)
            {
                for ( j = 2; j < 5; j++)
                    board[i, j] = ChessBoard.empty;
            }
            j = 6;
            for (int i = 0; i < 8; i++)
                board[i, j] = ChessBoard.blackPawnUnMoved;
            board[0, 7] = ChessBoard.blackTowerUnMoved;
            board[1, 7] = ChessBoard.blackKnight;
            board[2, 7] = ChessBoard.blackBishop;
            board[3, 7] = ChessBoard.blackQueen;
            board[4, 7] = ChessBoard.blackKingUnMoved;
            board[5, 7] = ChessBoard.blackBishop;
            board[6, 7] = ChessBoard.blackKnight;
            board[7, 7] = ChessBoard.blackTowerUnMoved;

        }
        private static string TransformPieceToTile(ChessBoard piece)
        {
            switch (piece)
            {
                case ChessBoard.empty:
                    return "  ";

                case ChessBoard.blackBishop:
                    return "BB";

                case ChessBoard.blackKing:
                    return "BK";

                case ChessBoard.blackKnight:
                    return "BN";

                case ChessBoard.blackPawn:
                    return "BP";

                case ChessBoard.blackQueen:
                    return "BQ";

                case ChessBoard.blackTower:
                    return "BT";

                case ChessBoard.whiteBishop:
                    return "WB";

                case ChessBoard.whiteKing:
                    return "WK";

                case ChessBoard.whiteKnight:
                    return "WN";

                case ChessBoard.whitePawn:
                    return "WP";

                case ChessBoard.whiteQueen:
                    return "WQ";

                case ChessBoard.whiteTower:
                    return "WT";
                case ChessBoard.whitePawnUnMoved:
                    return "WP";
                case ChessBoard.blackPawnUnMoved:
                    return "BP";
                case ChessBoard.whiteKingUnMoved:
                    return "WK";
                case ChessBoard.blackKingUnMoved:
                    return "BK";
                case ChessBoard.whiteTowerUnMoved:
                    return "WT";
                case ChessBoard.blackTowerUnMoved:
                    return "BT";
                case ChessBoard.whitePawnAfterOneMove:
                    return "WP";
                case ChessBoard.blackPawnAfterOneMove:
                    return "BP";



            }
            return "error";
        }
        public void Render(ChessBoard[,] board)
        {
            for (int i = 0; i < 8; i++)
                Console.Write((i+1) + " |");
               
            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j < 8)
                        Console.Write(TransformPieceToTile(board[i, j]) + " ");
                    else
                        Console.Write((char)(65 + i) + "");
                }
                Console.WriteLine();
            }
        }
        public void CostumBoard(ChessBoard[,] board) //for debug
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    board[i, j] = ChessBoard.empty;
            board[2, 2] = ChessBoard.whitePawn;
            board[1, 3] = ChessBoard.blackPawnAfterOneMove;
            board[0, 7] = ChessBoard.blackTowerUnMoved;
            board[5, 7] = ChessBoard.whiteBishop;
            
        }

    }
}
