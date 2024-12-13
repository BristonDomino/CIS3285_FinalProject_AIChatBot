using System;
using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using static Google.Rpc.Context.AttributeContext.Types;
using Google.Cloud.Dialogflow.Cx.V3;
using CIS3285_FinalProject_AIChatBot;

//save
class Program
{
    static async Task Main(string[] args)
    {
        // Set the environment variable for credentials
        System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\bdddo.BRISTONSDESKTOP\OneDrive\files that can't be upload to school drive\Fall 2024\Software Design\Finual project\Jason file\winged-sol-443923-e8-c1cc1b1c1615.json");

        // Create a session client
        string projectId = "winged-sol-443923-e8";
        string location = "global";
      //  string agentId = "09f4a4bb-2f33-4db8-a5ed-fec6105b713f";
        string agentId = "306944b0-f26e-434d-bb37-3d994d98da83";

        string sessionId = Guid.NewGuid().ToString();

        string sessionPath = $"projects/{projectId}/locations/{location}/agents/{agentId}/sessions/{sessionId}";
        Console.WriteLine($"Session Path: {sessionPath}");

        SessionsClient sessionsClient = await SessionsClient.CreateAsync();

        IBotService botService = new DialogflowBotService(sessionsClient, sessionPath);

        IBotService decoratedBotService = new BotServiceDecorator(botService);

        /**** Use this for advanced bot ****/
        ChatBot chatBot = new AdvancedBot();
        chatBot.StartConversation();

        /*** Use this for basic bot ******/
        //ChatBot chatBot = new BasicBot();
        //chatBot.StartConversation();

        while (true)
       {
            Console.Write("You: ");
            string userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
                continue;
            }

            try
            {
                string botResponse = await botService.GetBotResponseAsync(userInput);
                Console.WriteLine($"Bot: {botResponse}");
            }
            catch (Exception ex)  
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
           

        }
    }


    //static async Task Main(string[] args)
    //{
    //    var botService = new DialogflowBotService(
    //        "winged-sol-443923-e8",  // Replace with your project ID
    //        "global",               // Replace with your agent's location
    //        "09f4a4bb-2f33-4db8-a5ed-fec6105b713f"         // Replace with your agent ID
    //    );

    //    Console.WriteLine("Type a message for the bot:");
    //    string userInput = Console.ReadLine();

    //    string botResponse = await botService.GetBotResponseAsync(userInput);
    //    Console.WriteLine($"Bot Response: {botResponse}");
    //}
}