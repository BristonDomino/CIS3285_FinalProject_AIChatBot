using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject_AIChatBot
{
    public class BotServiceDecorator : IBotService
    {
        private readonly IBotService _decoratedBotService;

        public BotServiceDecorator(IBotService botService)
        {
            _decoratedBotService = botService;
        }

        public async Task<string> GetBotResponseAsync(string userInput)
        {
            // this will call the original bot service
            string response = await _decoratedBotService.GetBotResponseAsync(userInput);

            // this will log the input and response
            LogResponse(userInput, response);

            return response;
        }

        private void LogResponse(string userInput, string response)
        {
            Console.WriteLine($"[Log] User: {userInput}");
            Console.WriteLine($"[Log] Bot: {response}");
        }
    }
}
