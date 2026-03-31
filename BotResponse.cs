using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot
{
    public class ChatBotResponse
    {
        // Represents a single canned response the bot can use.
        // stores a trigger word, the message to show, and a category label.
        public string TriggerKeyword { get; set; }

        // The text the bot will display when this response is selected.
        // the human-readable advice or explanation.
        public string BotAdvice { get; set; }

        // A short label describing the security category this response belongs to (e.g., "Malware", "Phishing").
        // used to tag or group replies.
        public string CyberCategory { get; set; }

        public ChatBotResponse(string triggerKeyword, string botAdvice, string cyberCategory)
        {
            TriggerKeyword = triggerKeyword;
            BotAdvice = botAdvice;
            CyberCategory = cyberCategory;
        }

        public ChatBotResponse()
        {
            // Parameterless constructor for object-initialiser syntax.
            // allows initialization with property setters instead of passing values to the constructor.
        }

        public override string ToString()
        {
            // Provide a compact, human-readable representation of the response for debugging or logging.
            // prints the category, trigger and advice on one line.
            return $"[{CyberCategory}] {TriggerKeyword}: {BotAdvice}";
        }
    }
}