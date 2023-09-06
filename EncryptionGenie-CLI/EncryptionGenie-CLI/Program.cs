using System.Diagnostics;


namespace EncryptionGenie
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            //Beginning of the program

            try
            {
                // If Windows, run the WinForm in separate process and terminate

                if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
                {

                    //The win-dependencies is developed as a separate solution and is integrated here to acheive cross-platform usability
                    //Both, this solution as well as win-dependencies, are built with .NET (7.0) CORE 

                    Process.Start("win-dependencies\\EncryptionGenie.exe");
                    Process.GetCurrentProcess().Kill();

                }
                // For any other operating system, run the CLI 
                else
                {
                    ExecuteCommandLine();
                }
            }
            // If WinForm does not work, run the CLI
            catch
            {
                ExecuteCommandLine();
            }
        }
        static void ExecuteCommandLine()
        {
            bool validAttempt = true;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Console.ResetColor();
            Console.WriteLine("Encryption Genie Application started.");

            //loop until user chooses to exit

            while (validAttempt)
            {
                try
                {

                    Console.WriteLine();

                    //Grab the operation type user wants to perform
                    int operationType = 0;

                    while (operationType < 1 || operationType > 2)
                    {
                        Console.ResetColor();
                        Console.WriteLine("Please select an option:");
                        Console.WriteLine("1. Encrypt a file");
                        Console.WriteLine("2. Decrypt a file");

                        Console.ForegroundColor = ConsoleColor.Green;
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out operationType))
                        {
                            if (operationType < 1 || operationType > 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid option selected. Try again.");
                            }
                        }
                    }

                    //Grab the file path as input 
                    string filePath = "";

                    while (filePath == "" || !Path.Exists(filePath))
                    {
                        Console.WriteLine();
                        Console.ResetColor();

                        //For Windows file path
                        if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
                        {
                            Console.WriteLine("Please enter a valid file path (Ex: C:\\Sample\\Sample.ext): ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string input = Console.ReadLine();

                            if (File.Exists(input))
                                filePath = input;
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("File path is invalid. Try again.");
                            }

                        }
                        // For Linux file apth
                        else
                        {
                            Console.WriteLine("Please enter a valid file path (Ex: /home/uname/Desktop/Sample.txt: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string input = Console.ReadLine();

                            input = input.Replace("/", "//");

                            if (File.Exists(input))
                                filePath = input;
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("File path is invalid. Try again.");
                            }
                        }




                    }

                    // if Operation is Encryption, ask user for the Encryption algorithm and Hash algorithm 
                    int encAlgorithmId = 0;
                    int hashAlgorithmId = 0;

                    if (operationType == 1)
                    {

                        while (encAlgorithmId < 1 || encAlgorithmId > 3)
                        {
                            Console.WriteLine();
                            Console.ResetColor();
                            Console.WriteLine("Please select encryption algorithm: ");
                            Console.WriteLine("1. 3DES");
                            Console.WriteLine("2. AES128");
                            Console.WriteLine("3. AES256");

                            Console.ForegroundColor = ConsoleColor.Green;
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out encAlgorithmId))
                            {
                                if (encAlgorithmId < 1 || encAlgorithmId > 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid option selected. Try again.");
                                }
                            }
                        }


                        while (hashAlgorithmId < 1 || hashAlgorithmId > 2)
                        {
                            Console.WriteLine();
                            Console.ResetColor();
                            Console.WriteLine("Please select hash algorithm for HMAC: ");
                            Console.WriteLine("1. SHA256");
                            Console.WriteLine("2. SHA512");

                            Console.ForegroundColor = ConsoleColor.Green;
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out hashAlgorithmId))
                            {
                                if (hashAlgorithmId < 1 || hashAlgorithmId > 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid option selected. Try again.");
                                }
                            }
                        }



                    }


                    // Grab password in hidden text from user
                    string secretText = "";

                    while (secretText == "" || secretText.Length < 8)
                    {
                        Console.WriteLine();
                        Console.ResetColor();

                        if (operationType == 1)
                            Console.WriteLine("Please enter a password that's at least 8 characters long: ");
                        else
                            Console.WriteLine("Please enter the password: ");

                        string password = "";
                        Console.ForegroundColor = ConsoleColor.Green;
                        while (true)
                        {
                            ConsoleKeyInfo key = Console.ReadKey(true);

                            if (key.Key == ConsoleKey.Enter)
                            {
                                break;
                            }
                            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                            {
                                password = password.Remove(password.Length - 1);
                                Console.Write("\b \b");
                            }
                            else if (key.KeyChar != '\u0000')
                            {
                                password += key.KeyChar;
                                Console.Write("*");
                            }
                        }

                        if (password.Length >= 8)
                            secretText = password;
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid password length. Try again.");
                        }
                    }

                    Console.WriteLine();
                    Controller controller = new Controller();


                    // If Operation requested is Encryption, call Controller's encryptFile() to encrypt the file
                    // Pass required params Enc Algo, Hash Algo, File Path and Password to the function
                    if (operationType == 1)
                    {
                        string encAlgo, hashAlgo;

                        switch (encAlgorithmId)
                        {
                            case 1: encAlgo = "3DES"; break;
                            case 2: encAlgo = "AES128"; break;
                            default: encAlgo = "AES256"; break;
                        }
                        switch (hashAlgorithmId)
                        {
                            case 1: hashAlgo = "SHA256"; break;
                            default: hashAlgo = "SHA512"; break;
                        }

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        string outputPath = controller.encryptFile(filePath, encAlgo, hashAlgo, secretText);

                        if (outputPath.Length > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine();
                            Console.WriteLine("File has been encrypted and saved at " + outputPath);
                        }

                    }
                    // If Operation requested is Decryption, call Controller's decryptFile() to decrypt the file
                    // Pass required params File Path and Password to the function
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        string outputPath = controller.decryptFile(filePath, secretText);

                        if (outputPath.Length > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine();
                            Console.WriteLine("File has been decrypted and saved at " + outputPath);
                        }
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.ToString());
                    Console.Write(e.ToString());
                }
                //If any exception occours, throw an error and ask if user wants to retry or exit
                finally
                {
                    int selectedOption = 0;


                    while (selectedOption < 1 || selectedOption > 2)
                    {
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Please select an option: ");
                        Console.WriteLine("1. Another Operation");
                        Console.WriteLine("2. Exit Program");

                        Console.ForegroundColor = ConsoleColor.Green;
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out selectedOption))
                        {
                            if (selectedOption < 1 || selectedOption > 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid option selected. Try again.");
                            }
                        }
                        if (selectedOption == 1)
                            validAttempt = true;
                        else
                            validAttempt = false;
                    }
                }


            }

            Console.WriteLine("Encryption Genie Application ended.");
            //End of the program
        }
    }
}
