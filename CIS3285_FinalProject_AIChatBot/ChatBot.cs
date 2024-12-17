using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject_AIChatBot
{
    /// <summary>
    /// Abstract class representing a generic chatbot.
    /// Defines the structure and behavior for all chatbots.
    /// </summary>
    public abstract class ChatBot
    {
        /// <summary>
        /// Gets the type of bot (e.g., BasicBot, AdvancedBot).
        /// I will added basicBot and advancedBot in the future when I can figure it out how from Google's Dialog flow CX
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract string BotType { get; }

        /// <summary>
        /// Starts a conversation with the bot.
        /// Displays a starting message including the bot type.
        /// </summary>
        public virtual void StartConversation()
        {
            Console.WriteLine($"Starting a conversation with a {BotType}.");
        }
    }
}
