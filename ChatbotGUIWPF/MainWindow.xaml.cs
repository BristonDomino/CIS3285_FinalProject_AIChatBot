using CIS3285_FinalProject_AIChatBot;
using Google.Cloud.Dialogflow.Cx.V3;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Google.Cloud.Dialogflow.Cx.V3.ConversationTurn.Types;

namespace CIS3285_FinalProject_AIChatBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // this will declare the bot service for sending and reciving messages
        private readonly IBotService _botService;

        public MainWindow()
        {
            InitializeComponent();

            // this code will find the jason file strored on the local computer
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\bdddo.BRISTONSDESKTOP\OneDrive\files that can't be upload to school drive\Fall 2024\Software Design\Finual project\Jason file\winged-sol-443923-e8-c1cc1b1c1615.json");

            //  Set up Dialogflow credentials and initialize the bot service
            string projectId = "winged-sol-443923-e8";
            string location = "global";
            // string agentId = "09f4a4bb-2f33-4db8-a5ed-fec6105b713f";
            string agentId = "306944b0-f26e-434d-bb37-3d994d98da83";
            string sessionId = System.Guid.NewGuid().ToString();

            var sessionPath = $"projects/{projectId}/locations/{location}/agents/{agentId}/sessions/{sessionId}";
            var sessionsClient = SessionsClient.Create();

            _botService = new DialogflowBotService(sessionsClient, sessionPath);
        }

        /// <summary>
        /// Handles the Send button click event. Sends user input to the bot and displays the response.
        /// </summary>
        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Get User Input
            string userInput = userInputTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(userInput))
            {
                // Add User message to ChatDisplay
                AppendToChat("You: " + userInput);

                // Call Dialogflow bot to get response
                string botResponse = await GetBotResponseAsync(userInput);

                // Display bot response in ChatDisplay
                AppendToChat("Bot: " + botResponse);

                // Clear input box
                userInputTextBox.Clear();
            }
        }

        /// <summary>
        /// Sends user input to the bot service and retrieves the response.
        /// </summary>
        private async Task<string> GetBotResponseAsync(string userInput)
        {
            return await _botService.GetBotResponseAsync(userInput);
        }

        /// <summary>
        /// Adds a message to the chat display with a new line.
        /// </summary>
        /// <param name="message">The message to append.</param>
        private void AppendToChat(string message)
        {
            // Append message to RichTextBox
            ChatDisplay.Document.Blocks.Add(new Paragraph(new Run(message)));
            ChatDisplay.ScrollToEnd();
        }

        /// <summary>
        /// Handles the Enter key press event to send messages.
        /// </summary>
        private async void userInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true; // Prevents the default behavior of Enter key (like moving focus)

                string userInput = userInputTextBox.Text;

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    // Display user input in the chat box with time and date
                    ChatDisplay.AppendText($"[{DateTime.Now:T}] You: {userInput}\n");

                    // Get the bot's response
                    string botResponse = await _botService.GetBotResponseAsync(userInput);

                    // Display bot's response with the time and date
                    ChatDisplay.AppendText($"[{DateTime.Now:T}] Bot: {botResponse}\n");


                    // Clear the input TextBox
                    userInputTextBox.Clear();
                }
            }
        }
    }
}