using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace EncryptionGenie
{
    internal static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Log.Info("Encryption Genie Application started.");

            ApplicationConfiguration.Initialize();
            Application.Run(new EncryptForm());

            Log.Info("Encryption Genie Application ended.");

        }
    }
}
