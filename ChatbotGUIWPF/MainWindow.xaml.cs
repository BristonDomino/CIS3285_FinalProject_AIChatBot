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
        private readonly IBotService _botService;

        public MainWindow()
        {
            InitializeComponent();

            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\bdddo.BRISTONSDESKTOP\OneDrive\files that can't be upload to school drive\Fall 2024\Software Design\Finual project\Jason file\winged-sol-443923-e8-c1cc1b1c1615.json");

            // Set up DialogflowBotService with credentials
            string projectId = "winged-sol-443923-e8";
            string location = "global";
            // string agentId = "09f4a4bb-2f33-4db8-a5ed-fec6105b713f";
            string agentId = "306944b0-f26e-434d-bb37-3d994d98da83";
            string sessionId = System.Guid.NewGuid().ToString();

            var sessionPath = $"projects/{projectId}/locations/{location}/agents/{agentId}/sessions/{sessionId}";
            var sessionsClient = SessionsClient.Create();

            _botService = new DialogflowBotService(sessionsClient, sessionPath);
        }

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

        private async Task<string> GetBotResponseAsync(string userInput)
        {
            return await _botService.GetBotResponseAsync(userInput);
        }

        private void AppendToChat(string message)
        {
            // Append message to RichTextBox
            ChatDisplay.Document.Blocks.Add(new Paragraph(new Run(message)));
            ChatDisplay.ScrollToEnd();
        }

        private async void userInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true; // Prevents the default behavior of Enter key (like moving focus)

                string userInput = userInputTextBox.Text;

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    // Display user input in the chat box
                    ChatDisplay.AppendText($"You: {userInput}\n");

                    // Get the bot's response
                    string botResponse = await _botService.GetBotResponseAsync(userInput);

                    // Display bot's response
                    ChatDisplay.AppendText($"Bot: {botResponse}\n");

                    // Clear the input TextBox
                    userInputTextBox.Clear();
                }
            }
        }
    }
}