/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Administrative
 * 
 * File:            TreasureHunterApp.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using System.IO;
using System.Text;

using TreasureHunterCore.Core;
using TreasureHunterCore.Views;

namespace TreasureHunterCore.Administrative
{
    internal class TreasureHunterApp
    {
        // Represents Main Treasure Hunter Game
        private static TreasureHunterApp? _instance = null;

        private AppSettings _settings;
        private TextLogger _logger;

        private AppStatus _status;

        private ViewManager _viewManager;

        private bool[] _statusFlags;
        private List<PresequenceCallback> _callbacksStartup;
        private List<PresequenceCallback> _callbacksExecute;
        private List<PresequenceCallback> _callbacksCleanup;

        private UserProfile _userProfile;




        internal TreasureHunterApp(
            AppSettings appSettings)
        {
            // Constructor
            _settings = appSettings;
            _logger = new TextLogger(appSettings);

            _status = AppStatus.UNKNOWN;

            _viewManager = new ViewManager(this);

            _statusFlags = new bool[6];
            _callbacksStartup = new List<PresequenceCallback>();
            _callbacksExecute = new List<PresequenceCallback>();
            _callbacksCleanup = new List<PresequenceCallback>();

            _userProfile = UserProfile.NullUserProfile();

            InitStatusFlags();
        }

        ~TreasureHunterApp()
        {
            // Destructor
            DeregisterSingleton();
        }

        #region Getters and Setters

        public AppStatus Status
        {
            // Get the Current Status of the Application
            get { return _status; }
        }

        public AppSettings Settings
        {
            // Get the Current Settings
            get { return _settings; }
        }

        public ViewManager ViewManager
        {
            // Get the view Manager
            get { return _viewManager; }
        }

        public bool BegunStartup
        {
            // Get or set if startup sequnece has begun
            get { return _statusFlags[0]; }
            private set { _statusFlags[0] = value; }  
        }

        public bool FinishedStartup
        {
            // Get or Set if startup sequence has finished
            get {  return _statusFlags[1]; }
            private set { _statusFlags[1] = value; }
        }

        public bool BegunExecution
        {
            // Get or set if execution sequnece has begun
            get { return _statusFlags[2]; }
            private set { _statusFlags[2] = value; }
        }

        public bool FinishedExecution
        {
            // Get or set if execution sequnece has finished
            get { return _statusFlags[3]; }
            private set { _statusFlags[3] = value; }
        }

        public bool BegunCleanup
        {
            // Get or set if cleanup sequnece has begun
            get { return _statusFlags[4]; }
            private set { _statusFlags[4] = value; }
        }

        public bool FinishedCleanup
        {
            // Get or set if cleanup sequnece has begun
            get { return _statusFlags[5]; }
            private set { _statusFlags[5] = value; }
        }

        #endregion

        #region Public Interface

        public void LogMessage(
            string message,
            TextLogger.LogLevel logLevel)
        {
            // Log a Message
            _logger.LogMessage(message, logLevel);
            return;
        }

        public void Startup()
        {
            // Run App Startup Sequence
            BegunStartup = true;
            EvaluateStartupCallbacks();

            // Show Message To User + Load the Profile
            DisplayStartupMessageToConsole();
            LoadUserProfile();



            FinishedStartup = true;
            return;
        }

        public void Execute()
        {
            // Run App Execution Squence
            BegunExecution = true;
            EvaluateExecuteCallbacks();


            FinishedExecution = true;
            return;
        }

        public void Cleanup()
        {
            // Run App Cleanup Sequence
            BegunCleanup = true;
            EvaluateCleanupCallbacks();



            FinishedCleanup = true;
            return;
        }



        #endregion

        #region Private Interface

        private void EvaluateStartupCallbacks()
        {
            // Evaluate all startup callbacks
            foreach (PresequenceCallback item in _callbacksStartup)
            {
                AppStatus newStatus = item.Invoke(this);
                UpdateStatus(newStatus);
            }
            return;
        }

        private void EvaluateExecuteCallbacks()
        {
            // Evaluate all startup callbacks
            foreach (PresequenceCallback item in _callbacksExecute)
            {
                AppStatus newStatus = item.Invoke(this);
                UpdateStatus(newStatus);
            }
            return;
        }

        private void EvaluateCleanupCallbacks()
        {
            // Evaluate all startup callbacks
            foreach (PresequenceCallback item in _callbacksCleanup)
            {
                AppStatus newStatus = item.Invoke(this);
                UpdateStatus(newStatus);
            }
            return;
        }

        private bool UpdateStatus(AppStatus newStatus)
        {
            // Update the app status to the "worse" of the new provided and the current
            AppStatus oldStatus = _status;
            if (newStatus > oldStatus)
            {
                // Worse off
                _status = newStatus;
                return true;
            }
            return false;
        }

        private void InitStatusFlags()
        {
            // Initialize Status Flags to False
            for (int ii = 0; ii < _statusFlags.Length; ii++)
            {
                _statusFlags[ii] = false;   
            }
            return;
        }

        private void DisplayStartupMessageToConsole()
        {
            // Show Startup Message to Console
            ViewStartup startupView = new ViewStartup();
            _viewManager.SwitchToView(startupView);
            _viewManager.ShowCurrentView();
            return;
        }

        private void LoadUserProfile()
        {
            // Logic to Load User Profile
            return;
        }


        private void Shutdown()
        {
            // Handle Shutdown Flag
        }

        private bool DeregisterSingleton()
        {
            // Deregister this instance is the "Singleton" if applicable
            if (_instance != null)
            {
                if (_instance == this)
                {
                    _instance = null;
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Static Interface

        internal static bool RegisterSingleton(TreasureHunterApp app)
        {
            // Register provided instance as the "Singleton" instance
            if (app == null)
            {
                // Got null instance?
                return false;
            }
            if (_instance == null)
            {
                // Successfuly Registered app
                _instance = app;
                return true;
            }
            else
            {
                // Singleton Already Exists
                return false;
            }
        }

        internal static TreasureHunterApp? GetInstance
        {
            // Return previously registered Singleton Instance
            get { return _instance; }
        }

        #endregion

    }
}
