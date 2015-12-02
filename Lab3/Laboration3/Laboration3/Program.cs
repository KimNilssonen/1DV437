﻿using System;
using Laboration3.Controller;

namespace Laboration3
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new GameController())
                game.Run();
        }
    }
#endif
}
