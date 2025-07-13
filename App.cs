using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CSharpFundamentals.ConsoleApp.TrainingApps.PasswordManager
{
    public static class App
    {
        private static readonly Dictionary<string, string> _passwordEntries = new();

        public static void Run()
        {
            ReadPasswords();

            if (!_passwordEntries.ContainsKey("masterKey"))
            {
                Console.WriteLine("Please Enter Your MasterKey: ");
                string masterKeyPassword = Console.ReadLine();
                _passwordEntries.Add("masterKey", masterKeyPassword);
                SavePasswords();
            }
            while (true)
            {
                    Console.WriteLine("Please Enter Your MasterKey: ");
                    string masterKeyPassword = Console.ReadLine();

                    if (!ValidateMasterKey(masterKeyPassword))
                    {
                        Console.WriteLine("Invalid MasterKey ... You don't have permission.");
                        continue;
                    }

                    Console.WriteLine("Please Select an Option: ");
                    Console.WriteLine("1. List all passwords");
                    Console.WriteLine("2. Add/Change passwords");
                    Console.WriteLine("3. Get passwords");
                    Console.WriteLine("4. Delete passwords");
                    var selectedOption = Console.ReadLine();
                    if (selectedOption == "1")
                        ListAllPasswords();
                    else if (selectedOption == "2")
                        AddOrChangePasswords();
                    else if (selectedOption == "3")
                        GetPasswords();
                    else if (selectedOption == "4")
                        DeletePasswords();
                    else
                        Console.WriteLine("Invalid option");

                    Console.WriteLine("-----------------------------------------");
            }
            
        }
        
              
        private static void ListAllPasswords()
        {
            foreach (var entry in _passwordEntries) 
            {
                Console.WriteLine($"{entry.Key} = {entry.Value}");
            }
        }

        private static void AddOrChangePasswords()
        {
            Console.Write("Please enter the website/app name: ");
            var appName = Console.ReadLine();
            Console.Write("Please enter your password: ");
            var password = Console.ReadLine();

            if (_passwordEntries.ContainsKey(appName))
                _passwordEntries[appName] = password;
            else 
                _passwordEntries.Add(appName, password);

            SavePasswords();
        }

        private static void GetPasswords()
        {
            Console.Write("Please enter the website/app name: ");
            var appName = Console.ReadLine();
            if (_passwordEntries.ContainsKey(appName))
                Console.WriteLine($"Your Password is: {_passwordEntries[appName]}");
            else
                Console.WriteLine("Password not found");
        }

        private static void DeletePasswords()
        {
            Console.Write("Please enter the website/app name: ");
            var appName = Console.ReadLine();
            if (_passwordEntries.ContainsKey(appName))
            {
                _passwordEntries.Remove(appName);
                SavePasswords();
            }
            else
                Console.WriteLine("Password not found");
        }
        private static void ReadPasswords()
        {
            if (File.Exists("passwords.txt"))
            {
                var passwordLine = File.ReadAllText("passwords.txt");
                foreach (var line in passwordLine.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var equalIndex = line.IndexOf('=');
                        var appName = line.Substring(0, equalIndex);
                        var password = line.Substring(equalIndex + 1);
                        _passwordEntries.Add(appName, EncryptionUtlity.Decrypt(password));
                    }
                }

            }
          


        }
        private static void SavePasswords()
        {
            var sb = new StringBuilder();
            foreach (var entry in _passwordEntries)
                sb.AppendLine($"{entry.Key} = {EncryptionUtlity.Encrypt(entry.Value)}");
            File.WriteAllText("passwords.txt", sb.ToString());
            
        }
        private static bool ValidateMasterKey(string password)
        {
            if (_passwordEntries.ContainsKey("masterKey"))

               return _passwordEntries["masterKey"] == password;
             else
                    return false;
 
        }

    }
}

