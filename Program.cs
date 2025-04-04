using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using Figgle;


namespace Example1
{

    class voice
    {
        static void Main(String[] args)
        {



            SpeechSynthesizer synth = new SpeechSynthesizer();

            //Configure the synthesizer
            synth.Volume = 100; // set the volume (100-0)
            synth.Rate = 0; // set the speaking rate (-10 to 10)


            //Shows ASCII art through Figgle
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("======================================================================================================================");
            Console.WriteLine(FiggleFonts.Standard.Render("CyberSecurity is cool!"));
            Console.WriteLine("======================================================================================================================");

            //speaks a message
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("Chatbot: Hello I can talk.");
            synth.Speak("Hello I can talk.");

            //speaks for user's name
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Chatbot: Please enter your name: ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You:");
            synth.Speak("Please enter your name.");
            String userText = Console.ReadLine();
            //synth.Speak("Please enter your name.");




            //Shows ASCII art through Figgle
            //Console.WriteLine(FiggleFonts.Standard.Render("CyberSecurity is cool!"));
            //Greets user with their added name.
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Chatbot: Welcome: {userText}, how are you?");
            synth.Speak($"Welcome: {userText}, how are you?");
            String greeting = Console.ReadLine();
            //synth.Speak($"Welcome: {userText}, how are you?");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nYou:{greeting}");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Chatbot: I'm doing fine thanks {userText}.");
            synth.Speak($"I'm doing fine thanks {userText}.");

            //Prompts user to enter a key response to start explanation
            //Shows ASCII art through Figgle
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("======================================================================================================================");
            Console.WriteLine(FiggleFonts.Standard.Render("CyberSecurity is is cool!"));
            Console.WriteLine("======================================================================================================================");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Chatbot: Let's learn more about Cyber Security, {userText}!! I can tell you more about passwords, wifi, updates, antiviruses \n as well as phishing! \n However if you'd like {userText}, you can type 'exit' if you would want to leave this chat room:");
            synth.Speak($"Let's learn more about Cyber Security, {userText}!! I can tell you more about passwords, wifi, updates, antiviruses as well as phising! \nHowever if you'd like {userText}, you can type 'exit' if you would want to leave this chat room:");

            //If user enters one of selected key response, an explanation will pop up.
            Console.ForegroundColor = ConsoleColor.Blue;
            Dictionary<string, string> responses = new Dictionary<string, string>()
        {
                
                { "password", "Always use strong passwords with a mix of letters, numbers, and symbols." },
            { "phishing", "Phishing scams often involve fake emails or websites. Never click on links from unknown sources." },
            { "antivirus", "Keep your antivirus software up to date to protect your system." },
            { "update", "Regularly update your software to patch vulnerabilities." },
            { "wifi", "Avoid using public Wi-Fi for sensitive activities like online banking." }
        };

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nYou: ");
                string userInput = Console.ReadLine()?.ToLower();

                //If user enters exit, while statement stops loop
                if (userInput == "exit")
                {
                    //Shows ASCII art through Figgle
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("======================================================================================================================");
                    Console.WriteLine(FiggleFonts.Standard.Render("CyberSecurity is cool!"));
                    Console.WriteLine("======================================================================================================================");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    string goodbyeMessage = $"Goodbye {userText}! Have great caution online.";
                    Console.WriteLine("Chatbot: " + goodbyeMessage);
                    synth.Speak(goodbyeMessage);
                    break;
                }

                //
                bool foundResponse = false;
                foreach (var key in responses.Keys)
                {
                    if (userInput.Contains(key))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        string response = responses[key];
                        Console.WriteLine("Chatbot: " + response);
                        synth.Speak(response);
                        foundResponse = true;
                        break;
                    }
                }

                if (!foundResponse)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string defaultResponse = "Dang it!!! I don't have that knowlegde on that. However I can tell you more about phishing, passwords, updates, antiviruses or wifi.";
                    Console.WriteLine("Chatbot: " + defaultResponse);
                    synth.Speak(defaultResponse);
                }
            }


            

        }

    }
}

