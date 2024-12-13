using CIS3285_FinalProject_AIChatBot;
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

namespace ChatbotGUIWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SendButton_Click_TextChanged(object sender, RoutedEventArgs e)
        {

            //string userInput = UserInputTextBox.Text;
            //if (string.IsNullOrWhiteSpace(userInput)) return;

            //// Use the bot service
            //string botResponse = await IBotService.GetBotResponseAsync(userInput);

            //// Display conversation
            //ConversationBox.Text += $"You: {userInput}\nBot: {botResponse}\n";

            //UserInputTextBox.Clear();
        }
    }
}