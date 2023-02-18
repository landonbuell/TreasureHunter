/*
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
            AppSettings settings = new AppSettings();

            // Build the App
            TreasureHunterApp app = new TreasureHunterApp(settings);
            TreasureHunterApp.RegisterSingleton(app);

            // Run the Startup
            app.Startup();

            // Run the Execution
            app.Execute();

            // Run the Shutdown
            app.Cleanup();

            // All Done

        }
    }
}
