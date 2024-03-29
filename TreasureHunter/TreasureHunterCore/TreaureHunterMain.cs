﻿/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Core
 * 
 * File:            Program.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using TreasureHunterCore.Administrative;

namespace TreasureHunterCore
{
    class TreaureHunterMain
    {
        static void Main(string[] args)
        {
            // Main Executable
            AppSettings settings = AppSettings.DevelopmentSettings();

            // Build the App
            TreasureHunterApp app = new TreasureHunterApp(settings);

            // Run + Exit
            int exitStatus = app.Run();
            return;
        }
    }
}
