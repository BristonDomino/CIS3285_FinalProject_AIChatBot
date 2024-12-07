using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject_AIChatBot
{
    public interface IBotService
    {
        string GetBotResponse(string userInput);

    }
}
