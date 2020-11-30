using System;

namespace Chess
{
    class UserInput
    {
        public int GetInput()
        {
            string tmp = Console.ReadLine();
            tmp = tmp.Trim();
            if (CheckInput(tmp))
            {
                Transform transfrom = new Transform();
                return transfrom.TransformToInt(tmp);
            }
            else
            {
                Coms.RenderComs(2);
                return GetInput();
            }

        }
        private bool CheckInput(string tmp)
        {
            if (tmp.Length != 2)
                return false;
            else if (tmp[0] < 'A' || tmp[0] > 'H' || tmp[1] < '1' || tmp[1] > '8')
                return false;
            return true;

        }
        public string GetPromotionInput()
        {
            string input = Console.ReadLine();
            if (CheckPromotionInput(input))
                return input;
            Coms.RenderComs(2);
            return GetPromotionInput();
        }
        private bool CheckPromotionInput(string input)
        {
            if (input.Length == 1 && input[0] == 'K' || input[0] == 'B' && input[0] == 'T' && input[0] == 'Q')
                return true;
            else
                return false;
        }
    }
}
