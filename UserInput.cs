using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot
{
    internal class UserInput
    {
        public class UserInputValidationService
        {
            private const int MaximumInputCharacterLimit = 300;
            private const int MinimumInputCharacterLimit = 1;

            public bool ValidateUserInput(string rawInput, out string validationErrorMessage)
            {                
                if (string.IsNullOrEmpty(rawInput))
                {
                    validationErrorMessage = "Field cannot be empty. " +
                                             "Please type a message and press Enter.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(rawInput))
                {
                    validationErrorMessage = "I didn't quite understand that. " +
                                             "Could you rephrase your question?";
                    return false;
                }

                string trimmedInput = rawInput.Trim();

                if (trimmedInput.Length < MinimumInputCharacterLimit)
                {
                    validationErrorMessage = "Your response is too short. " +
                                             "Please provide a more detailed question so that I can better help you.";
                    return false;
                }

                if (trimmedInput.Length > MaximumInputCharacterLimit)
                {
                    validationErrorMessage = $"Your input exceeds the maximum length " +
                                             $"of {MaximumInputCharacterLimit} characters. " +
                                             $"Please summarise or shortne your question.";
                    return false;
                }

                if (IsInputNumericOnly(trimmedInput))
                {
                    validationErrorMessage = "Your input appears to contain only numbers. " +
                                             "Please ask a cybersecurity-related question.";
                    return false;
                }

                validationErrorMessage = string.Empty;
                return true;
            }
            private bool IsInputNumericOnly(string trimmedInput)
            {
                foreach (char inputCharacter in trimmedInput)
                {
                    if (!char.IsDigit(inputCharacter) && inputCharacter != ' ')
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
