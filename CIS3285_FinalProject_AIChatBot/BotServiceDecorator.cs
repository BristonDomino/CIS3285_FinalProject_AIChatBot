using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject_AIChatBot
{
    /// <summary>
    /// Decorator class for adding additional functionality to an existing IBotService implementation.
    /// Implements the IBotService interface.
    /// </summary>
    public class BotServiceDecorator : IBotService
    {
        // Reference to the original bot service being decorated.
        private readonly IBotService _decoratedBotService;

        /// <summary>
        /// Constructor for the BotServiceDecorator.
        /// Accepts an existing implementation of IBotService.
        /// </summary>
        /// <param name="botService">The bot service to decorate.</param>
        public BotServiceDecorator(IBotService botService)
        {
            _decoratedBotService = botService;
        }

        /// <summary>
        /// Method to get the bot's response.
        /// This method decorates the original GetBotResponseAsync by adding logging functionality.
        /// </summary>
        /// <param name="userInput">The user's input string.</param>
        /// <returns>The bot's response string.</returns>
        public async Task<string> GetBotResponseAsync(string userInput)
        {
            // this will call the original bot service
            string response = await _decoratedBotService.GetBotResponseAsync(userInput);

            // this will log the input and response
            LogResponse(userInput, response);

            return response;
        }

        /// <summary>
        /// Logs the user's input and bot's response to the console.
        /// </summary>
        /// <param name="userInput">The user's input.</param>
        /// <param name="response">The bot's response.</param>
        private void LogResponse(string userInput, string response)
        {
            Console.WriteLine($"[Log] User: {userInput}");
            Console.WriteLine($"[Log] Bot: {response}");
        }
    }
}
