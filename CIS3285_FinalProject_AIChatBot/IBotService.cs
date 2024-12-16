using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject_AIChatBot
{
    // This is an INterface for bot services to define a standared strucutre. 
    public interface IBotService
    {
        // This is an asynchhronous method to get a response from the bot. 
        Task<string> GetBotResponseAsync(string userInput);

    }
}
