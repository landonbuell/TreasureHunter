﻿/*
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

        private AppSettings _settings;
        private TextLogger _logger;

        private AppStatus _status;
        private bool[] _statusFlags;

        private ViewManager _viewManager;
        private TaskManager _taskManager;
        private QueryManager _queryManager;

        internal TreasureHunterApp(
            AppSettings appSettings)
        {
            // Constructor
            _settings = appSettings;
            _logger = new TextLogger(appSettings);

            _status = AppStatus.SUCCESS;
            _statusFlags = new bool[7];

            _viewManager = new ViewManager(this);
            _taskManager = new TaskManager(this);
            _queryManager = new QueryManager(this);


            InitStatusFlags();
        }

        ~TreasureHunterApp()
        {
            // Destructor
        }

        #region Getters and Setters

        public AppStatus Status
        {
            // Get the Current Status of the Application
            get { return _status; }
            private set { _status = value; }
        }

        public bool ExitFlag
        {
            // Return the Exit Flag
            get { return _statusFlags[6]; }
            set { _statusFlags[6] = value; }
        }

        public AppSettings Settings
        {
            // Get the Current Settings
            get { return _settings; }
        }

        private ViewManager ViewManager
        {
            // Get the view Manager
            get { return _viewManager; }
        }

        private TaskManager TaskManager
        {
            // Get the Task Manager
            get { return _taskManager; }
        }

        private QueryManager QueryManager
        {
            // Get the query manager
            get { return _queryManager; }
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

        public void UpdateStatus(AppStatus newStatus, string reason)
        {
            // Update the internal status, and justify
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Updating AppStatus from ");
            stringBuilder.AppendFormat("{0} -> {1} ", Status.ToString(), newStatus.ToString());
            stringBuilder.Append("For reason: ");
            stringBuilder.Append(reason);
            // Log the message + update status
            LogMessage(stringBuilder.ToString(),TextLogger.LogLevel.INFO);
            Status = newStatus;
            return;
        }

        public int Run()
        {
            // Run the App's execution
            Startup();         
            if (Status == 0 && ExitFlag == false)
            {
                Execute();
            }
            Shutdown();
            return (int)Status;
        }

        internal bool UpdateStatus(AppStatus newStatus)
        {
            // Update the app status to the "worse" of the new provided and the current
            AppStatus oldStatus = Status;
            if (newStatus > oldStatus)
            {
                // Worse off
                Status = newStatus;
                if (Status == AppStatus.FAILURE)
                {
                    // App is in a Error state
                    ExitFlag = true;
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Private Interface

        private void InitStatusFlags()
        {
            // Initialize Status Flags to False
            for (int ii = 0; ii < _statusFlags.Length; ii++)
            {
                _statusFlags[ii] = false;
            }
            return;
        }

        private void Startup()
        {
            // Run App Startup Sequence
            BegunStartup = true;
            LogMessage("Begining startup sequence ... ", TextLogger.LogLevel.INFO);

            // Perform Load + App Setup Process
            PerformStartup();            

            LogMessage("Finished startup sequence ... ", TextLogger.LogLevel.INFO);
            FinishedStartup = true;
            return;
        }

        private void Execute()
        {
            // Run App Execution Squence
            BegunExecution = true;
            LogMessage("Begining execution sequence ... ", TextLogger.LogLevel.INFO);

            while ((TaskManager.CurrentTaskValid == true) && (Status != AppStatus.FAILURE))
            {
                TaskManager.ExecuteCurrentTask();
                TaskManager.MoveToNextTask();
            }

            LogMessage("Finished cleanup sequence ... ", TextLogger.LogLevel.INFO);
            FinishedExecution = true;
            return;
        }

        private void Shutdown()
        {
            // Run App Cleanup Sequence
            BegunCleanup = true;
            LogMessage("Begining cleanup sequence ... ", TextLogger.LogLevel.INFO);

            // Perform Load + App Setup Process
            PerformShutdown();

            LogMessage("Finished cleanup sequence ... ", TextLogger.LogLevel.INFO);
            FinishedCleanup = true;
            return;
        }

        private void PerformStartup()
        {
            // Perform the App startup sequence

            ViewManager.Initialize();
            QueryManager.Initialize();

            return;
        }

        private void PerformShutdown()
        {
            // Perform the App startup sequence

            ViewManager.Cleanup();
            QueryManager.Cleanup();

            return;
        }

        #endregion

    }
}
