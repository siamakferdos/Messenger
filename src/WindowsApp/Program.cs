using System.Diagnostics;
using System.Windows.Forms.Design;
using WindowsApp.MessageBroker;

namespace WindowsApp
{
    internal static class Program
    {
        const String APP_NAME_PREFIX = "NEW_INSTANCE_";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                CreateInstance($"{APP_NAME_PREFIX}New Instance");
                return;
            }
            if(args.Length == 1 && args[0].Contains(APP_NAME_PREFIX))
            {
                CreateInstance(args[0]);
                return;
            }
                
            foreach (var arg in args)
            {
                Process.Start(Application.ExecutablePath, APP_NAME_PREFIX + arg);
            }
        }

        static void CreateInstance(string arg)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMessanger(arg));
        }
    }
}