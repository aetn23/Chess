using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
   static class ListMoves
    {
        
        public static string RememberAsInt(int posLet, int posNum, string movesInt)
        {
            
            return string.Concat(movesInt, (posLet).ToString(), (posNum).ToString());
        }
        public static string RememberAsNotation(string pos, string movesNotation)
        {

            return string.Concat(movesNotation, pos);
        }
    }
}
