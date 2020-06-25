using System;

namespace MasterMind
{
    public class Answer
    {
        public int FirstDigit { get; set; }
        public int SecondDigit { get; set; }
        public int ThirdDigit { get; set; }
        public int FourthDigit { get; set; }

        public int FullAnswer 
        {
            get
            {
                return Convert.ToInt32(FirstDigit.ToString() + SecondDigit.ToString() + ThirdDigit.ToString() + FourthDigit.ToString());
            }
        }
    }
}
