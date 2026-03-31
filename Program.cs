using System;
using System.Threading;

namespace ChatBot
{
    internal class Program
    {
        private static string GetUserName()
        {
            // This method prompts the user for their name until they provide a valid, non-empty value.
            // it asks for input and blocks until the user types something meaningful.
            // it validates, trims whitespace, and normalises the first character to upper-case
            // so the name is presented in a friendly, consistent format throughout the program.
            string name = string.Empty;

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n  🤖 BOT: ");
                Console.ResetColor();
                Console.Write("What is your name? ");

                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    // Notify the user that the input was invalid and loop again.
                    ConsoleEngine.WarningNotification("Please enter your name to continue.");

                    // Reset name so the while loop continues prompting.
                    name = string.Empty;
                }
            }

            name = name.Trim();
            name = char.ToUpper(name[0]) + name.Substring(1);

            return name;
        }

        /// <summary>
        /// Program entry point.
        /// sets up the console UI, asks for the user's name, then runs a loop to accept questions and show answers.
        /// performs console initialisation, loads a knowledge base, validates user input, matches topics, and renders multi-line responses using helper UI functions.
        /// The loop continues until an exit command is detected.
        /// </summary>
        static void Main(string[] args)
        {
            // Set the window title so users can identify the application at a glance.
            Console.Title = "Cybersecurity Awareness Bot";

            // Try to ensure there is enough width for the UI layout; ignore failures on platforms that don't allow resizing.
            try
            {
                Console.WindowWidth = Math.Max(Console.WindowWidth, 85);
            }
            catch
            {
                // Silently ignore when console dimensions cannot be changed (e.g., some terminals or IDE consoles).
            }

            // Show title and initial UI elements that welcome the user.
            ConsoleEngine.TitleScreen();

            // Small pause to let the animated title render.
            System.Threading.Thread.Sleep(300);

            // Draw a divider line to separate UI sections.
            ConsoleEngine.LayoutDivider();

            // Animated welcome message — friendly, slightly stylised text output.
            ConsoleEngine.AnimatedText(
                "  Welcome to the South African Cybersecurity Awareness Bot!",
                characterDelay: 10,
                renderColour: ConsoleColor.Cyan);

            ConsoleEngine.AnimatedText(
                "  I'm here to help you stay safe online.\n",
                characterDelay: 10,
                renderColour: ConsoleColor.White);

            ConsoleEngine.LayoutDivider();

            // Ask the user for their name using the helper method above.
            string userName = GetUserName();

            // Greet the user and explain usage basics.
            ConsoleEngine.RenderBotResponse(
                $"Nice to meet you, {userName}! " +
                "I am your personal Cyber Security Awarness Bot. " +
                "You can ask me questions related to CyberSecurity and I will answer to the best of my ability\n" +
                "Type 'exit', 'quit', or 'bye' at any time to leave.");

            ConsoleEngine.LayoutDivider();

            // Prepare the knowledge base and input validation service used in the main loop.
            KnowledgeBase knowledgeBase = new KnowledgeBase();

            var inputChecker = new UserInput.UserInputValidationService();

            bool running = true;

            // Main interaction loop — runs until the user issues an exit command.
            while (running)
            {
                // Prompt for user input (shows the user's name in the prompt for context).
                ConsoleEngine.UserInputPrompt(userName);

                string rawInput = Console.ReadLine();

                // Validate the input using a small service; reject malformed or empty inputs.
                if (!inputChecker.ValidateUserInput(rawInput, out string errorMessage))
                {
                    ConsoleEngine.ValidationError(errorMessage);
                    continue;
                }

                // If the user typed an exit command, say goodbye and stop the loop.
                if (knowledgeBase.IsExitCommand(rawInput))
                {
                    ConsoleEngine.RenderBotResponse(
                        $"Goodbye, {userName}! Stay cyber-safe and always think before you click. 🔐");

                    running = false;
                    break;
                }

                // Try to find a canned reply that matches the user's input.
                BotReply matchedReply = knowledgeBase.FindReply(rawInput);

                if (matchedReply != null)
                {
                    // Render the category tag (e.g., "Malware") and the multi-line message.
                    ConsoleEngine.RenderSecurityCategoryTag(matchedReply.TopicLabel);
                    ConsoleEngine.MultiLineBotResponse(matchedReply.Message);
                }
                else
                {
                    // Fallback message when the bot does not recognise the topic.
                    ConsoleEngine.RenderBotResponse(
                        "I didn't quite understand that. Could you rephrase?\n" +
                        "Try asking about: phishing, passwords, malware, " +
                        "safe browsing, social engineering, or 2FA.");
                }

                // Draw a divider after the response and show closing hints before waiting for a keypress.
                ConsoleEngine.LayoutDivider();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n  Thank you for using the Cybersecurity Awareness Bot.");
                Console.WriteLine("  Press any key to close...");
                Console.ResetColor();

                // Pause so the user can read the final messages; waiting for any key to continue.
                Console.ReadKey();
            }
        }
    }
}