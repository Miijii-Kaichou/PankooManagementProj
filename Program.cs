using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PankoojiManagementProj
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Login or create account, and pair keys
            StartUp.Init();

            //TODO: Selection Cycle (what to do inside the account)
            if (StartUp.Success)
                System.Begin();

            Console.ReadLine();
        }
    }

    internal static class StartUp
    {
        internal static bool Success { get; private set; }

        internal static void Init()
        {
            //TODO: Ask for PanID
            //TODO: Ask for Password
            Console.WriteLine("");
            string userIdentification = UserPrompt.Ask("PanID: ");
            string userPassword = UserPrompt.Ask("\nPassword: ", true);

            //TODO: Match PanID and Password to database, and check for valid key
            Identification inputID = new Identification(userIdentification);
            Password inputPassword = new Password(userPassword);

            PanAccount validationAccount = PanAccount.New(inputID, inputPassword);

            bool accountMatch = PanAuthorization.Validate(validationAccount);

            //TODO: Add option to create new account.

            Success = accountMatch;
        }
    }

    //The program after successful login or account create and key creation
    internal class System
    {
        internal static void Begin()
        {
            //Main Selection Loop begins here. Flush buffer
            Console.Clear();

            //Give User Application Options
            Console.Write(
                $"WELCOME TO THE PANKOO MANAGEMENT SYSTEM" +
                $"\n\n" +
                $"Please Input Command: " +
                $"*CURSOR GOES HERE*" +
                $"\n\n==========================================================================================================\n\n" +
                $"\n\t1) OPTION 1" +
                $"\n\t2) OPTION 2" +
                $"\n\t3) OPTION 3" +
                $"\n\t4) OPTION 4" +
                $"\n\t5) OPTION 5" +
                $"\n\n===========================================================================================================\n\n"
                );

            //TODO: Create thread for user input

        }
    }

    //User Account used to access list of passwords
    internal class PanAccount
    {
        PanAccount(Identification id, Password password)
        {
            accountID = id;
            accountPassword = password;
        }

        internal static PanAccount New(Identification id, Password password)
        {
            return new PanAccount(id, password);
        }

        internal Identification GetAccountId() => accountID;

        internal Password GetAccountPassword() => accountPassword;

        Identification accountID;
        Password accountPassword;
    }

    //PanAccount Authorization Class
    internal class PanAuthorization
    {
        internal static bool Successful { get; private set; }
        internal static bool Validate(PanAccount targetPanAccount)
        {
            //TODO: Search through database for existing account, otherwise, ask to create a new one
            //For now, fake access.s

            Successful = true;
            return Successful;
        }
    }

    //Identification of user PanAccount
    internal class Identification
    {
        internal string ID { get; private set; }
        internal Identification(string value)
        {
            ID = value;
        }
    }

    //Password of user PanAccount
    internal class Password
    {
        internal string Data { get; private set; }
        internal Password(string value)
        {
            Data = value;
        }
    }

    //Main connection to database/sql operations during main selection loop
    internal class DatabaseSession
    {

    }

    //Key used to match one device to database, or one external drive to device to database
    internal class Key
    {

    }

    //Encodes all infromation through unique algorithm
    internal class SecureEncode
    {

    }


    //Form Structure Class simply used to strucutre data input.
    //Will parse and extract data based on user input
    internal class ConsoleForm
    {

    }

    internal class UserPrompt
    {
        internal static string Ask(string prompt)
        {
            return Ask(prompt, false);
        }

        internal static string Ask(string prompt, bool allowInterception)
        {

            Console.WriteLine(prompt);

            //Check if to allow interception
            if (allowInterception)
            {
                string input = string.Empty;
                while (true)
                {
                    var key = Console.ReadKey(allowInterception);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        return input;
                    }
                    input += key.KeyChar;
                }
            }

            return Console.ReadLine();
        }
    }
}
