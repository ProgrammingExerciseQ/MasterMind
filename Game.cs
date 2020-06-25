using MasterMind.Model;
using System;
using System.Security.Cryptography;

namespace MasterMind
{
    public class Game
    {
        private Answer _answer;
        private Validator _validator;
        private readonly RNGCryptoServiceProvider _rngCryptoServiceProvider;

        private const string _correctNumberCorrectPosition = "+";
        private const string _correctNumberWrongPosition = "-";

        public Game()
        {
            _rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            _validator = new Validator();

            _answer = new Answer
            {
                FirstDigit = GetRandomInteger(2, 5), // note that "between" => excluding endpoints 1 and 6
                SecondDigit = GetRandomInteger(2, 5), // note that "between" => excluding endpoints 1 and 6
                ThirdDigit = GetRandomInteger(2, 5), // note that "between" => excluding endpoints 1 and 6
                FourthDigit = GetRandomInteger(2, 5) // note that "between" => excluding endpoints 1 and 6
            };
        }


        public string CheckAnswer(string guess)
        {
            string message = string.Empty;

            if (_validator.ValidateGuess(guess, ref message) == true)
            {
                CompareGuessWithAnswer(guess, ref message);
            }

            return message;
        }

        private void CompareGuessWithAnswer(string guess, ref string message)
        {
            if (Convert.ToInt32(guess) == _answer.FullAnswer)
            {
                message = "Success! You're a winner!";
            }
            else
            {
                Response response = new Response
                {
                    FirstChar = GetCombinationSymbol(Convert.ToInt32(guess[0].ToString()), _answer.FirstDigit),
                    SecondChar = GetCombinationSymbol(Convert.ToInt32(guess[1].ToString()), _answer.SecondDigit),
                    ThirdChar = GetCombinationSymbol(Convert.ToInt32(guess[2].ToString()), _answer.ThirdDigit),
                    FourthChar = GetCombinationSymbol(Convert.ToInt32(guess[3].ToString()), _answer.FourthDigit)
                };

                message = response.FullResponse;
            }
        }

        private string GetCombinationSymbol(int guessDigit, int answerDigit)
        {
            string symbol = string.Empty;

            if (guessDigit == answerDigit)
            {
                symbol = _correctNumberCorrectPosition;
            }
            else if (_answer.FullAnswer.ToString().Contains(guessDigit.ToString()))
            {
                symbol = _correctNumberWrongPosition;
            }

            return symbol;
        }

        // rngCrypto code based off this article: 
        // http://csharphelper.com/blog/2014/08/use-a-cryptographic-random-number-generator-in-c/
        private int GetRandomInteger(int min, int max)
        {
            uint scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                // Get four random bytes.
                byte[] four_bytes = new byte[4];
                _rngCryptoServiceProvider.GetBytes(four_bytes);

                // Convert that into an uint.
                scale = BitConverter.ToUInt32(four_bytes, 0);
            }

            // Add min to the scaled difference between max and min.
            return (int)(min + (max - min) *
                (scale / (double)uint.MaxValue));
        }
    }
}
