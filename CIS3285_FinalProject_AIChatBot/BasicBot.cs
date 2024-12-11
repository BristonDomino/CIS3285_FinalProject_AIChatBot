using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject_AIChatBot
{
    public class BasicBot : ChatBot
    {
        public override string BotType => "Basic bot";

        public override void StartConversation()
        {
            base.StartConversation();
            Console.WriteLine("This bot provides basic responses. ");
        }

    }


}
