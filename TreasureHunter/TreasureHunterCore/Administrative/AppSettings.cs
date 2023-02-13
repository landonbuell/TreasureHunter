/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Administrative
 * 
 * File:            AppSettings.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using System.IO;

namespace TreasureHunterCore.Administrative
{
    internal class AppSettings
    {
        // Store all Runtime Settings

        private string _pathStartup;
        private string _pathOutput;

        private TextLogger.LogLevel _logLevel;
        private bool _logToFile;
        private bool _logToConsole;

        private bool _isDebugMode;

        public AppSettings()
        {
            // Constructor
            _pathStartup = Directory.GetCurrentDirectory();
            _pathOutput = Path.Combine(_pathStartup, "..", "..", "outputLog");

            _logLevel = TextLogger.LogLevel.MESSAGE;
            _logToFile = true;
            _logToConsole = false;

            _isDebugMode = true;
        }

        #region Getters and Setters

        public string StartupPath
        {
            // Get the App's Startup Path
            get { return _pathStartup; }
        }

        public string OutputPath
        {
            // Get the App's Output Logging Path
            get { return _pathOutput; }
        }

        public TextLogger.LogLevel MinimumLogLevel
        {
            // Get the Logger's Minimum Required Level
            get { return _logLevel; }
        }

        public bool LogToFile
        {
            // Get if messages should be logged to specified file
            get { return _logToFile; }
        }

        public bool LogToConsole
        {
            // Get if messages should be logged to specified file
            get { return _logToConsole; }
        }

        public bool IsDebugMode
        {
            // Get T/F If app is in Debug Mode
            get { return IsDebugMode; } 
        }


        #endregion

        #region Public Interface

        public void ParseUserInputs(ref string[] args)
        {
            // Parse User Inputs and Apply the to settings
        }

        #endregion

        #region Private Interface

        #endregion

    }
}
