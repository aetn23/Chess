 using System;

namespace Chess
{
    public enum ChessBoard { empty = 0, whitePawn = 1, whitePawnUnMoved = 2, whitePawnAfterOneMove = 20, blackPawnAfterOneMove = - 20, blackPawn = -1,
        blackPawnUnMoved = - 2, whiteKnight = 3, blackKnight = -3, whiteBishop = 4, blackBishop = -4, whiteTower = 5, whiteTowerUnMoved = 50, blackTowerUnMoved = - 50,
        blackTower = -5, whiteQueen = 9, blackQueen = -9, whiteKing = 10, whiteKingUnMoved = 100, blackKingUnMoved = - 100, blackKing = -10 }; //the absolute value actually matches the value of each piece in chess game (exepct for king, whcihc hasnt any value) 
    class Program
    {
        private static ChessBoard[,] board = new ChessBoard[8, 8];

        static void Main(string[] args)
        {
            RenderBoard renderboard = new RenderBoard(board);
            UserInput userinput = new UserInput();
            Pieces pieces = new Pieces();
            bool whoseTurn = true; //white - true, black - false
            Transform transform = new Transform();
            PossbileMoves possiblemoves = new PossbileMoves();
            Moves moves = new Moves();
            string attackedTiles = "AA";
            
            string movesInt = "";
            //renderboard.CostumBoard(board);
            while (true) // to be changed to IsGameOver method
            {
                attackedTiles = "AA";
                int posToWhichMove, posOfPiece;
                ChessBoard piece;
                //renderboard.CostumBoard(board); //DEBUG
                renderboard.Render(board);
                Coms.RenderComs(1);
                posOfPiece = userinput.GetInput();
                if (!pieces.IsPlayerPiece(board[posOfPiece/10, posOfPiece%10], whoseTurn))
                {
                    Coms.RenderComs(6);
                    continue;
                }
                Coms.RenderComs(3);               
                posToWhichMove = userinput.GetInput(); // get input to where should the piece be moved
                movesInt = ListMoves.RememberAsInt(posToWhichMove/ 10, posToWhichMove % 10, movesInt);

               
                if (moves.Controller(board, posToWhichMove / 10, posToWhichMove % 10, posOfPiece /10, posOfPiece % 10, whoseTurn, movesInt).IndexOf(posToWhichMove.ToString()) != -1) 
                {
                     ChessBoard[,] copyOfBoard = new ChessBoard[8, 8];
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            copyOfBoard[i, j] = board[i, j];
                        }
                    }
                    moves.ExecuteMove(copyOfBoard, posToWhichMove / 10, posToWhichMove % 10, posOfPiece / 10, posOfPiece % 10, whoseTurn);
                    if (whoseTurn)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if ( board[i, j] < 0 && board[i, j] != 0) 
                                    attackedTiles = String.Concat(attackedTiles, transform.TransformFromIntToNotation((moves.ListAttackedTiles(board, i, j, !whoseTurn))));
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (board[i, j] > 0 && board[i, j] != 0)
                                    attackedTiles = String.Concat(attackedTiles, transform.TransformFromIntToNotation((moves.ListAttackedTiles(board, i, j, !whoseTurn))));
                                //, Console.WriteLine(attackedTiles);
                            }
                        }
                    }
                    //Console.WriteLine(attackedTiles);
                    if (attackedTiles.IndexOf(possiblemoves.SearchForKing(copyOfBoard, whoseTurn)) == -1)
                    {
                        
                    }
                    else
                    {
                       //write funciton that lists all moves white can move and then check if after any of those moves the check is still in place, if it is then game over!!
                        Coms.RenderComs(8);
                        continue;
                    }
                    moves.ExecuteMove(board, posToWhichMove / 10, posToWhichMove % 10, posOfPiece / 10, posOfPiece % 10, whoseTurn);
                } 
                else
                {
                    Coms.RenderComs(5);
                    continue;
                } 
                if (whoseTurn)
                    whoseTurn = false;
                else
                    whoseTurn = true;
            }
            
        }
    }
}
