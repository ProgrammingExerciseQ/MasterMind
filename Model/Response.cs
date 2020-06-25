namespace MasterMind.Model
{
    public class Response
    {
        public string FirstChar { get; set; }
        public string SecondChar { get; set; }
        public string ThirdChar { get; set; }
        public string FourthChar { get; set; }

        public string FullResponse
        {
            get
            {
                return string.Concat(
                    string.IsNullOrEmpty(FirstChar) ? " " : FirstChar, 
                    string.IsNullOrEmpty(SecondChar) ? " " : SecondChar,
                    string.IsNullOrEmpty(ThirdChar) ? " " : ThirdChar,
                    string.IsNullOrEmpty(FourthChar) ? " " : FourthChar);
            }
        }
    }
}
