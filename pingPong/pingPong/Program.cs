﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pingPong
{
    static class Program
    {
        public static frGame Game;
        public static frMenu Menu;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Game = new frGame();
            Menu = new frMenu();
            Application.Run(Menu);
        }

        public static bool IsInDesignMode { get { return Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1; } }
    }
}
