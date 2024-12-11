using Google.Cloud.Dialogflow.Cx.V3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject_AIChatBot
{
    internal class DialogflowBotService : IBotService
    {
        private readonly SessionsClient _sessionsClient;
        private readonly string _sessionPath;

        public DialogflowBotService(SessionsClient sessionsClient, string sessionPath)
        {
            _sessionsClient = sessionsClient;
            _sessionPath = sessionPath;
        }

        public async Task<string> GetBotResponseAsync(string userInput)
        {
            // Create the text input
            var textInput = new TextInput { Text = userInput };

            // Create the query input
            var queryInput = new QueryInput
            {
                Text = textInput,
                LanguageCode = "en"
            };

            // Call Dialogflow CX API
            var response = await _sessionsClient.DetectIntentAsync(new DetectIntentRequest
            {
                Session = _sessionPath,
                QueryInput = queryInput
            });

            // Return the bot's response
            return response.QueryResult.ResponseMessages[0].Text.Text_[0];
        }
    }

}
