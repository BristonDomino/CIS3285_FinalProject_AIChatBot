using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject_AIChatBot
{
    public abstract class ChatBot
    {
        public abstract string BotType { get; }
        public virtual void StartConversation()
        {
            Console.WriteLine($"Starting a conversation with a {BotType}.");
        }
    }
}
