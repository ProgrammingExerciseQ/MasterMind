using System;

namespace MasterMind
{
    public class Validator
    {
        public bool ValidateGuess(string guess, ref string message)
        {
            bool isValid = false;

            isValid = CheckLength(guess, ref message);
            if (isValid)
            {
                isValid = CheckNumeric(guess, ref message);
                if (isValid)
                {
                    isValid = CheckDigits(guess, ref message);
                }
            }

            return isValid;
        }

        private bool CheckLength(string guess, ref string message)
        {
            bool isValid = false;

            if (guess.Length == 4)
            {
                isValid = true;
            }
            else
            {
                message = "Improper Length: Each guess should be 4 digits in length.";
            }

            return isValid;
        }

        private bool CheckNumeric(string guess, ref string message)
        {
            bool isValid = false;

            int parsedGuess = 0;
            if (Int32.TryParse(guess, out parsedGuess) == true)
            {
                isValid = true;
            }
            else
            {
                message = "Not numeric: Each guess should be numeric.";
            }

            return isValid;
        }

        // check that each digit is between 1 and 6
        private bool CheckDigits(string guess, ref string message)
        {
            bool isValid = false;

            if (Convert.ToInt32(guess[0].ToString()) > 1 && Convert.ToInt32(guess[0].ToString()) < 6 &&
                Convert.ToInt32(guess[1].ToString()) > 1 && Convert.ToInt32(guess[1].ToString()) < 6 &&
                Convert.ToInt32(guess[2].ToString()) > 1 && Convert.ToInt32(guess[2].ToString()) < 6 &&
                Convert.ToInt32(guess[3].ToString()) > 1 && Convert.ToInt32(guess[3].ToString()) < 6)
            {
                isValid = true;
            }
            else
            {
                message = "Invalid Range: Each digit should be between 1 and 6 (eg. 2, 3, 4, 5).";
            }

            return isValid;
        }
    }
}
