using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot
{
    public class ChatBotResponse
    {
        public string TriggerKeyword { get; set; }

        public string BotAdvice { get; set; }

        public string CyberCategory { get; set; }

        public ChatBotResponse(string triggerKeyword, string botAdvice, string cyberCategory)
        {
            TriggerKeyword = triggerKeyword;
            BotAdvice = botAdvice;
            CyberCategory = cyberCategory;
        }

        public ChatBotResponse()
        {
            // Parameterless constructor for object-initialiser syntax
        }

        public override string ToString()
        {
            return $"[{CyberCategory}] {TriggerKeyword}: {BotAdvice}";
        }
    }
}