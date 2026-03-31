using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatBot
{
    public class BotReply
    {
        // Represents a single canned reply in the knowledge base.
        // holds a topic label and the message to show to the user.
        public string TopicLabel { get; set; }
        public string Message { get; set; }

        public BotReply(string topicLabel, string message)
        {
            TopicLabel = topicLabel;
            Message = message;
        }
    }

    public class KnowledgeBase
    {
        // A compact in-memory list of predefined bot replies.
        // this is where the bot looks up answers to common questions.
        private readonly List<BotReply> _responses = new()
        {
            new BotReply("phishing", "Phishing is a cyber attack technique where attackers impersonate legitimate entities to deceive individuals into providing sensitive information, such as passwords, credit card numbers, or other personal data. Phishing attacks often occur through email, social media, or messaging platforms, where attackers create fake websites or send fraudulent messages to trick victims into revealing their information."),
            new BotReply("passwords", "Use long, unique passwords and a password manager. Avoid reuse."),
            new BotReply("malware", "Malware is a type of software designed to cause damage to a computer, server, client, or computer network. It can take various forms, including viruses, worms, trojans, ransomware, spyware, adware, and more. Malware can be used for various malicious purposes, such as stealing sensitive information, disrupting operations, or gaining unauthorized access to systems."),
            new BotReply("2FA", "Enable two-factor authentication where possible for extra security."),
            new BotReply("cybersecurity", "Cybersecurity refers to the practice of protecting computer systems, networks, and data from unauthorized access, attacks, damage, or theft. It involves implementing measures such as firewalls, encryption, antivirus software, and security protocols to safeguard against cyber threats and ensure the confidentiality, integrity, and availability of information."),
            new BotReply("firewall", "A firewall is a network security device or software that monitors and controls incoming and outgoing network traffic based on predetermined security rules. Firewalls can be hardware-based, software-based, or a combination of both. They act as a barrier between a trusted internal network and untrusted external networks, such as the internet, to prevent unauthorized access and protect against cyber threats."),
        };

        private readonly string[] _exitCommands = new[] { "exit", "quit", "bye" };

        public bool IsExitCommand(string input)
        {
            // If the input is empty or only whitespace, it's not an exit command.
            if (string.IsNullOrWhiteSpace(input)) return false;

            // Normalise the input: trim whitespace and lower-case for case-insensitive comparison.
            var trimmed = input.Trim().ToLowerInvariant();

            // Check whether the normalised input exactly matches any of the configured exit tokens.
            return _exitCommands.Contains(trimmed);
        }

        public BotReply FindReply(string input)
        {
            // Return null immediately for empty input; nothing to match.
            if (string.IsNullOrWhiteSpace(input)) return null;

            // Lower-case the input to perform case-insensitive substring matching.
            var lowered = input.ToLowerInvariant();

            // return the first one whose topic label appears in the user's input.
            // checks if the user's text contains the topic word.
            foreach (var resp in _responses)
            {
                if (lowered.Contains(resp.TopicLabel.ToLowerInvariant()))
                    return resp;
            }

            // No match found.
            return null;
        }
    }
}
