# CIS3285_FinalProject_AIChatBot

CIS3285_FinalProject_AIChatBot
Overview
This is the final project for CIS3285 - Software Design, developed in C# using Visual Studio 2022. The goal of this project was to create a functional AI chatbot integrated with Google Dialogflow CX, showcasing various software design principles and patterns. The chatbot communicates with users via a command-line interface and provides dynamic responses powered by Dialogflow CX.

Features Implemented
The project was developed in sprints using Scrum methodology. Each sprint added new features and refined the design. Below is a summary of the implemented features:

Sprint 1
Dependency Injection: Implemented constructor injection in the DialogflowBotService class to ensure clean and testable code.
Interface Design: Created an IBotService interface to abstract chatbot logic.

Sprint 2
Asynchronous Programming: Refactored the chatbot logic to use async and await for improved responsiveness.
Enhanced Dependency Injection: Finalized the injection of SessionsClient and sessionPath into the DialogflowBotService class.

Sprint 3
Decorator Pattern: Implemented the BotServiceDecorator to extend functionality with logging.
Inheritance: Designed a parent ChatBot class with child classes for basic and advanced chatbot capabilities.

Additional Features
Integrated with Google Dialogflow CX for natural language processing.
A prebuilt template agent was incorporated to enhance the chatbot’s conversational abilities.
The chatbot handles user input dynamically and returns accurate responses from the Dialogflow agent.

How to Run the Project:
Clone the repository to your local machine.
Ensure you have Visual Studio 2022 installed.
Set up a Google Dialogflow CX agent and download the JSON service account key.
Update the GOOGLE_APPLICATION_CREDENTIALS path in Program.cs to point to your JSON key file.
Build and run the project.

Future Enhancements:
Add a graphical user interface (GUI) using Windows Forms or WPF.
Expand chatbot functionalities with more predefined intents and entities.
Implement additional integrations, such as database storage for chat history.

Project Team:
Developed by Briston and collaborators as part of the CIS3285 course project.
