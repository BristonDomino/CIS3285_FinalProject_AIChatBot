using Google.Cloud.Dialogflow.Cx.V3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject_AIChatBot
{
    // Serivce class for interacting with the Dialogflow bot
    public class DialogflowBotService : IBotService
    {
        // This here is a Dpendency-injected Dialogflow session client and session path
        private readonly SessionsClient _sessionsClient;
        private readonly string _sessionPath;

        // This is an constctrutr with Dependency Injection for better testability and flexibility 
        public DialogflowBotService(SessionsClient sessionsClient, string sessionPath)
        {
            _sessionsClient = sessionsClient;
            _sessionPath = sessionPath;
        }

        /// <summary>
        /// Sends the user's input to Dialogflow and retrieves the bot's response asynchronously.
        /// </summary>
        /// <param name="userInput">The user's message or query.</param>
        /// <returns>The bot's response as a string.</returns>
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

            // Call Dialogflow CX API to dialogflow and send the user input
            var response = await _sessionsClient.DetectIntentAsync(new DetectIntentRequest
            {
                Session = _sessionPath,
                QueryInput = queryInput
            });

            // This code here will return the bot's first text reponse if it is available
            return response.QueryResult.ResponseMessages[0].Text.Text_[0];
        }
    }

}
