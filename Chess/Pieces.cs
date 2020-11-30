using System;

namespace Chess
{
    class Pieces
    {
        public ChessBoard WhichPiece(ChessBoard[,] board, int posLet, int posNum)
        {

            return board[(posLet), (posNum)]; // return the piece that was chosen by the player
        }
        public int InputToBoard(int posLet, int posNum) // UNUSED SICNE ITS CONTENT WAS TAKEN TO Transfrom.TransformToInt()
        {
            return ((posNum) - 1) * 10 + ((posLet) - 2); //input from the player comes in form of LETTERNUMEBER (E4, D4 like in chess), so we have to transfrom it. The GetInput does transrom it to numbers, but it has to be further chagned in order to have value that fit into array

        }
        public bool IsTaken(ChessBoard[,] board, int let, int num)
        {
            //determines if the positon where players wants to move is taken
            return board[let, num] != ChessBoard.empty ? false : true;
        }
        public bool IsPlayerPiece(ChessBoard piece, bool whoseTurn)
        {
            if (whoseTurn)
            {
                if (piece > 0)
                    return true;
                return false;
            }
            if (piece < 0)
                return true;
            return false;

        }
        public bool IsCheckMate(ChessBoard[,] board, bool whoseTurn)
        {

            return true;
        }
    }
    class PossbileMoves
    {
        Pieces pieces = new Pieces();
        public string PawnMove(ChessBoard[,] board, int posLet, int posNum, bool whoseTurn)
        {
            string possibleMoves = "";
            int i; 
            if (whoseTurn)
                i = 1;
            else
                i = -1;

            
            if (posNum + i < 8 && posNum + i >= 0 && posNum + i + i < 8 && posNum >= 0 && (board[posLet, posNum] == ChessBoard.whitePawnUnMoved || board[posLet, posNum] == ChessBoard.blackPawnUnMoved) && board[posLet, posNum + i] == ChessBoard.empty && board[posLet, posNum + i + i] == ChessBoard.empty)
                possibleMoves = string.Concat(possibleMoves, (posLet).ToString(), (posNum + i + i).ToString());
            if (posNum + i >= 0 && posNum + i < 8 && board[posLet, posNum + i] == ChessBoard.empty)
                possibleMoves = string.Concat(possibleMoves, (posLet).ToString(), (posNum + i).ToString());

           // Console.WriteLine("Pawn" + possibleMoves);
            return possibleMoves;
        }  
        public string EnPassant(ChessBoard[,] board, int posLet, int posNum, bool whoseTurn, string moves)
        {
            string possibleMoves = "";
            
            int leng = moves.Length, tmp;
            if (leng > 0)
                tmp = Convert.ToInt32(string.Concat(moves[leng - 2], moves[leng - 1]));
            else
                tmp = 0;
            int enPassantPawnLet = tmp / 10, enPassantPawnNum = tmp % 10;
            if ((posLet + 1 < 8 || posLet - 1 >= 0) && board[enPassantPawnLet, enPassantPawnNum] == ChessBoard.blackPawnAfterOneMove && posNum == 4 && enPassantPawnNum == 4 && (posLet + 1 == enPassantPawnLet || posLet - 1 == enPassantPawnLet))
                possibleMoves = string.Concat(possibleMoves, (enPassantPawnLet).ToString(), (enPassantPawnNum + 1).ToString());
            if ((posLet + 1 < 8 || posLet - 1 >= 0) && board[enPassantPawnLet, enPassantPawnNum] == ChessBoard.whitePawnAfterOneMove && posNum == 3 && enPassantPawnNum == 3 && (posLet + 1 == enPassantPawnLet || posLet - 1 == enPassantPawnLet))
                possibleMoves = string.Concat(possibleMoves, (enPassantPawnLet).ToString(), (enPassantPawnNum - 1).ToString());

            return possibleMoves;
        }
        public string PawnAttack(ChessBoard[,] board, int posLet, int posNum, bool whoseTurn)
        {
            string possibleMoves = "";
            int i;
            if (whoseTurn)
                i = 1;
            else
                i = -1;
            if (posLet + i >= 0 && posLet + i < 8 && posNum + 1 >= 0 && posNum + i < 8 && board[posLet, posNum] > board[posLet + i, posNum + i] && board[posLet + i, posNum + i] !=0 && whoseTurn)
                possibleMoves = string.Concat(possibleMoves, (posLet + i).ToString(), (posNum + i).ToString());
            if (posLet - i >= 0 && posLet - i < 8 && posNum + 1 >= 0 && posNum + i < 8 && board[posLet, posNum] > board[posLet - i, posNum + i] && board[posLet - i, posNum + i] != 0 && whoseTurn)
                possibleMoves = string.Concat(possibleMoves, (posLet - i).ToString(), (posNum + i).ToString());
            if (posLet + i >= 0 && posLet + i < 8 && posNum + 1 >= 0 && posNum + i < 8 && board[posLet, posNum] < board[posLet + i, posNum + i] && !whoseTurn && board[posLet + i, posNum + i] != 0)
                possibleMoves = string.Concat(possibleMoves, (posLet + i).ToString(), (posNum + i).ToString());
            if (posLet - i >= 0 && posLet - i < 8 && posNum + 1 >= 0 && posNum + i < 8 && board[posLet, posNum] < board[posLet - i, posNum + i] && !whoseTurn && board[posLet - i, posNum + i] != 0)
                possibleMoves = string.Concat(possibleMoves, (posLet - i).ToString(), (posNum + i).ToString());




            return possibleMoves;
        }
        public string Tower(ChessBoard[,] board, int posLet, int posNum, bool whoseTurn)
        {
            string possibleMoves = "";

            for (int i = posLet + 1; i < 8; i++)
            {
                if (board[i, posNum] == ChessBoard.empty)
                {
                    possibleMoves = string.Concat(possibleMoves, i.ToString(), (posNum).ToString());
                }
                else if (pieces.IsPlayerPiece(board[i, posNum], whoseTurn))
                    break;

                else if (!pieces.IsPlayerPiece(board[i, posNum], whoseTurn))
                {

                    possibleMoves = string.Concat(possibleMoves, i.ToString(), (posNum).ToString());
                    break;
                }

            }
            for (int i = posLet - 1; i >= 0; i--)
            {
                if (board[i, posNum] == ChessBoard.empty)
                {
                    possibleMoves = string.Concat(possibleMoves, i.ToString(), (posNum).ToString());
                }
                else if (pieces.IsPlayerPiece(board[i, posNum], whoseTurn))
                    break;

                else if (!pieces.IsPlayerPiece(board[i, posNum], whoseTurn))
                {

                    possibleMoves = string.Concat(possibleMoves, i.ToString(), (posNum).ToString());
                    break;
                }

            }


            for (int i = posNum + 1; i < 8; i++)
            {

                if (board[posLet, i] == ChessBoard.empty)
                {

                    possibleMoves = string.Concat(possibleMoves, (posLet).ToString(), i.ToString());
                }
                else if (pieces.IsPlayerPiece(board[posLet, i], whoseTurn))
                    break;

                else if (!pieces.IsPlayerPiece(board[posLet, i], whoseTurn))
                {

                    possibleMoves = string.Concat(possibleMoves, (posLet).ToString(), i.ToString());
                    break;
                }

            }

            for (int i = posNum - 1; i >= 0; i--)
            {

                if (board[posLet, i] == ChessBoard.empty)
                {

                    possibleMoves = string.Concat(possibleMoves, (posLet).ToString(), i.ToString());
                }
                else if (pieces.IsPlayerPiece(board[posLet, i], whoseTurn))
                    break;

                else if (!pieces.IsPlayerPiece(board[posLet, i], whoseTurn))
                {

                    possibleMoves = string.Concat(possibleMoves, (posLet).ToString(), i.ToString());
                    break;
                }
            }

            return possibleMoves;
        }
        public string Bishop(ChessBoard[,] board, int posLet, int posNum, bool whoseTurn)
        {
            Transform transform = new Transform();
            string possibleMoves = "";
            int i = posLet + 1;
            int j = posNum + 1;
            while (i < 8 && j < 8)
            {
                if (board[i, j] == ChessBoard.empty)
                    possibleMoves = string.Concat(possibleMoves, i.ToString(), j.ToString());
                else if (pieces.IsPlayerPiece(board[i, j], whoseTurn))
                    break;
                else if (!pieces.IsPlayerPiece(board[i, j], whoseTurn))
                {
                    possibleMoves = string.Concat(possibleMoves, i.ToString(), j.ToString());
                    break;
                }
                i++;
                j++;
            }
            i = posLet - 1;
            j = posNum - 1;
            while (i >= 0 && j >= 0)
            {
                if (board[i, j] == ChessBoard.empty)
                    possibleMoves = string.Concat(possibleMoves, i.ToString(), j.ToString());
                else if (pieces.IsPlayerPiece(board[i, j], whoseTurn))
                    break;
                else if (!pieces.IsPlayerPiece(board[i, j], whoseTurn))
                {
                    Console.WriteLine("asdasd");
                    possibleMoves = string.Concat(possibleMoves, i.ToString(), j.ToString());
                    break;
                }
                i--;
                j--;
            }
            i = posLet - 1;
            j = posNum + 1;
            while (i >= 0 && j < 8)
            {
                if (board[i, j] == ChessBoard.empty)
                    possibleMoves = string.Concat(possibleMoves, i.ToString(), j.ToString());
                else if (pieces.IsPlayerPiece(board[i, j], whoseTurn))
                    break;
                else if (!pieces.IsPlayerPiece(board[i, j], whoseTurn))
                {
                    possibleMoves = string.Concat(possibleMoves, i.ToString(), j.ToString());
                    break;
                }
                i--;
                j++;
            }
            i = posLet + 1;
            j = posNum - 1;
            while (i < 8 && j >= 0)
            {
                if (board[i, j] == ChessBoard.empty)
                    possibleMoves = string.Concat(possibleMoves, i.ToString(), j.ToString());
                else if (pieces.IsPlayerPiece(board[i, j], whoseTurn))
                    break;
                else if (!pieces.IsPlayerPiece(board[i, j], whoseTurn))
                {
                    possibleMoves = string.Concat(possibleMoves, i.ToString(), j.ToString());
                    break;
                }
                i++;
                j--;
            }
            Console.WriteLine("Ruchy Bishopp ");
            transform.test(possibleMoves);
            return possibleMoves;
        }
        public string Queen(ChessBoard[,] board, int posLet, int posNum, bool whoseTurn)
        {
            return string.Concat(Bishop(board, posLet, posNum, whoseTurn), Tower(board, posLet, posNum, whoseTurn));
        }
        public string King(ChessBoard[,] board, int posLet, int posNum, bool whoseTurn)
        {//yeah this is lame, but it is still the fastest way to perfome this check so yeah
            //i think the fastest
            string possibleMoves = "";

            if (posLet + 1 < 8 && (board[posLet + 1, posNum] == ChessBoard.empty || !pieces.IsPlayerPiece(board[posLet + 1, posNum], whoseTurn)))
                possibleMoves = string.Concat(possibleMoves, (posLet + 1).ToString(), (posNum).ToString());
            if (posNum + 1 < 8 && (board[posLet, posNum + 1] == ChessBoard.empty || !pieces.IsPlayerPiece(board[posLet, posNum + 1], whoseTurn)))
                possibleMoves = string.Concat(possibleMoves, (posLet).ToString(), (posNum + 1).ToString());
            if (posLet + 1 < 8 && posNum + 1 < 8 && (board[posLet + 1, posNum + 1] == ChessBoard.empty || posLet + 1 < 8 && posNum + 1 < 8 && !pieces.IsPlayerPiece(board[posLet + 1, posNum + 1], whoseTurn)))
                possibleMoves = string.Concat(possibleMoves, (posLet + 1).ToString(), (posNum + 1).ToString());
            if (posLet - 1 >= 0 && (board[posLet - 1, posNum] == ChessBoard.empty || (posLet - 1 >= 0 && !pieces.IsPlayerPiece(board[posLet - 1, posNum], whoseTurn))))
                possibleMoves = string.Concat(possibleMoves, (posLet - 1).ToString(), (posNum).ToString());
            if (posLet - 1 >= 0 && posNum -1 >= 0 && (board[posLet - 1, posNum - 1] == ChessBoard.empty || posLet - 1 >= 0 && posNum - 1 >= 0 && !pieces.IsPlayerPiece(board[posLet - 1, posNum - 1], whoseTurn)))
                possibleMoves = string.Concat(possibleMoves, (posLet - 1).ToString(), (posNum - 1).ToString());
            if (posNum - 1 >= 0 && (board[posLet, posNum - 1] == ChessBoard.empty || posNum - 1 >= 0 && !pieces.IsPlayerPiece(board[posLet, posNum - 1], whoseTurn)))
                possibleMoves = string.Concat(possibleMoves, (posLet).ToString(), (posNum - 1).ToString());
            if (posLet - 1 >= 0 && posNum + 1 < 8 && (board[posLet - 1, posNum + 1] == ChessBoard.empty || posLet - 1 >= 0 && !pieces.IsPlayerPiece(board[posLet - 1, posNum + 1], whoseTurn)))
                possibleMoves = string.Concat(possibleMoves, (posLet - 1).ToString(), (posNum + 1).ToString());
            if (posLet + 1 < 8 && posNum - 1 >= 0 && (board[posLet + 1, posNum - 1] == ChessBoard.empty || posLet + 1 < 8 && !pieces.IsPlayerPiece(board[posLet + 1, posNum - 1], whoseTurn)))
                possibleMoves = string.Concat(possibleMoves, (posLet + 1).ToString(), (posNum - 1).ToString());

            if (((board[posLet, posNum] == ChessBoard.whiteKingUnMoved && board[posLet + 3, posNum] == ChessBoard.whiteTowerUnMoved) || board[posLet, posNum] == ChessBoard.blackKingUnMoved && board[posLet + 3, posNum] == ChessBoard.blackTowerUnMoved) && board[posLet + 2, posNum] == ChessBoard.empty && board[posLet + 1, posNum] == ChessBoard.empty)
                possibleMoves = string.Concat(possibleMoves, (posLet + 2).ToString(), (posNum).ToString());
            if (((board[posLet, posNum] == ChessBoard.whiteKingUnMoved && board[posLet - 4, posNum] == ChessBoard.whiteTowerUnMoved) || board[posLet, posNum] == ChessBoard.blackKingUnMoved && board[posLet - 4, posNum] == ChessBoard.blackTowerUnMoved) && board[posLet - 3, posNum] == ChessBoard.empty && board[posLet - 2, posNum] == ChessBoard.empty && board[posLet - 1, posNum] == ChessBoard.empty)
                possibleMoves = string.Concat(possibleMoves, (posLet - 3).ToString(), (posNum).ToString());
            //have to perfom later addintonal check to deterine if one of the tiles that king is passing on isnt attacked
            return possibleMoves;
        }
        public string Knight(ChessBoard[,] board, int posLet, int posNum, bool whoseTurn)
        {//this again seems to be lame, but there is no better way soooo yeahh
            string possibleMoves = "";
            if (posLet + 2 < 8 && posNum + 1 < 8 && (board[posLet + 2, posNum + 1]) == ChessBoard.empty || posLet + 2 < 8 && posNum + 1 < 8 && !pieces.IsPlayerPiece(board[posLet + 2, posNum + 1], whoseTurn))
                possibleMoves = string.Concat(possibleMoves, (posLet + 2).ToString(), (posNum + 1).ToString());
            if (posLet + 1 < 8 && posNum + 2 < 8 && (board[posLet + 1, posNum + 2]) == ChessBoard.empty || posLet + 1 < 8 && posNum + 2 < 8 && !pieces.IsPlayerPiece(board[posLet + 1, posNum + 2], whoseTurn))
                possibleMoves = string.Concat(possibleMoves, (posLet + 1).ToString(), (posNum + 2).ToString());
            if ((posLet - 2 >= 0 && posNum - 1 >= 0) && (board[posLet - 2, posNum - 1]) == ChessBoard.empty || posLet - 2 >= 0 && posNum - 1 >= 0 && !pieces.IsPlayerPiece(board[posLet - 2, posNum - 1], whoseTurn))
                possibleMoves = string.Concat(possibleMoves, (posLet - 2).ToString(), (posNum - 1).ToString());
            if (posLet - 1 >= 0 && posNum - 2 >= 0 && (board[posLet - 1, posNum - 2]) == ChessBoard.empty || posLet - 1 >= 0 && posNum - 2 >= 0 && !pieces.IsPlayerPiece(board[posLet - 1, posNum - 2], whoseTurn))
                possibleMoves = string.Concat(possibleMoves, (posLet - 1).ToString(), (posNum - 2).ToString());
            if (posLet + 2 < 8 && posNum - 1 >=0  && (board[posLet + 2, posNum - 1]) == ChessBoard.empty || posLet + 2 < 8 && posNum - 1 >= 0 && !pieces.IsPlayerPiece(board[posLet + 2, posNum - 1], whoseTurn))
                possibleMoves = string.Concat(possibleMoves, (posLet + 2).ToString(), (posNum - 1).ToString());
            if (posLet - 2 >=0 && posNum + 1 < 8 && (board[posLet - 2, posNum + 1]) == ChessBoard.empty || posLet - 2 >= 0 && posNum + 1 < 8 && !pieces.IsPlayerPiece(board[posLet - 2, posNum + 1], whoseTurn))
                possibleMoves = string.Concat(possibleMoves, (posLet - 2).ToString(), (posNum + 1).ToString());
            if (posLet - 1 >=0 && posNum + 2 < 8 && (board[posLet - 1, posNum + 2]) == ChessBoard.empty || posLet - 1 >= 0 && posNum + 2 < 8&&!pieces.IsPlayerPiece(board[posLet - 1, posNum + 2], whoseTurn))
                possibleMoves = string.Concat(possibleMoves, (posLet - 1).ToString(), (posNum + 2).ToString());
            if (posLet + 1 < 8 && posNum - 2 >=0 && (board[posLet + 1, posNum - 2]) == ChessBoard.empty || posLet + 1 < 8 && posNum - 2 >= 0&& !pieces.IsPlayerPiece(board[posLet + 1, posNum - 2], whoseTurn))
                possibleMoves = string.Concat(possibleMoves, (posLet + 1).ToString(), (posNum - 2).ToString());
            return possibleMoves;
        }
        public string SearchForKing(ChessBoard[,] board, bool whoseTurn)
        {
            string kingPos = "";
            if (whoseTurn)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board[i, j] == ChessBoard.whiteKing || board[i, j] == ChessBoard.whiteKingUnMoved)
                            kingPos = string.Concat(i.ToString(), j.ToString());
                        //, Console.WriteLine(attackedTiles);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board[i, j] == ChessBoard.blackKing || board[i, j] == ChessBoard.blackKingUnMoved)
                            kingPos = string.Concat(i.ToString(), j.ToString());
                        //, Console.WriteLine(attackedTiles);
                    }
                }
            }
            return kingPos;
        }
    }
}
