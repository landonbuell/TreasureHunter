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

        private BuildInfo _buildInfo;
        private bool _isDebugMode;
        private bool _clearConsole;

        public AppSettings(string outputPath)
        {
            // Constructor
            _pathStartup = Directory.GetCurrentDirectory();
            _pathOutput = Path.GetFullPath(outputPath);

            _logLevel = TextLogger.LogLevel.MESSAGE;
            _logToFile = true;
            _logToConsole = false;

            _buildInfo = new BuildInfo(0,0,0);
            _isDebugMode = true;
            _clearConsole = false;

            if (Directory.Exists(outputPath) == false)
            {
                Directory.CreateDirectory(outputPath);
            }

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

        public string BuildID
        {
            // Return the Current App Build ID
            get { return _buildInfo.ToString(); }
        }
        public bool IsDebugMode
        {
            // Get T/F If app is in Debug Mode
            get { return _isDebugMode; }
        }

        public bool ClearConsole
        {
            // Get T/F if we should clear the console between views
            get { return _clearConsole; }
        }


        #endregion

        #region Public Interface

        public static AppSettings DevelopmentSettings()
        {
            string outputPath = @"C:\Users\lando\Documents\GitHub\TreasureHunter\GameLogs\sessionAlpha";
            return new AppSettings(outputPath);
        }

        #endregion

        #region Private Interface

        private struct BuildInfo
        {
            private uint _buildMajor;
            private uint _buildMinor;
            private uint _buildRevision;

            public BuildInfo(uint major,uint minor,uint rev)
            {
                // Constructor
                _buildMajor = major;
                _buildMinor = minor;
                _buildRevision = rev;
            }

            public override string ToString()
            {
                // Cast to String
                string result = String.Format("{0}.{1}.{2}",
                    _buildMajor,_buildMinor, _buildRevision);
                return result;
            }

        }

        #endregion

    }
}
