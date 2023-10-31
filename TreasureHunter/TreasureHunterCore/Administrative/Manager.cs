/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Views
 * 
 * File:            BaseView.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunterCore.Administrative
{
    internal abstract class Manager
    {
        // Parent Class for all Managers
        private TreasureHunterApp _app;
        private string _name;

        internal Manager(
            TreasureHunterApp app,
            string name)
        {
            // Constructor
            _app = app;   
            _name = name;

            LogConstruction();
        }

        ~Manager()
        {
            // Destructor
            LogDestruction();
        }

        #region Getters and Setters

        public TreasureHunterApp App
        {
            // Get the App reference
            get { return _app; }
        }

        public string Name
        {
            // Get the Name of this Manager
            get { return _name; }
        }

        #endregion

        #region Public Interface

        public void Initialize()
        {
            // Initialize this Manager
            LogInitialization();
            return;
        }

        public void Cleanup()
        {
            // Cleanup this Manager
            LogCleanup();
            return;
        }

        #endregion

        #region Protected Interface

        #endregion

        #region Private Interface

        private void LogConstruction()
        {
            // Log Construction Message
            string message = String.Format("Constructing Manager: {0}", Name);
            App.LogMessage(message, TextLogger.LogLevel.INFO);
            return;
        }

        private void LogInitialization()
        {
            // Log Initialization Message
            string message = String.Format("Initializing Manager: {0}", Name);
            App.LogMessage(message, TextLogger.LogLevel.INFO);
            return;
        }

        private void LogCleanup()
        {
            // Log Cleanup Message
            string message = String.Format("Cleaning up Manager: {0}", Name);
            App.LogMessage(message, TextLogger.LogLevel.INFO);
            return;
        }

        private void LogDestruction()
        {
            // Log Construction Message
            string message = String.Format("Destroying Manager: {0}", Name);
            App.LogMessage(message, TextLogger.LogLevel.INFO);
            return;
        }
        #endregion

    }
}
