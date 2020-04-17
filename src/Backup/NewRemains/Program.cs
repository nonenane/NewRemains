using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Nwuram.Framework.Project;
using Nwuram.Framework.Settings.Connection;
using Nwuram.Framework.Logging;

namespace NewRemains
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string []args)
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                Project.FillSettings(args);
                Logging.Init(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
                Logging.StartFirstLevel(1);
                Logging.Comment("Вход в программу");
                Logging.StopFirstLevel();
                //Config.userStatus = Nwuram.Framework.Settings.User.UserSettings.User.StatusCode;
                Application.Run(new frmMain());
                Logging.StartFirstLevel(2);
                Logging.Comment("Выход из программы");
                Logging.StopFirstLevel();
            }   
        }
    }
}
