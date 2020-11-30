using System;
using System.Text;

namespace Chess
{
    class Transform
    {
        public int TransformToInt(string pos)
        {
            StringBuilder stringbulider = new StringBuilder(pos);
            stringbulider.Insert(0, ((char)(int)(pos[0] - 15)));
            stringbulider.Remove(1, 1);
            string tmpAsInt = stringbulider.ToString();
            int posToArray = Convert.ToInt32(tmpAsInt);
            //Console.WriteLine(((posToArray / 10) - 2) * 10 + ((posToArray % 10) - 1));
            return ((posToArray / 10) - 2) * 10 + ((posToArray % 10) - 1);
        }
        public string TransformToOneMove(string pos, int i = 0)
        {
            return string.Concat(pos[i], pos[i + 1]);
        }
        public string TransformFromIntToNotation(string pos ) // for debug and better understanding, will use latter to list and save every possible move
        {
            if(pos.Length !=0)
                return string.Concat(((char)(pos[0] + 17)), (pos[1] + 1 - '0'));
            return "";
        }
       
        public void test(string pos)
        {
           
            string ruchy = "";
            int leng = pos.Length;
            for (int i = 0; i < leng - 1; i = i + 2)
            {
                ruchy = string.Concat(ruchy, TransformFromIntToNotation(TransformToOneMove(pos, i)));
            }
            Console.WriteLine(ruchy);
        }
        
    }
}
