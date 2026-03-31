using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot
{
    internal class UserInput
    {
        // Top-level container for user input related utilities.
        // groups services and helpers that validate what the user types.
        public class UserInputValidationService
        {
            // Maximum allowed length for a user's message. Protects the application from extremely long inputs.
            private const int MaximumInputCharacterLimit = 300;
            // Minimum meaningful length for a user's message. Prevents empty or trivially short queries.
            private const int MinimumInputCharacterLimit = 1;

            public bool ValidateUserInput(string rawInput, out string validationErrorMessage)
            {                
                // Check for a null reference or an empty string early to avoid downstream errors.
                if (string.IsNullOrEmpty(rawInput))
                {
                    // Simple: user didn't type anything.
                    // Complex: this guards against null input which could otherwise cause unexpected behaviour in other code paths.
                    validationErrorMessage = "Field cannot be empty. " +
                                             "Please type a message and press Enter.";
                    return false;
                }

                // Reject input that is only whitespace (spaces, tabs, newlines).
                if (string.IsNullOrWhiteSpace(rawInput))
                {
                    // input looks blank even if it contains spaces.
                    validationErrorMessage = "I didn't quite understand that. " +
                                             "Could you rephrase your question?";
                    return false;
                }

                string trimmedInput = rawInput.Trim();

                // Ensure the trimmed input meets the minimum character requirement.
                if (trimmedInput.Length < MinimumInputCharacterLimit)
                {
                    // too few characters to form a valid question.
                    validationErrorMessage = "Your response is too short. " +
                                             "Please provide a more detailed question so that I can better help you.";
                    return false;
                }

                // Enforce an upper bound to keep user messages reasonably sized.
                if (trimmedInput.Length > MaximumInputCharacterLimit)
                {
                    // text is too long.
                    validationErrorMessage = $"Your input exceeds the maximum length " +
                                             $"of {MaximumInputCharacterLimit} characters. " +
                                             $"Please summarise or shortne your question.";
                    return false;
                }

                // Disallow input that contains only digits (and spaces) because it's unlikely to be a valid question.
                if (IsInputNumericOnly(trimmedInput))
                {
                    // numbers-only input doesn't look like a question.
                    validationErrorMessage = "Your input appears to contain only numbers. " +
                                             "Please ask a cybersecurity-related question.";
                    return false;
                }

                validationErrorMessage = string.Empty;
                return true;
            }
            private bool IsInputNumericOnly(string trimmedInput)
            {
                // Determine whether the trimmed input consists solely of digits and optional spaces.
                foreach (char inputCharacter in trimmedInput)
                {
                    // If any character is not a digit or a space, the input is not numeric-only.
                    if (!char.IsDigit(inputCharacter) && inputCharacter != ' ')
                    {
                        return false;
                    }
                }

                // If we reached this point, every character was either a digit or a space.
                return true;
            }
        }
    }
}
