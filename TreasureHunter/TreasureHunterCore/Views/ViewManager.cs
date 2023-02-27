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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TreasureHunterCore.Administrative;

namespace TreasureHunterCore.Views
{
    internal class ViewManager : Manager
    {
        // Governs the Currently Active View and Accepts User Input
        private static readonly string VIEW_MANAGER = "View Manager";

        private BaseView _currentView;
        

        internal ViewManager(
            TreasureHunterApp app) :
            base(app, VIEW_MANAGER)
        {
            // Constructor

            _currentView = new StartupView();
            
        }

        ~ViewManager()
        {
            // Destructor
            
        }

        public BaseView CurrentView
        {
            // Get or Set the Current View
            get { return _currentView; }
        }

        public bool SwitchToView(BaseView newView)
        {
            // Switch to a new View if it is not Null
            if (newView == null)
            {
                string message = "Not switching to null view";
                App.LogMessage(message, TextLogger.LogLevel.WARNING);
                return false;
            }
            else
            {
                string message = "Switching to new view";
                App.LogMessage(message, TextLogger.LogLevel.INFO);
                _currentView = newView;
                return true;
            }
        }

        #region Public Interface

        public void ShowCurrentView()
        {
            // Show the Current View to Console
            _currentView.ShowView();
            return;
        }

        public void ExecuteAction(int actionIndex)
        {
            // Execute the Action Prescribed by the Index
            if (actionIndex < 0 || actionIndex >= _currentView.NumActions)
            {
                // Action Index is Out of Range
                string message = String.Format(
                    "Action Index {0} is out of range for view {1} w/ {2} possible actions",
                    actionIndex, _currentView.ViewName, _currentView.NumActions);
                App.LogMessage(message, TextLogger.LogLevel.WARNING);
                return;
            }
            // Execute the Action
            _currentView.InvokeAction(actionIndex);
            return;
        }

        #endregion

        #region Private Interface

        #endregion
    }

}
