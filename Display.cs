using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot
{
    public static class ConsoleEngine
    {
        // Helper class responsible for rendering the console UI and formatting bot/user output.
        // groups methods that print messages, prompts, and small animations to the terminal.

        // Colour constants used throughout the console rendering routines. They centralise visual theming so the UI is consistent.
        private const ConsoleColor colourBotOutput = ConsoleColor.Cyan;
        private const ConsoleColor colourUserInput = ConsoleColor.Green;
        private const ConsoleColor colourError = ConsoleColor.Red;
        private const ConsoleColor colourWarning = ConsoleColor.Yellow;
        private const ConsoleColor colourLogo = ConsoleColor.Magenta;
        private const ConsoleColor colourCyberCategory = ConsoleColor.Blue;

        public static void TitleScreen() 
        {
            // title screen and the ASCII art logo.
            // prints a large banner and the app title to the console.
            Console.ForegroundColor = colourLogo;
            Console.WriteLine();

            // ASCII art for "CYBER BOT"
            Console.WriteLine(@"
                                ..:...:...:...:..:...:...:...:..:...:...:...:..:...:...:...:..:...:...:...:..:...:...:...:..:...:...
                                :. .:. .:. .:. :. .:. .:. .:. :. .:. .:. .:. :. .:. .:. .:. :. .:. .:. .:. :. .:. .:. .:. :. .:. .:.
                                .:. .:. .:  .: .:. .:. .:  .: .:. .:. .:  .: .:. .:. .:. .: .:. .:. .:  .: .:. .:. .:  .: .:. .:. .
                                :...:...:...:..:...:...:...:..:...:..*###=...:...:..:+###=..:...:...:...:..:...:...:...:..:...:...:.
                                ....................................+#####*:......:+######:.........................................
                                ...................................-########+--:-+########*.........................................
                                ... ... ... .. ... ... ... .. ....*#######################- ... ... ... .. ... ... ... .. ... ... .
                                :...:...:...:..:...:...:...:..:...=########################*:...:...:...:..:...:...:...:..:...:...:.
                                ..:...:...:...:..:...:...:...:..:.*#########################:.:...:...:...:..:...:...:...:..:...:...
                                .................................:##########################+.......................................
                                .................................+###########################.......................................
                                .................................############################=......................................
                                ................................-############################*......................................
                                ................................+#############################:.....................................
                                ................................##############################=.....................................
                                ...............................:###############################.....................................
                                ................................:--=+++***##############**++=-:.....................................
                                ....................................................................................................
                                ....................................................................................................
                                ....................................................................................................
                                .......................:-=+***##*++-:......................:==+*###**+=-:...........................
                                .................-=++*##################*****++++++*****##################*++=-:....................
                                ...........:-=+##################################################################+=-:...............
                                .........-*###########################################################################-.............
                                :.  :. .-##############################################################################-. :.  :. .:.
                                ..:...:..:-+########################################################################+-...:..:...:...
                                .. ... ... .:.:=+*###########################################################*+=-:::. ... .. ... ...
                                ....................:---=++**######################################**++=---.........................
                                ...................:::::.......:.:---===+++++++**+++++++===---:.:......::.:--:......................
                                ..:...:...:...:..:-########+::.-=-.::...:..::..::..:...:..::..-=-.:..#########*-.:...:...:..:...:...
                                :...:...:...:..:=###########=.:=################################=...-############*::...:..:...:...:.
                                .:. .:. .:..:+##############=..#############-.:..-############*..:.-##############*+:. .: .:. .:. .
                                :...:...:..:+#################=..=#########+::...:.:+########*=.:...*#################*=..:...:...:.
                                ..:...:..:+####################-:..:-====-..:..:...:..-====-..:...:+#####################+:.:...:...
                                :. .:...+**#####################=.:. .:. .:. :. .:. .:. .:. :. .:+#######################**+..:. .:.
                                 .:. .:. .:  .:.-+###############+ .:. .:  .: .:. .:. .:  .: .:*#################*+-::. .: .:. .:. .
                                :...:...:...:..:...::.:=+*########*:..:...:..:...:...:...:..:*############+=-..:...:...:..:...:...:.
                                ............................=#######=.....................:+#########*=:............................
                                ..........................:+#########+:..................=###########+-:............................
                                 ... ... ... .. ... ....:+#############=:. .. ... ... .-*################+-:... ... ... .. ... ... .
                                :...:...:...:..:...:..:*#################-:..:...:...:=#####################*:.:...:...:..:...:...:.
                                ..:...:...:...:..:...::=*##################-:..:...:.*################+:.::..:...:...:...:..:...:...
                                ..........................:-=*##############*-......*############*-::...............................
                                ..............................:-+*############*=...*##########+-....................................
                                ..................................:=+*#########*..*########+-.......................................
                                .......................................=*######-.+#######+..........................................
                                ..........................................:+##*.-######=............................................
                                ..............................................:.*####+..............................................
                                ...............................................:###*:...............................................
                                ...............................................=##+.................................................
                                ...............................................+#=..................................................
                                ...............................................=-...................................................
                                ....................................................................................................
                                ....................................................................................................
                                ....................................................................................................
            ");
            Console.ForegroundColor = colourBotOutput;
            Console.WriteLine(@"    ==========================================");
            Console.WriteLine(@"    ||       CyberSecurity Awarness Bot      ||");
            Console.WriteLine(@"    ==========================================");

            Console.ResetColor();
            Console.WriteLine();
        }
        public static void LayoutDivider()
        {
            // Draw a horizontal divider to separate sections of the UI.
            // prints a line of characters to visually break up content.
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("  " + new string('─', 60));

            Console.ResetColor();
        }
        public static void LayoutSectionHeader(string sectionTitle)
        {
            // Render a section header with a title and padding.
            // shows the section name in a different colour so it stands out.
            Console.ForegroundColor = colourCyberCategory;

            
            int paddingCount = Math.Max(0, 50 - sectionTitle.Length);
            Console.WriteLine($"\n  || {sectionTitle} " + new string('=', paddingCount) + "||");

            Console.ResetColor();
        }
        public static void AnimatedText(string text, int characterDelay = 18, ConsoleColor renderColour = ConsoleColor.White)
        {
            // Print text one character at a time to create a typing animation effect.
            // loops through the string and sleeps briefly between characters.
            Console.ForegroundColor = renderColour;

            foreach (char character in text)
            {
                Console.Write(character);
                Thread.Sleep(characterDelay);
            }

            Console.WriteLine();
            Console.ResetColor();
        }
        public static void RenderBotResponse(string botMessage)
        {
            // Render a single-line bot response prefix and animate the accompanying message.
            // writes "BOT:" in a fixed colour then shows the message with animated text.
            Console.ForegroundColor = colourBotOutput;
            Console.Write("\n  BOT: ");
            Console.ResetColor();

            AnimatedText(botMessage, 12, ConsoleColor.White);
        }
        public static void MultiLineBotResponse(string botMessage)
        {
            // Render a multi-line bot response where each line is printed with a slight delay.
            // splits the message on newlines and prints each line indented for readability.
            Console.ForegroundColor = colourBotOutput;
            Console.WriteLine("\n  BOT:");
            Console.ResetColor();

            string[] outputLines = botMessage.Split('\n');

            foreach (string line in outputLines)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("     " + line);  
                Console.ResetColor();

                Thread.Sleep(25);
            }

            Console.WriteLine();
        }
        public static void WarningNotification(string alertMessage)
        {
            // Display a warning message in a prominent colour.
            // writes the provided alert text to the console.
            Console.ForegroundColor = colourWarning;
            Console.WriteLine($"\n  {alertMessage}");
            Console.ResetColor();
        }
        public static void ValidationError(string errorMessage)
        {
            // Display an error message for invalid user input.
            // prints the error text in red to indicate a problem.
            Console.ForegroundColor = colourError;
            Console.WriteLine($"\n  {errorMessage}");
            Console.ResetColor();
        }
        public static void UserInputPrompt(string userName)
        {
            // Show the user input prompt with the user's name in a distinct colour.
            // prints "<UserName>: " so the user knows where to type.
            Console.ForegroundColor = colourUserInput;

            
            Console.Write($"\n  {userName}: ");

            Console.ResetColor();
        }
        public static void RenderSecurityCategoryTag(string cyberCategory)
        {
            // Render a small tag indicating the security topic being discussed.
            // prints the topic label in a different colour for quick recognition.
            Console.ForegroundColor = colourCyberCategory;
            Console.WriteLine($"     Security domain: {cyberCategory}");
            Console.ResetColor();
        }
    }
}